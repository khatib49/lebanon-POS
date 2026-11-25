using System.Net;
using System.Net.Http.Json;
using LebanonPos.Api.Endpoints;
using LebanonPos.Domain;

namespace LebanonPos.Tests;

public class ApiTests(ApiFixture api) : IClassFixture<ApiFixture>
{
    private const long Rate = 89_500;

    private static async Task<T> Read<T>(HttpResponseMessage response) =>
        (await response.Content.ReadFromJsonAsync<T>(ApiFixture.Json))!;

    private static CreateSaleRequest Sale(int number, long usdCents = 1250, long paidUsdCents = 2000, long changeUsdCents = 700, long changeLbp = 45_000) =>
        new(Guid.NewGuid(), "T1", number, DateTimeOffset.UtcNow, Rate, 1100, true,
            [new SaleLineRequest(null, "Coffee beans", "بن", 1, Currency.USD, usdCents, 0, TaxCategory.Standard)],
            [new SalePaymentRequest(PaymentMethod.Cash, Currency.USD, paidUsdCents)],
            changeUsdCents, changeLbp);

    private static async Task<HttpClient> ShopWithRateAsync(ApiFixture api)
    {
        var (client, _) = await api.NewShopAsync();
        (await client.PostAsJsonAsync("/api/exchange-rates", new SetExchangeRateRequest(Rate))).EnsureSuccessStatusCode();
        return client;
    }

