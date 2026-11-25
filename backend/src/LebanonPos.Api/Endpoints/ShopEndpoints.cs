using LebanonPos.Api.Auth;
using LebanonPos.Domain.Entities;
using LebanonPos.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LebanonPos.Api.Endpoints;

public record ShopDto(Guid Id, string Name, string? NameAr, string? VatNumber, string? Address, string? Phone,
    string? ReceiptFooter, string DefaultLanguage, bool PricesIncludeVat, long LbpCashUnit);
public record UpdateShopRequest(string Name, string? NameAr, string? VatNumber, string? Address, string? Phone,
    string? ReceiptFooter, string DefaultLanguage, bool PricesIncludeVat, long LbpCashUnit);
public record RegisterDto(Guid Id, string Code, string Name, bool IsActive, int LastNumber);
public record ExchangeRateDto(Guid Id, long LbpPerUsd, DateTimeOffset EffectiveFrom, Guid SetByUserId);
public record SetExchangeRateRequest(long LbpPerUsd);
public record VatRateDto(Guid Id, int RateBps, DateOnly EffectiveFrom);
public record AddVatRateRequest(int RateBps, DateOnly EffectiveFrom);
public record AuditDto(long Id, Guid? UserId, string Action, string? EntityType, string? EntityId, string? Details, DateTimeOffset At);

public static class ShopEndpoints
{
    private static readonly string[] Languages = ["ar", "en"];
    /// <summary>Sanity limits that catch typing mistakes such as a missing or extra zero.</summary>
    private const long MinRate = 1_000, MaxRate = 10_000_000;

    private static ShopDto ToDto(Shop s) => new(s.Id, s.Name, s.NameAr, s.VatNumber, s.Address, s.Phone,
        s.ReceiptFooter, s.DefaultLanguage, s.PricesIncludeVat, s.LbpCashUnit);

    public static Task<ExchangeRate?> CurrentRateAsync(this PosDbContext db, DateTimeOffset at) =>
        db.ExchangeRates.Where(r => r.EffectiveFrom <= at).OrderByDescending(r => r.EffectiveFrom).FirstOrDefaultAsync();

    public static Task<VatRate?> CurrentVatAsync(this PosDbContext db, DateOnly on) =>
        db.VatRates.Where(r => r.EffectiveFrom <= on).OrderByDescending(r => r.EffectiveFrom).FirstOrDefaultAsync();

