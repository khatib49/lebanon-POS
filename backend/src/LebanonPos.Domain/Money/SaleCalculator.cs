namespace LebanonPos.Domain.Money;

public sealed record SaleLineInput(
    Currency PriceCurrency,
    long UnitPriceMinor,
    decimal Quantity,
    long DiscountMinor,
    TaxCategory TaxCategory);

public sealed record SaleLineResult(long LineTotalMinor, long VatMinor);

public sealed record SaleTotals(
    IReadOnlyList<SaleLineResult> Lines,
    long UsdPartCents,
    long LbpPart,
    long TotalUsdCents,
    long TotalLbp,
    long VatUsdCents,
    long VatLbp)
{
    /// <summary>Exact total in dollars, used to compare with mixed-currency payments.</summary>
    public decimal TotalUsdExact(long lbpPerUsd) => UsdPartCents / 100m + LbpPart / (decimal)lbpPerUsd;
}

/// <summary>
/// Calculates a sale. Each line is totalled in its own price currency, so a shop that prices
/// only in dollars (or only in lira) never sees conversion rounding in its totals. The sale
/// then carries the full total in both currencies at the sale's exchange rate.
/// </summary>
public static class SaleCalculator
{
    public const int BasisPoints = 10_000;

    public static SaleTotals Calculate(
        IReadOnlyList<SaleLineInput> lines,
        long lbpPerUsd,
        int vatRateBps,
        bool pricesIncludeVat)
    {
        if (lbpPerUsd <= 0) throw new ArgumentOutOfRangeException(nameof(lbpPerUsd));
        if (vatRateBps < 0) throw new ArgumentOutOfRangeException(nameof(vatRateBps));

        var results = new List<SaleLineResult>(lines.Count);
        long usdPart = 0, lbpPart = 0, vatUsd = 0, vatLbp = 0;

        foreach (var line in lines)
        {
            if (line.Quantity <= 0) throw new ArgumentException("Quantity must be positive.", nameof(lines));
            if (line.UnitPriceMinor < 0) throw new ArgumentException("Price cannot be negative.", nameof(lines));
            if (line.DiscountMinor < 0) throw new ArgumentException("Discount cannot be negative.", nameof(lines));

            var beforeDiscount = MoneyMath.Round(line.UnitPriceMinor * line.Quantity);
            if (line.DiscountMinor > beforeDiscount) throw new ArgumentException("Discount is larger than the line.", nameof(lines));
            var amount = beforeDiscount - line.DiscountMinor;

            long vat = 0, total = amount;
            if (line.TaxCategory == TaxCategory.Standard && vatRateBps > 0)
            {
                if (pricesIncludeVat)
                {
                    vat = MoneyMath.Round(amount * (decimal)vatRateBps / (BasisPoints + vatRateBps));
                }
                else
                {
                    vat = MoneyMath.Round(amount * (decimal)vatRateBps / BasisPoints);
                    total = amount + vat;
                }
            }

            results.Add(new SaleLineResult(total, vat));
            if (line.PriceCurrency == Currency.USD) { usdPart += total; vatUsd += vat; }
            else { lbpPart += total; vatLbp += vat; }
        }

        return new SaleTotals(
            results,
            usdPart,
            lbpPart,
            TotalUsdCents: usdPart + MoneyMath.LbpToUsdCents(lbpPart, lbpPerUsd),
            TotalLbp: MoneyMath.UsdCentsToLbp(usdPart, lbpPerUsd) + lbpPart,
            VatUsdCents: vatUsd + MoneyMath.LbpToUsdCents(vatLbp, lbpPerUsd),
            VatLbp: MoneyMath.UsdCentsToLbp(vatUsd, lbpPerUsd) + vatLbp);
    }
}