    [Fact]
    public async Task Requests_without_a_token_are_refused()
    {
        var response = await api.CreateClient().GetAsync("/api/products");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Wrong_password_is_refused()
    {
        var (_, auth) = await api.NewShopAsync();

        var response = await api.CreateClient().PostAsJsonAsync("/api/auth/login", new LoginRequest(auth.User.Email, "wrong-password"));

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task New_shop_starts_with_a_till_and_11_percent_vat()
    {
        var (client, _) = await api.NewShopAsync();

        var registers = await client.GetFromJsonAsync<List<RegisterDto>>("/api/registers", ApiFixture.Json);
        var vat = await client.GetFromJsonAsync<List<VatRateDto>>("/api/vat-rates", ApiFixture.Json);

        Assert.Equal("T1", Assert.Single(registers!).Code);
        Assert.Equal(1100, Assert.Single(vat!).RateBps);
    }

    [Fact]
    public async Task One_shop_cannot_see_another_shops_products()
    {
        var (first, _) = await api.NewShopAsync("First");
        var (second, _) = await api.NewShopAsync("Second");
        var created = await Read<ProductDto>(await first.PostAsJsonAsync("/api/products",
            new SaveProductRequest(null, "Labneh", "لبنة", "111", Currency.LBP, 250_000, TaxCategory.Exempt)));

        var seenBySecond = await second.GetFromJsonAsync<List<ProductDto>>("/api/products", ApiFixture.Json);
        var update = await second.PutAsJsonAsync($"/api/products/{created.Id}",
            new SaveProductRequest(null, "Hacked", null, null, Currency.USD, 1, TaxCategory.Standard));

        Assert.Empty(seenBySecond!);
        Assert.Equal(HttpStatusCode.NotFound, update.StatusCode);
    }

    [Fact]
    public async Task Cashier_cannot_change_the_rate_or_prices_or_cancel_a_sale()
    {
        var owner = await ShopWithRateAsync(api);
        var email = $"cashier-{Guid.NewGuid():N}@example.com";
        (await owner.PostAsJsonAsync("/api/users", new CreateUserRequest("Maya", email, "cashier-password", UserRole.Cashier))).EnsureSuccessStatusCode();
        var cashier = await api.SignInAsync(email, "cashier-password");
        var sale = Sale(1);
        (await cashier.PostAsJsonAsync("/api/sales", sale)).EnsureSuccessStatusCode();

        var rate = await cashier.PostAsJsonAsync("/api/exchange-rates", new SetExchangeRateRequest(90_000));
        var product = await cashier.PostAsJsonAsync("/api/products", new SaveProductRequest(null, "Gum", null, null, Currency.USD, 50, TaxCategory.Standard));
        var cancel = await cashier.PostAsJsonAsync($"/api/sales/{sale.Id}/void", new VoidSaleRequest("mistake"));

        Assert.Equal(HttpStatusCode.Forbidden, rate.StatusCode);
        Assert.Equal(HttpStatusCode.Forbidden, product.StatusCode);
        Assert.Equal(HttpStatusCode.Forbidden, cancel.StatusCode);
    }

    [Fact]
    public async Task Deactivated_user_loses_access_immediately()
    {
        var (owner, _) = await api.NewShopAsync();
        var email = $"cashier-{Guid.NewGuid():N}@example.com";
        var user = await Read<UserDto>(await owner.PostAsJsonAsync("/api/users", new CreateUserRequest("Sami", email, "cashier-password", UserRole.Cashier)));
        var cashier = await api.SignInAsync(email, "cashier-password");

        (await owner.PatchAsJsonAsync($"/api/users/{user.Id}", new UpdateUserRequest(null, null, false, null))).EnsureSuccessStatusCode();
        var response = await cashier.GetAsync("/api/products");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Shop_must_keep_one_active_owner()
    {
        var (owner, auth) = await api.NewShopAsync();

        var response = await owner.PatchAsJsonAsync($"/api/users/{auth.User.Id}", new UpdateUserRequest(null, UserRole.Cashier, null, null));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Sale_is_stored_with_totals_in_both_currencies()
    {
        var client = await ShopWithRateAsync(api);

        var response = await client.PostAsJsonAsync("/api/sales", Sale(1));
        var sale = await Read<SaleDto>(response);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.Equal("T1-000001", sale.InvoiceNumber);
        Assert.Equal(1250, sale.TotalUsdCents);
        Assert.Equal(1_118_750, sale.TotalLbp);
        Assert.Equal(124, sale.VatUsdCents);
        Assert.Null(sale.ReviewNote);
    }

    [Fact]
    public async Task Same_sale_sent_twice_is_stored_once()
    {
        var client = await ShopWithRateAsync(api);
        var request = Sale(1);

        var first = await client.PostAsJsonAsync("/api/sales", request);
        var second = await client.PostAsJsonAsync("/api/sales", request);
        var all = await client.GetFromJsonAsync<List<SaleDto>>("/api/sales", ApiFixture.Json);

        Assert.Equal(HttpStatusCode.Created, first.StatusCode);
        Assert.Equal(HttpStatusCode.OK, second.StatusCode);
        Assert.Single(all!);
    }

    [Fact]
    public async Task Invoice_number_cannot_be_reused_by_a_different_sale()
    {
        var client = await ShopWithRateAsync(api);
        (await client.PostAsJsonAsync("/api/sales", Sale(1))).EnsureSuccessStatusCode();

        var response = await client.PostAsJsonAsync("/api/sales", Sale(1));

        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
    }

    [Fact]
    public async Task Underpaid_offline_sale_is_kept_and_flagged_for_review()
    {
        var client = await ShopWithRateAsync(api);

        var sale = await Read<SaleDto>(await client.PostAsJsonAsync("/api/sales", Sale(1, paidUsdCents: 1000, changeUsdCents: 0, changeLbp: 0)));

        Assert.Contains("short", sale.ReviewNote);
    }

    [Fact]
    public async Task Cancelling_a_sale_needs_a_reason_and_is_audited()
    {
        var client = await ShopWithRateAsync(api);
        var request = Sale(1);
        (await client.PostAsJsonAsync("/api/sales", request)).EnsureSuccessStatusCode();

        var noReason = await client.PostAsJsonAsync($"/api/sales/{request.Id}/void", new VoidSaleRequest(" "));
        var cancelled = await Read<SaleDto>(await client.PostAsJsonAsync($"/api/sales/{request.Id}/void", new VoidSaleRequest("Customer changed mind")));
        var audit = await client.GetFromJsonAsync<List<AuditDto>>("/api/audit", ApiFixture.Json);

        Assert.Equal(HttpStatusCode.BadRequest, noReason.StatusCode);
        Assert.Equal(SaleStatus.Voided, cancelled.Status);
        Assert.Contains(audit!, a => a.Action == "sale.voided" && a.EntityId == request.Id.ToString());
    }

    [Fact]
    public async Task Daily_report_counts_cash_in_each_currency_and_skips_cancelled_sales()
    {
        var client = await ShopWithRateAsync(api);
        (await client.PostAsJsonAsync("/api/sales", Sale(1))).EnsureSuccessStatusCode();
        var cancelled = Sale(2);
        (await client.PostAsJsonAsync("/api/sales", cancelled)).EnsureSuccessStatusCode();
        (await client.PostAsJsonAsync($"/api/sales/{cancelled.Id}/void", new VoidSaleRequest("Test"))).EnsureSuccessStatusCode();

        var report = await client.GetFromJsonAsync<DailyReportDto>("/api/reports/daily", ApiFixture.Json);

        Assert.Equal(1, report!.SalesCount);
        Assert.Equal(1, report.VoidedCount);
        Assert.Equal(1250, report.TotalUsdCents);
        Assert.Equal(1300, report.CashUsdCents);
        Assert.Equal(-45_000, report.CashLbp);
    }

    [Fact]
    public async Task Price_change_is_recorded_in_the_audit_log()
    {
        var (client, _) = await api.NewShopAsync();
        var product = await Read<ProductDto>(await client.PostAsJsonAsync("/api/products",
            new SaveProductRequest(null, "Olive oil", null, "222", Currency.USD, 900, TaxCategory.Exempt)));

        (await client.PutAsJsonAsync($"/api/products/{product.Id}",
            new SaveProductRequest(null, "Olive oil", null, "222", Currency.USD, 950, TaxCategory.Exempt))).EnsureSuccessStatusCode();
        var audit = await client.GetFromJsonAsync<List<AuditDto>>("/api/audit", ApiFixture.Json);

        Assert.Contains(audit!, a => a.Action == "product.price_changed" && a.EntityId == product.Id.ToString());
    }
}
