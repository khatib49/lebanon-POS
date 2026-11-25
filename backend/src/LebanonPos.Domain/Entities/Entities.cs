namespace LebanonPos.Domain.Entities;

public interface IShopOwned
{
    Guid ShopId { get; set; }
}

public class Shop
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public required string Name { get; set; }
    public string? NameAr { get; set; }
    public string? VatNumber { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? ReceiptFooter { get; set; }
    public string DefaultLanguage { get; set; } = "ar";
    /// <summary>Shelf prices already contain VAT (the norm in Lebanese retail).</summary>
    public bool PricesIncludeVat { get; set; } = true;
    /// <summary>Smallest lira amount handled in cash; change is rounded to it.</summary>
    public long LbpCashUnit { get; set; } = 1000;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public class User : IShopOwned
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ShopId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string PasswordHash { get; set; } = "";
    public UserRole Role { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public class Register : IShopOwned
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ShopId { get; set; }
    /// <summary>Short code printed in invoice numbers, for example "T1".</summary>
    public required string Code { get; set; }
    public required string Name { get; set; }
    public bool IsActive { get; set; } = true;
}

public class ExchangeRate : IShopOwned
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ShopId { get; set; }
    public long LbpPerUsd { get; set; }
    public DateTimeOffset EffectiveFrom { get; set; }
    public Guid SetByUserId { get; set; }
}

/// <summary>A VAT rate with the date it starts, so a change in the law is a new row, not a code change.</summary>
public class VatRate : IShopOwned
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ShopId { get; set; }
    /// <summary>Rate in basis points: 1100 = 11%.</summary>
    public int RateBps { get; set; }
    public DateOnly EffectiveFrom { get; set; }
}

public class Category : IShopOwned
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ShopId { get; set; }
    public required string Name { get; set; }
    public string? NameAr { get; set; }
    public int SortOrder { get; set; }
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public class Product : IShopOwned
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ShopId { get; set; }
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public required string Name { get; set; }
    public string? NameAr { get; set; }
    public string? Barcode { get; set; }
    public Currency PriceCurrency { get; set; } = Currency.USD;
    public long PriceMinor { get; set; }
    public TaxCategory TaxCategory { get; set; } = TaxCategory.Standard;
    public bool IsActive { get; set; } = true;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}

/// <summary>
/// A sale is never deleted or edited: it can only be voided, with a reason. Its id is created on the
/// device, so a sale made offline and sent twice is stored once.
/// </summary>
public class Sale : IShopOwned
{
    public Guid Id { get; set; }
    public Guid ShopId { get; set; }
    public required string RegisterCode { get; set; }
    /// <summary>Invoice number within the register, counted on the device with no gaps.</summary>
    public int Number { get; set; }
    public Guid CashierId { get; set; }
    public DateTimeOffset SoldAt { get; set; }
    public DateTimeOffset ReceivedAt { get; set; } = DateTimeOffset.UtcNow;

    public long LbpPerUsd { get; set; }
    public int VatRateBps { get; set; }
    public bool PricesIncludeVat { get; set; }

    public long TotalUsdCents { get; set; }
    public long TotalLbp { get; set; }
    public long VatUsdCents { get; set; }
    public long VatLbp { get; set; }
    public long ChangeUsdCents { get; set; }
    public long ChangeLbp { get; set; }

    public SaleStatus Status { get; set; } = SaleStatus.Completed;
    public DateTimeOffset? VoidedAt { get; set; }
    public Guid? VoidedByUserId { get; set; }
    public string? VoidReason { get; set; }
    /// <summary>Set when the numbers sent by the device do not add up; the sale is kept and flagged for the owner.</summary>
    public string? ReviewNote { get; set; }

    public List<SaleLine> Lines { get; set; } = [];
    public List<SalePayment> Payments { get; set; } = [];
}

public class SaleLine
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid SaleId { get; set; }
    public Guid? ProductId { get; set; }
    public required string Name { get; set; }
    public string? NameAr { get; set; }
    public decimal Quantity { get; set; }
    public Currency PriceCurrency { get; set; }
    public long UnitPriceMinor { get; set; }
    public long DiscountMinor { get; set; }
    public TaxCategory TaxCategory { get; set; }
    public long LineTotalMinor { get; set; }
    public long VatMinor { get; set; }
}

public class SalePayment
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid SaleId { get; set; }
    public PaymentMethod Method { get; set; }
    public Currency Currency { get; set; }
    public long AmountMinor { get; set; }
}

/// <summary>Append-only record of sensitive actions (rate changes, price changes, voids, user changes).</summary>
public class AuditEntry : IShopOwned
{
    public long Id { get; set; }
    public Guid ShopId { get; set; }
    public Guid? UserId { get; set; }
    public required string Action { get; set; }
    public string? EntityType { get; set; }
    public string? EntityId { get; set; }
    public string? Details { get; set; }
    public DateTimeOffset At { get; set; } = DateTimeOffset.UtcNow;
}
