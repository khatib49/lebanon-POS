namespace LebanonPos.Domain.Money;

/// <summary>
/// Money is stored as whole numbers: USD in cents, LBP in pounds.
/// The exchange rate is whole LBP per 1 USD (for example 89500).
/// </summary>
public static class MoneyMath
{
    public static long Round(decimal value) => (long)Math.Round(value, 0, MidpointRounding.AwayFromZero);

    public static long UsdCentsToLbp(long usdCents, long lbpPerUsd) => Round(usdCents * (decimal)lbpPerUsd / 100m);

    public static long LbpToUsdCents(long lbp, long lbpPerUsd) => Round(lbp * 100m / lbpPerUsd);

    /// <summary>Value of an amount in dollars (with fractions), used only to compare and subtract mixed-currency amounts.</summary>
    public static decimal ToUsd(Currency currency, long minor, long lbpPerUsd) =>
        currency == Currency.USD ? minor / 100m : minor / (decimal)lbpPerUsd;

    /// <summary>Rounds an LBP amount to the nearest cash unit (for example 1,000 LBP).</summary>
    public static long RoundLbpToUnit(decimal lbp, long unit)
    {
        if (unit <= 1) return Round(lbp);
        return Round(lbp / unit) * unit;
    }
}