    public static void MapShop(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api").RequireAuthorization();

        api.MapGet("/shop", async (PosDbContext db, CurrentUser current) =>
            ToDto(await db.Shops.SingleAsync(s => s.Id == current.RequiredShopId)));

        api.MapPut("/shop", async (UpdateShopRequest req, PosDbContext db, CurrentUser current) =>
        {
            if (Common.Clean(req.Name) is not { } name) return Common.Invalid("name", "Shop name is required.");
            if (!Languages.Contains(req.DefaultLanguage)) return Common.Invalid("defaultLanguage", "Language must be ar or en.");
            if (req.LbpCashUnit is < 1 or > 100_000) return Common.Invalid("lbpCashUnit", "Cash unit must be between 1 and 100,000 LBP.");

            var shop = await db.Shops.SingleAsync(s => s.Id == current.RequiredShopId);
            shop.Name = name;
            shop.NameAr = Common.Clean(req.NameAr);
            shop.VatNumber = Common.Clean(req.VatNumber);
            shop.Address = Common.Clean(req.Address);
            shop.Phone = Common.Clean(req.Phone);
            shop.ReceiptFooter = Common.Clean(req.ReceiptFooter);
            shop.DefaultLanguage = req.DefaultLanguage;
            shop.PricesIncludeVat = req.PricesIncludeVat;
            shop.LbpCashUnit = req.LbpCashUnit;
            db.Audit(current, "shop.updated", nameof(Shop), shop.Id);
            await db.SaveChangesAsync();
            return Results.Ok(ToDto(shop));
        }).RequireAuthorization(Policies.OwnerOnly);

        api.MapGet("/registers", async (PosDbContext db) =>
        {
            var registers = await db.Registers.OrderBy(r => r.Code).ToListAsync();
            var last = await db.Sales.GroupBy(s => s.RegisterCode)
                .Select(g => new { Code = g.Key, Last = g.Max(s => s.Number) })
                .ToDictionaryAsync(x => x.Code, x => x.Last);
            return registers.Select(r => new RegisterDto(r.Id, r.Code, r.Name, r.IsActive, last.GetValueOrDefault(r.Code)));
        });

        api.MapGet("/exchange-rates/current", async (PosDbContext db) =>
            await db.CurrentRateAsync(DateTimeOffset.UtcNow) is { } r
                ? Results.Ok(new ExchangeRateDto(r.Id, r.LbpPerUsd, r.EffectiveFrom, r.SetByUserId))
                : Results.NotFound());

        api.MapGet("/exchange-rates", async (PosDbContext db) =>
            (await db.ExchangeRates.OrderByDescending(r => r.EffectiveFrom).Take(100).ToListAsync())
                .Select(r => new ExchangeRateDto(r.Id, r.LbpPerUsd, r.EffectiveFrom, r.SetByUserId)));

        api.MapPost("/exchange-rates", async (SetExchangeRateRequest req, PosDbContext db, CurrentUser current) =>
        {
            if (req.LbpPerUsd is < MinRate or > MaxRate)
                return Common.Invalid("lbpPerUsd", $"Rate must be between {MinRate:N0} and {MaxRate:N0} LBP per dollar.");

            var previous = await db.CurrentRateAsync(DateTimeOffset.UtcNow);
            var rate = new ExchangeRate
            {
                ShopId = current.RequiredShopId,
                LbpPerUsd = req.LbpPerUsd,
                EffectiveFrom = DateTimeOffset.UtcNow,
                SetByUserId = current.UserId,
            };
            db.ExchangeRates.Add(rate);
            db.Audit(current, "rate.changed", nameof(ExchangeRate), rate.Id, new { From = previous?.LbpPerUsd, To = rate.LbpPerUsd });
            await db.SaveChangesAsync();
            return Results.Created("/api/exchange-rates/current", new ExchangeRateDto(rate.Id, rate.LbpPerUsd, rate.EffectiveFrom, rate.SetByUserId));
        }).RequireAuthorization(Policies.ManagerUp);

        api.MapGet("/vat-rates", async (PosDbContext db) =>
            (await db.VatRates.OrderByDescending(r => r.EffectiveFrom).ToListAsync())
                .Select(r => new VatRateDto(r.Id, r.RateBps, r.EffectiveFrom)));

        api.MapPost("/vat-rates", async (AddVatRateRequest req, PosDbContext db, CurrentUser current) =>
        {
            if (req.RateBps is < 0 or > 5000) return Common.Invalid("rateBps", "VAT must be between 0% and 50%.");
            if (await db.VatRates.AnyAsync(r => r.EffectiveFrom == req.EffectiveFrom))
                return Common.Invalid("effectiveFrom", "A VAT rate already starts on this date.");

            var rate = new VatRate { ShopId = current.RequiredShopId, RateBps = req.RateBps, EffectiveFrom = req.EffectiveFrom };
            db.VatRates.Add(rate);
            db.Audit(current, "vat.added", nameof(VatRate), rate.Id, new { rate.RateBps, rate.EffectiveFrom });
            await db.SaveChangesAsync();
            return Results.Created("/api/vat-rates", new VatRateDto(rate.Id, rate.RateBps, rate.EffectiveFrom));
        }).RequireAuthorization(Policies.OwnerOnly);

        api.MapGet("/audit", async (PosDbContext db, int? take) =>
            (await db.AuditEntries.OrderByDescending(a => a.Id).Take(Math.Clamp(take ?? 100, 1, 500)).ToListAsync())
                .Select(a => new AuditDto(a.Id, a.UserId, a.Action, a.EntityType, a.EntityId, a.Details, a.At)))
            .RequireAuthorization(Policies.OwnerOnly);
    }
}
