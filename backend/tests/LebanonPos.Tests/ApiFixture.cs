using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using LebanonPos.Api.Endpoints;
using LebanonPos.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LebanonPos.Tests;

/// <summary>
/// Runs the real API against a throwaway PostgreSQL database. Set TEST_DB_HOST to point at another
/// server; by default it uses the local development server.
/// </summary>
public class ApiFixture : WebApplicationFactory<Program>, IAsyncLifetime
{
    public static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web) { Converters = { new JsonStringEnumConverter() } };

    private readonly string _database = $"lebpos_test_{Guid.NewGuid():N}";

    private string ConnectionString(string database) =>
        Environment.GetEnvironmentVariable("TEST_DB") is { Length: > 0 } custom
            ? custom.Replace("{db}", database)
            : $"Host=localhost;Database={database};Username=lebpos;Password=lebpos;Pooling=false";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.UseSetting("ConnectionStrings:Default", ConnectionString(_database));
        builder.UseSetting("Jwt:Key", "test-only-signing-key-0123456789-abcdefghij");
        builder.UseSetting("RateLimit:AuthPerMinute", "10000");
    }

    public async Task InitializeAsync()
    {
        using var scope = Services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<PosDbContext>().Database.MigrateAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        using var scope = Services.CreateScope();
        await scope.ServiceProvider.GetRequiredService<PosDbContext>().Database.EnsureDeletedAsync();
    }

    /// <summary>Creates a new shop with its owner and returns a client signed in as that owner.</summary>
    public async Task<(HttpClient Client, AuthResponse Auth)> NewShopAsync(string name = "Test Market")
    {
        var client = CreateClient();
        var email = $"owner-{Guid.NewGuid():N}@example.com";
        var response = await client.PostAsJsonAsync("/api/auth/register-shop", new RegisterShopRequest(name, "Owner", email, "correct-horse-battery"));
        response.EnsureSuccessStatusCode();
        var auth = (await response.Content.ReadFromJsonAsync<AuthResponse>(Json))!;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);
        return (client, auth);
    }

    public async Task<HttpClient> SignInAsync(string email, string password)
    {
        var client = CreateClient();
        var response = await client.PostAsJsonAsync("/api/auth/login", new LoginRequest(email, password));
        response.EnsureSuccessStatusCode();
        var auth = (await response.Content.ReadFromJsonAsync<AuthResponse>(Json))!;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);
        return client;
    }
}
