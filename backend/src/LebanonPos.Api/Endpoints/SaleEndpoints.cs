using LebanonPos.Api.Auth;
using LebanonPos.Domain;
using LebanonPos.Domain.Entities;
using LebanonPos.Domain.Money;
using LebanonPos.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LebanonPos.Api.Endpoints;

public record SaleLineRequest(Guid? ProductId, string Name, string? NameAr, decimal Quantity,
    Currency PriceCurrency, long UnitPriceMinor, long DiscountMinor, TaxCategory TaxCategory);
public record SalePaymentRequest(PaymentMethod Method, Currency Currency, long AmountMinor);
public record CreateSaleRequest(Guid Id, string RegisterCode, int Number, DateTimeOffset SoldAt,
    long LbpPerUsd, int VatRateBps, bool PricesIncludeVat,
    List<SaleLineRequest> Lines, List<SalePaymentRequest> Payments, long ChangeUsdCents, long ChangeLbp);
public record VoidSaleRequest(string Reason);

public record SaleLineDto(Guid? ProductId, string Name, string? NameAr, decimal Quantity, Currency PriceCurrency,
    long UnitPriceMinor, long DiscountMinor, TaxCategory TaxCategory, long LineTotalMinor, long VatMinor);
public record SalePaymentDto(PaymentMethod Method, Currency Currency, long AmountMinor);
public record SaleDto(Guid Id, string RegisterCode, int Number, string InvoiceNumber, Guid CashierId,
    DateTimeOffset SoldAt, long LbpPerUsd, int VatRateBps, bool PricesIncludeVat,
    long TotalUsdCents, long TotalLbp, long VatUsdCents, long VatLbp, long ChangeUsdCents, long ChangeLbp,
    SaleStatus Status, string? VoidReason, string? ReviewNote,
    List<SaleLineDto> Lines, List<SalePaymentDto> Payments);
public record DailyReportDto(DateOnly Date, int SalesCount, int VoidedCount, long TotalUsdCents, long TotalLbp, long VatLbp,
    long CashUsdCents, long CashLbp, long CardUsdCents, long CardLbp, int NeedsReviewCount);

public static class SaleEndpoints
{
    private const int MaxLines = 500;

    private static SaleDto ToDto(Sale s) => new(s.Id, s.RegisterCode, s.Number, $"{s.RegisterCode}-{s.Number:D6}", s.CashierId,
        s.SoldAt, s.LbpPerUsd, s.VatRateBps, s.PricesIncludeVat,
        s.TotalUsdCents, s.TotalLbp, s.VatUsdCents, s.VatLbp, s.ChangeUsdCents, s.ChangeLbp,
        s.Status, s.VoidReason, s.ReviewNote,
        s.Lines.Select(l => new SaleLineDto(l.ProductId, l.Name, l.NameAr, l.Quantity, l.PriceCurrency,
            l.UnitPriceMinor, l.DiscountMinor, l.TaxCategory, l.LineTotalMinor, l.VatMinor)).ToList(),
        s.Payments.Select(p => new SalePaymentDto(p.Method, p.Currency, p.AmountMinor)).ToList());

    private static IResult? Validate(CreateSaleRequest req)
    {
        if (req.Id == Guid.Empty) return Common.Invalid("id", "Sale id is required.");
        if (req.Number <= 0) return Common.Invalid("number", "Invoice number must be positive.");
        if (req.LbpPerUsd <= 0) return Common.Invalid("lbpPerUsd", "Exchange rate is required.");
        if (req.VatRateBps is < 0 or > 5000) return Common.Invalid("vatRateBps", "VAT rate is out of range.");
        if (req.Lines is null || req.Lines.Count == 0) return Common.Invalid("lines", "A sale needs at least one line.");
        if (req.Lines.Count > MaxLines) return Common.Invalid("lines", $"A sale can have at most {MaxLines} lines.");
        if (req.ChangeUsdCents < 0 || req.ChangeLbp < 0) return Common.Invalid("change", "Change cannot be negative.");
        foreach (var line in req.Lines)
        {
            if (Common.Clean(line.Name) is null) return Common.Invalid("lines", "Every line needs a name.");
            if (line.Quantity <= 0) return Common.Invalid("lines", "Quantity must be positive.");
            if (line.UnitPriceMinor < 0 || line.DiscountMinor < 0) return Common.Invalid("lines", "Prices and discounts cannot be negative.");
            if (!Enum.IsDefined(line.PriceCurrency) || !Enum.IsDefined(line.TaxCategory)) return Common.Invalid("lines", "Unknown currency or tax category.");
        }
        foreach (var payment in req.Payments ?? [])
        {
            if (payment.AmountMinor <= 0) return Common.Invalid("payments", "Payment amounts must be positive.");
            if (!Enum.IsDefined(payment.Currency) || !Enum.IsDefined(payment.Method)) return Common.Invalid("payments", "Unknown currency or payment method.");
        }
        return null;
    }

