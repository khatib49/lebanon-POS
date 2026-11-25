using LebanonPos.Api.Auth;
using LebanonPos.Domain;
using LebanonPos.Domain.Entities;
using LebanonPos.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LebanonPos.Api.Endpoints;

public record CategoryDto(Guid Id, string Name, string? NameAr, int SortOrder);
public record SaveCategoryRequest(string Name, string? NameAr, int SortOrder);
public record ProductDto(Guid Id, Guid? CategoryId, string Name, string? NameAr, string? Barcode,
    Currency PriceCurrency, long PriceMinor, TaxCategory TaxCategory, bool IsActive, DateTimeOffset UpdatedAt);
public record SaveProductRequest(Guid? CategoryId, string Name, string? NameAr, string? Barcode,
    Currency PriceCurrency, long PriceMinor, TaxCategory TaxCategory, bool IsActive = true);

public static class CatalogEndpoints
{
    private static CategoryDto ToDto(Category c) => new(c.Id, c.Name, c.NameAr, c.SortOrder);

    private static ProductDto ToDto(Product p) => new(p.Id, p.CategoryId, p.Name, p.NameAr, p.Barcode,
        p.PriceCurrency, p.PriceMinor, p.TaxCategory, p.IsActive, p.UpdatedAt);

    private static async Task<IResult?> ValidateAsync(SaveProductRequest req, PosDbContext db, Guid? existingId)
    {
        if (Common.Clean(req.Name) is null) return Common.Invalid("name", "Product name is required.");
        if (!Enum.IsDefined(req.PriceCurrency)) return Common.Invalid("priceCurrency", "Currency must be USD or LBP.");
        if (!Enum.IsDefined(req.TaxCategory)) return Common.Invalid("taxCategory", "Unknown tax category.");
        if (req.PriceMinor < 0) return Common.Invalid("priceMinor", "Price cannot be negative.");
        if (req.CategoryId is { } categoryId && !await db.Categories.AnyAsync(c => c.Id == categoryId))
            return Common.Invalid("categoryId", "Category not found.");
        if (Common.Clean(req.Barcode) is { } barcode && await db.Products.AnyAsync(p => p.Barcode == barcode && p.Id != existingId))
            return Common.Invalid("barcode", "Another product already uses this barcode.");
        return null;
    }

    private static void Apply(Product p, SaveProductRequest req)
    {
        p.CategoryId = req.CategoryId;
        p.Name = req.Name.Trim();
        p.NameAr = Common.Clean(req.NameAr);
        p.Barcode = Common.Clean(req.Barcode);
        p.PriceCurrency = req.PriceCurrency;
        p.PriceMinor = req.PriceMinor;
        p.TaxCategory = req.TaxCategory;
        p.IsActive = req.IsActive;
        p.UpdatedAt = DateTimeOffset.UtcNow;
    }

    public static void MapCatalog(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api").RequireAuthorization();

        api.MapGet("/categories", async (PosDbContext db) =>
            (await db.Categories.OrderBy(c => c.SortOrder).ThenBy(c => c.Name).ToListAsync()).Select(ToDto));

        api.MapPost("/categories", async (SaveCategoryRequest req, PosDbContext db, CurrentUser current) =>
        {
            if (Common.Clean(req.Name) is not { } name) return Common.Invalid("name", "Category name is required.");
            var category = new Category { ShopId = current.RequiredShopId, Name = name, NameAr = Common.Clean(req.NameAr), SortOrder = req.SortOrder };
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return Results.Created($"/api/categories/{category.Id}", ToDto(category));
        }).RequireAuthorization(Policies.ManagerUp);

        api.MapPut("/categories/{id:guid}", async (Guid id, SaveCategoryRequest req, PosDbContext db) =>
        {
            if (Common.Clean(req.Name) is not { } name) return Common.Invalid("name", "Category name is required.");
            var category = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null) return Results.NotFound();
            category.Name = name;
            category.NameAr = Common.Clean(req.NameAr);
            category.SortOrder = req.SortOrder;
            category.UpdatedAt = DateTimeOffset.UtcNow;
            await db.SaveChangesAsync();
            return Results.Ok(ToDto(category));
        }).RequireAuthorization(Policies.ManagerUp);

        // "updatedSince" lets a till download only what changed since its last sync.
        api.MapGet("/products", async (PosDbContext db, DateTimeOffset? updatedSince, bool? includeInactive) =>
        {
            var query = db.Products.AsQueryable();
            if (updatedSince is { } since) query = query.Where(p => p.UpdatedAt > since);
            else if (includeInactive != true) query = query.Where(p => p.IsActive);
            return (await query.OrderBy(p => p.Name).ToListAsync()).Select(ToDto);
        });

        api.MapPost("/products", async (SaveProductRequest req, PosDbContext db, CurrentUser current) =>
        {
            if (await ValidateAsync(req, db, null) is { } problem) return problem;
            var product = new Product { ShopId = current.RequiredShopId, Name = req.Name };
            Apply(product, req);
            db.Products.Add(product);
            db.Audit(current, "product.created", nameof(Product), product.Id, new { product.Name, product.PriceCurrency, product.PriceMinor });
            await db.SaveChangesAsync();
            return Results.Created($"/api/products/{product.Id}", ToDto(product));
        }).RequireAuthorization(Policies.ManagerUp);

        api.MapPut("/products/{id:guid}", async (Guid id, SaveProductRequest req, PosDbContext db, CurrentUser current) =>
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return Results.NotFound();
            if (await ValidateAsync(req, db, id) is { } problem) return problem;

            var priceChanged = product.PriceMinor != req.PriceMinor || product.PriceCurrency != req.PriceCurrency;
            if (priceChanged)
                db.Audit(current, "product.price_changed", nameof(Product), product.Id, new
                {
                    From = new { product.PriceCurrency, product.PriceMinor },
                    To = new { req.PriceCurrency, req.PriceMinor },
                });
            Apply(product, req);
            await db.SaveChangesAsync();
            return Results.Ok(ToDto(product));
        }).RequireAuthorization(Policies.ManagerUp);
    }
}
