using LebanonPos.Domain;
using LebanonPos.Domain.Money;

namespace LebanonPos.Tests;

public class MoneyTests
{
    private const long Rate = 89_500;
    private const int Vat = 1100;

    private static SaleLineInput Usd(long cents, decimal qty = 1, TaxCategory tax = TaxCategory.Standard, long discount = 0) =>
        new(Currency.USD, cents, qty, discount, tax);

    private static SaleLineInput Lbp(long pounds, decimal qty = 1, TaxCategory tax = TaxCategory.Standard) =>
        new(Currency.LBP, pounds, qty, 0, tax);

    [Fact]
    public void Dollar_sale_shows_the_lira_total_at_the_sale_rate()
    {
        var totals = SaleCalculator.Calculate([Usd(1250)], Rate, Vat, pricesIncludeVat: true);

        Assert.Equal(1250, totals.TotalUsdCents);
        Assert.Equal(1_118_750, totals.TotalLbp);
    }

    [Fact]
    public void Vat_is_taken_out_of_a_vat_inclusive_price()
    {
        var totals = SaleCalculator.Calculate([Usd(1110)], Rate, Vat, pricesIncludeVat: true);

        Assert.Equal(1110, totals.TotalUsdCents);
        Assert.Equal(110, totals.VatUsdCents);
        Assert.Equal(98_450, totals.VatLbp);
    }

    [Fact]
    public void Vat_is_added_on_top_of_a_vat_exclusive_price()
    {
        var totals = SaleCalculator.Calculate([Usd(1000)], Rate, Vat, pricesIncludeVat: false);

        Assert.Equal(1110, totals.TotalUsdCents);
        Assert.Equal(110, totals.VatUsdCents);
    }

    [Fact]
    public void Exempt_products_carry_no_vat()
    {
        var totals = SaleCalculator.Calculate([Usd(500, tax: TaxCategory.Exempt), Usd(1110)], Rate, Vat, pricesIncludeVat: true);

        Assert.Equal(1610, totals.TotalUsdCents);
        Assert.Equal(110, totals.VatUsdCents);
    }

    [Fact]
    public void Lira_only_sale_keeps_its_exact_lira_total()
    {
        var totals = SaleCalculator.Calculate([Lbp(150_000), Lbp(75_000, qty: 2)], Rate, Vat, pricesIncludeVat: true);

        Assert.Equal(300_000, totals.TotalLbp);
        Assert.Equal(335, totals.TotalUsdCents);
    }

    [Fact]
    public void Mixed_currency_lines_are_totalled_in_both_currencies()
    {
        var totals = SaleCalculator.Calculate([Usd(1000), Lbp(89_500)], Rate, Vat, pricesIncludeVat: true);

        Assert.Equal(1100, totals.TotalUsdCents);
        Assert.Equal(984_500, totals.TotalLbp);
    }

    [Fact]
    public void Weighed_quantity_and_discount_are_applied_per_line()
    {
        var totals = SaleCalculator.Calculate([Usd(800, qty: 1.25m, tax: TaxCategory.Exempt, discount: 100)], Rate, Vat, pricesIncludeVat: true);

        Assert.Equal(900, totals.TotalUsdCents);
    }

    [Fact]
    public void Discount_larger_than_the_line_is_rejected()
    {
        Assert.Throws<ArgumentException>(() =>
            SaleCalculator.Calculate([Usd(500, discount: 600)], Rate, Vat, pricesIncludeVat: true));
    }

    [Fact]
    public void Change_is_whole_dollars_plus_rounded_lira()
    {
        // $12.50 paid with a $20 note: $7 back in dollars and 50 cents back in lira.
        var result = ChangeCalculator.Calculate(12.50m, [new(Currency.USD, 2000)], Rate, lbpCashUnit: 1000);

        Assert.True(result.IsPaid);
        Assert.Equal(700, result.ChangeUsdCents);
        Assert.Equal(45_000, result.ChangeLbp);
    }

    [Fact]
    public void Customer_can_pay_in_dollars_and_lira_together()
    {
        // $12.50 total: $10 note plus 250,000 LBP (about $2.79) leaves about 26,000 LBP change.
        var result = ChangeCalculator.Calculate(12.50m, [new(Currency.USD, 1000), new(Currency.LBP, 250_000)], Rate, lbpCashUnit: 1000);

        Assert.True(result.IsPaid);
        Assert.Equal(0, result.ChangeUsdCents);
        Assert.Equal(26_000, result.ChangeLbp);
    }

    [Fact]
    public void Short_payment_reports_what_is_still_owed_in_both_currencies()
    {
        var result = ChangeCalculator.Calculate(12.50m, [new(Currency.USD, 1000)], Rate, lbpCashUnit: 1000);

        Assert.False(result.IsPaid);
        Assert.Equal(250, result.RemainingUsdCents);
        Assert.Equal(224_000, result.RemainingLbp);
    }

    [Fact]
    public void Paying_the_rounded_lira_total_counts_as_paid()
    {
        // $3.35 is 299,825 LBP; the customer hands over 300,000.
        var result = ChangeCalculator.Calculate(3.35m, [new(Currency.LBP, 300_000)], Rate, lbpCashUnit: 1000);

        Assert.True(result.IsPaid);
        Assert.Equal(0, result.ChangeLbp);
    }
}