    /// <summary>
    /// A sale made offline has already happened, so it is never refused for numbers that do not add up.
    /// It is stored and flagged, and the owner reviews it.
    /// </summary>
    private static string? Review(CreateSaleRequest req, SaleTotals totals, Shop shop, ExchangeRate? serverRate, VatRate? serverVat)
    {
        var notes = new List<string>();
        var payments = (req.Payments ?? []).Select(p => new PaymentInput(p.Currency, p.AmountMinor)).ToList();
        var paid = payments.Sum(p => MoneyMath.ToUsd(p.Currency, p.AmountMinor, req.LbpPerUsd));
        var change = req.ChangeUsdCents / 100m + req.ChangeLbp / (decimal)req.LbpPerUsd;
        var difference = paid - change - totals.TotalUsdExact(req.LbpPerUsd);
        // Change is rounded to the cash unit, so allow one full unit either way.
        var tolerance = ChangeCalculator.Tolerance(req.LbpPerUsd, shop.LbpCashUnit) * 2;
        if (difference < -tolerance) notes.Add($"Payments are short by ${-difference:0.00}.");
        else if (difference > tolerance) notes.Add($"Payments exceed the total by ${difference:0.00}.");

        if (serverRate is null) notes.Add("No exchange rate was set when this sale was made.");
        else if (serverRate.LbpPerUsd != req.LbpPerUsd) notes.Add($"Sale used rate {req.LbpPerUsd:N0}; the shop rate was {serverRate.LbpPerUsd:N0}.");

        if (serverVat is not null && serverVat.RateBps != req.VatRateBps) notes.Add($"Sale used VAT {req.VatRateBps / 100m}%; the rate in force was {serverVat.RateBps / 100m}%.");
        if (shop.PricesIncludeVat != req.PricesIncludeVat) notes.Add("Sale used a different VAT-inclusive setting than the shop.");

        return notes.Count == 0 ? null : string.Join(" ", notes);
    }

