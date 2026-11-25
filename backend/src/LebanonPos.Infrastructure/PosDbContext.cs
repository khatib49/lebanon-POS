using LebanonPos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LebanonPos.Infrastructure;

/// <summary>Tells the database layer which shop the current request belongs to.</summary>
public interface ICurrentShop
{
    Guid? ShopId { get; }
}

public class PosDbContext(DbContextOptions<PosDbContext> options, ICurrentShop currentShop) : DbContext(options)
{
    private Guid? CurrentShopId => currentShop.ShopId;

    public DbSet<Shop> Shops => Set<Shop>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Register> Registers => Set<Register>();
    public DbSet<ExchangeRate> ExchangeRates => Set<ExchangeRate>();
    public DbSet<VatRate> VatRates => Set<VatRate>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleLine> SaleLines => Set<SaleLine>();
    public DbSet<SalePayment> SalePayments => Set<SalePayment>();
    public DbSet<AuditEntry> AuditEntries => Set<AuditEntry>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        // Every shop-owned table is filtered to the signed-in user's shop, so one shop can never read another's data.
        b.Entity<User>().HasQueryFilter(e => e.ShopId == CurrentShopId);
        b.Entity<Register>().HasQueryFilter(e => e.ShopId == CurrentShopId);
        b.Entity<ExchangeRate>().HasQueryFilter(e => e.ShopId == CurrentShopId);
        b.Entity<VatRate>().HasQueryFilter(e => e.ShopId == CurrentShopId);
        b.Entity<Category>().HasQueryFilter(e => e.ShopId == CurrentShopId);
        b.Entity<Product>().HasQueryFilter(e => e.ShopId == CurrentShopId);
        b.Entity<Sale>().HasQueryFilter(e => e.ShopId == CurrentShopId);
        b.Entity<AuditEntry>().HasQueryFilter(e => e.ShopId == CurrentShopId);

        b.Entity<Shop>(e =>
        {
            e.Property(x => x.Name).HasMaxLength(200);
            e.Property(x => x.NameAr).HasMaxLength(200);
            e.Property(x => x.VatNumber).HasMaxLength(50);
            e.Property(x => x.Address).HasMaxLength(500);
            e.Property(x => x.Phone).HasMaxLength(50);
            e.Property(x => x.ReceiptFooter).HasMaxLength(500);
            e.Property(x => x.DefaultLanguage).HasMaxLength(5);
        });

        b.Entity<User>(e =>
        {
            e.Property(x => x.Name).HasMaxLength(200);
            e.Property(x => x.Email).HasMaxLength(320);
            e.HasIndex(x => x.Email).IsUnique();
            e.Property(x => x.Role).HasConversion<string>().HasMaxLength(20);
            e.HasOne<Shop>().WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<Register>(e =>
        {
            e.Property(x => x.Code).HasMaxLength(10);
            e.Property(x => x.Name).HasMaxLength(100);
            e.HasIndex(x => new { x.ShopId, x.Code }).IsUnique();
            e.HasOne<Shop>().WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<ExchangeRate>(e =>
        {
            e.HasIndex(x => new { x.ShopId, x.EffectiveFrom });
            e.HasOne<Shop>().WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<VatRate>(e =>
        {
            e.HasIndex(x => new { x.ShopId, x.EffectiveFrom }).IsUnique();
            e.HasOne<Shop>().WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<Category>(e =>
        {
            e.Property(x => x.Name).HasMaxLength(200);
            e.Property(x => x.NameAr).HasMaxLength(200);
            e.HasOne<Shop>().WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<Product>(e =>
        {
            e.Property(x => x.Name).HasMaxLength(300);
            e.Property(x => x.NameAr).HasMaxLength(300);
            e.Property(x => x.Barcode).HasMaxLength(64);
            e.Property(x => x.PriceCurrency).HasConversion<string>().HasMaxLength(3);
            e.Property(x => x.TaxCategory).HasConversion<string>().HasMaxLength(20);
            e.HasIndex(x => new { x.ShopId, x.Barcode }).IsUnique().HasFilter("barcode is not null");
            e.HasIndex(x => new { x.ShopId, x.UpdatedAt });
            e.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.SetNull);
            e.HasOne<Shop>().WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<Sale>(e =>
        {
            e.Property(x => x.Id).ValueGeneratedNever();
            e.Property(x => x.RegisterCode).HasMaxLength(10);
            e.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
            e.Property(x => x.VoidReason).HasMaxLength(500);
            e.Property(x => x.ReviewNote).HasMaxLength(1000);
            e.HasIndex(x => new { x.ShopId, x.RegisterCode, x.Number }).IsUnique();
            e.HasIndex(x => new { x.ShopId, x.SoldAt });
            e.HasMany(x => x.Lines).WithOne().HasForeignKey(x => x.SaleId).OnDelete(DeleteBehavior.Restrict);
            e.HasMany(x => x.Payments).WithOne().HasForeignKey(x => x.SaleId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne<Shop>().WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne<User>().WithMany().HasForeignKey(x => x.CashierId).OnDelete(DeleteBehavior.Restrict);
        });

        b.Entity<SaleLine>(e =>
        {
            e.Property(x => x.Name).HasMaxLength(300);
            e.Property(x => x.NameAr).HasMaxLength(300);
            e.Property(x => x.Quantity).HasPrecision(12, 3);
            e.Property(x => x.PriceCurrency).HasConversion<string>().HasMaxLength(3);
            e.Property(x => x.TaxCategory).HasConversion<string>().HasMaxLength(20);
        });

        b.Entity<SalePayment>(e =>
        {
            e.Property(x => x.Method).HasConversion<string>().HasMaxLength(20);
            e.Property(x => x.Currency).HasConversion<string>().HasMaxLength(3);
        });

        b.Entity<AuditEntry>(e =>
        {
            e.Property(x => x.Action).HasMaxLength(100);
            e.Property(x => x.EntityType).HasMaxLength(100);
            e.Property(x => x.EntityId).HasMaxLength(100);
            e.Property(x => x.Details).HasColumnType("jsonb");
            e.HasIndex(x => new { x.ShopId, x.At });
        });
    }
}
