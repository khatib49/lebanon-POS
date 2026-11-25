namespace LebanonPos.Domain.Money;

public sealed record PaymentInput(Currency Currency, long AmountMinor);

/// <param name="RemainingUsdCents">Still owed, in dollars (0 when fully paid).</param>
/// <param name="RemainingLbp">Still owed, in lira (0 when fully paid).</param>
/// <param name="ChangeUsdCents">Suggested change in whole dollars.</param>
/// <param name="ChangeLbp">Suggested change in lira, rounded to the cash unit.</param>
public sealed record PaymentResult(
    bool IsPaid,
    long RemainingUsdCents,
    long RemainingLbp,
    long ChangeUsdCents,
    long ChangeLbp);

/// <summary>
/// Works out what is still owed or what change to give when a customer pays in dollars,
/// lira or both. US coins do not circulate in Lebanon, so change is suggested as whole
/// dollars plus lira rounded to the shop's cash unit.
/// </summary>
public static class ChangeCalculator
{
    public static PaymentResult Calculate(
        decimal totalUsdExact,
        IReadOnlyList<PaymentInput> payments,
        long lbpPerUsd,
        long lbpCashUnit)
    {
        if (lbpPerUsd <= 0) throw new ArgumentOutOfRangeException(nameof(lbpPerUsd));

        var paid = payments.Sum(p => MoneyMath.ToUsd(p.Currency, p.AmountMinor, lbpPerUsd));
        var difference = paid - totalUsdExact;
        var tolerance = Tolerance(lbpPerUsd, lbpCashUnit);

        if (difference < -tolerance)
        {
            var remaining = -difference;
            return new PaymentResult(
                IsPaid: false,
                RemainingUsdCents: (long)Math.Ceiling(remaining * 100m),
                RemainingLbp: MoneyMath.RoundLbpToUnit(remaining * lbpPerUsd, lbpCashUnit),
                ChangeUsdCents: 0,
                ChangeLbp: 0);
        }

        if (difference <= tolerance) return new PaymentResult(true, 0, 0, 0, 0);

        var wholeDollars = Math.Floor(difference);
        var lbpChange = MoneyMath.RoundLbpToUnit((difference - wholeDollars) * lbpPerUsd, lbpCashUnit);
        return new PaymentResult(true, 0, 0, (long)wholeDollars * 100, lbpChange);
    }

    /// <summary>Half a cash unit, in dollars: differences this small are rounding, not money owed.</summary>
    public static decimal Tolerance(long lbpPerUsd, long lbpCashUnit) =>
        Math.Max(0.005m, Math.Max(lbpCashUnit, 1) / 2m / lbpPerUsd);
}