    public static void MapSales(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api").RequireAuthorization();

        api.MapPost("/sales", async (CreateSaleRequest req, PosDbContext db, CurrentUser current) =>
        {
            if (Validate(req) is { } problem) return problem;

            // The same sale sent twice (a retry after a lost connection) is stored once.
            var existing = await db.Sales.Include(s => s.Lines).Include(s => s.Payments).FirstOrDefaultAsync(s => s.Id == req.Id);
            if (existing is not null) return Results.Ok(ToDto(existing));

            var registerCode = req.RegisterCode?.Trim() ?? "";
            if (!await db.Registers.AnyAsync(r => r.Code == registerCode)) return Common.Invalid("registerCode", "Unknown till.");
            if (await db.Sales.AnyAsync(s => s.RegisterCode == registerCode && s.Number == req.Number))
                return Results.Conflict(new { message = $"Invoice {registerCode}-{req.Number:D6} already exists." });

            SaleTotals totals;
            try
            {
                totals = SaleCalculator.Calculate(
                    req.Lines.Select(l => new SaleLineInput(l.PriceCurrency, l.UnitPriceMinor, l.Quantity, l.DiscountMinor, l.TaxCategory)).ToList(),
                    req.LbpPerUsd, req.VatRateBps, req.PricesIncludeVat);
            }
            catch (ArgumentException ex)
            {
                return Common.Invalid("lines", ex.Message);
            }

            var shop = await db.Shops.SingleAsync(s => s.Id == current.RequiredShopId);
            var soldOn = DateOnly.FromDateTime(TimeZoneInfo.ConvertTime(req.SoldAt, Common.Beirut).DateTime);
            var sale = new Sale
            {
                Id = req.Id,
                ShopId = shop.Id,
                RegisterCode = registerCode,
                Number = req.Number,
                CashierId = current.UserId,
                SoldAt = req.SoldAt.ToUniversalTime(),
                LbpPerUsd = req.LbpPerUsd,
                VatRateBps = req.VatRateBps,
                PricesIncludeVat = req.PricesIncludeVat,
                TotalUsdCents = totals.TotalUsdCents,
                TotalLbp = totals.TotalLbp,
                VatUsdCents = totals.VatUsdCents,
                VatLbp = totals.VatLbp,
                ChangeUsdCents = req.ChangeUsdCents,
                ChangeLbp = req.ChangeLbp,
                ReviewNote = Review(req, totals, shop, await db.CurrentRateAsync(req.SoldAt), await db.CurrentVatAsync(soldOn)),
                Lines = req.Lines.Select((l, i) => new SaleLine
                {
                    ProductId = l.ProductId,
                    Name = l.Name.Trim(),
                    NameAr = Common.Clean(l.NameAr),
                    Quantity = l.Quantity,
                    PriceCurrency = l.PriceCurrency,
                    UnitPriceMinor = l.UnitPriceMinor,
                    DiscountMinor = l.DiscountMinor,
                    TaxCategory = l.TaxCategory,
                    LineTotalMinor = totals.Lines[i].LineTotalMinor,
                    VatMinor = totals.Lines[i].VatMinor,
                }).ToList(),
                Payments = (req.Payments ?? []).Select(p => new SalePayment { Method = p.Method, Currency = p.Currency, AmountMinor = p.AmountMinor }).ToList(),
            };
            db.Sales.Add(sale);
            await db.SaveChangesAsync();
            return Results.Created($"/api/sales/{sale.Id}", ToDto(sale));
        });

        api.MapGet("/sales/{id:guid}", async (Guid id, PosDbContext db) =>
            await db.Sales.Include(s => s.Lines).Include(s => s.Payments).FirstOrDefaultAsync(s => s.Id == id) is { } sale
                ? Results.Ok(ToDto(sale))
                : Results.NotFound());

        api.MapGet("/sales", async (PosDbContext db, DateTimeOffset? from, DateTimeOffset? to, int? take) =>
        {
            var start = from ?? DateTimeOffset.UtcNow.AddDays(-1);
            var end = to ?? DateTimeOffset.UtcNow.AddMinutes(5);
            var sales = await db.Sales.Include(s => s.Lines).Include(s => s.Payments)
                .Where(s => s.SoldAt >= start && s.SoldAt < end)
                .OrderByDescending(s => s.SoldAt)
                .Take(Math.Clamp(take ?? 100, 1, 500))
                .AsSplitQuery()
                .ToListAsync();
            return sales.Select(ToDto);
        });

        api.MapPost("/sales/{id:guid}/void", async (Guid id, VoidSaleRequest req, PosDbContext db, CurrentUser current) =>
        {
            if (Common.Clean(req.Reason) is not { } reason) return Common.Invalid("reason", "A reason is required to cancel a sale.");
            var sale = await db.Sales.Include(s => s.Lines).Include(s => s.Payments).FirstOrDefaultAsync(s => s.Id == id);
            if (sale is null) return Results.NotFound();
            if (sale.Status == SaleStatus.Voided) return Results.Ok(ToDto(sale));

            sale.Status = SaleStatus.Voided;
            sale.VoidedAt = DateTimeOffset.UtcNow;
            sale.VoidedByUserId = current.UserId;
            sale.VoidReason = reason;
            db.Audit(current, "sale.voided", nameof(Sale), sale.Id, new { Invoice = $"{sale.RegisterCode}-{sale.Number:D6}", sale.TotalUsdCents, reason });
            await db.SaveChangesAsync();
            return Results.Ok(ToDto(sale));
        }).RequireAuthorization(Policies.ManagerUp);

        // One Beirut calendar day: sales, VAT in lira, and what should be in the drawer in each currency.
        api.MapGet("/reports/daily", async (PosDbContext db, DateOnly? date) =>
        {
            var day = date ?? DateOnly.FromDateTime(TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, Common.Beirut).DateTime);
            var localStart = day.ToDateTime(TimeOnly.MinValue);
            var start = new DateTimeOffset(localStart, Common.Beirut.GetUtcOffset(localStart)).ToUniversalTime();
            var localEnd = day.AddDays(1).ToDateTime(TimeOnly.MinValue);
            var end = new DateTimeOffset(localEnd, Common.Beirut.GetUtcOffset(localEnd)).ToUniversalTime();

            var sales = await db.Sales.Include(s => s.Payments)
                .Where(s => s.SoldAt >= start && s.SoldAt < end)
                .ToListAsync();
            var completed = sales.Where(s => s.Status == SaleStatus.Completed).ToList();
            long Paid(PaymentMethod method, Currency currency) =>
                completed.SelectMany(s => s.Payments).Where(p => p.Method == method && p.Currency == currency).Sum(p => p.AmountMinor);

            return new DailyReportDto(
                day,
                SalesCount: completed.Count,
                VoidedCount: sales.Count - completed.Count,
                TotalUsdCents: completed.Sum(s => s.TotalUsdCents),
                TotalLbp: completed.Sum(s => s.TotalLbp),
                VatLbp: completed.Sum(s => s.VatLbp),
                CashUsdCents: Paid(PaymentMethod.Cash, Currency.USD) - completed.Sum(s => s.ChangeUsdCents),
                CashLbp: Paid(PaymentMethod.Cash, Currency.LBP) - completed.Sum(s => s.ChangeLbp),
                CardUsdCents: Paid(PaymentMethod.Card, Currency.USD),
                CardLbp: Paid(PaymentMethod.Card, Currency.LBP),
                NeedsReviewCount: completed.Count(s => s.ReviewNote is not null));
        }).RequireAuthorization(Policies.ManagerUp);
    }
}
