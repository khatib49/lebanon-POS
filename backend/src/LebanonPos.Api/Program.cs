using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using LebanonPos.Api.Auth;
using LebanonPos.Api.Endpoints;
using LebanonPos.Domain;
using LebanonPos.Domain.Entities;
using LebanonPos.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("ConnectionStrings:Default is not set.");
var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>() ?? new JwtOptions();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CurrentUser>();
builder.Services.AddScoped<ICurrentShop>(sp => sp.GetRequiredService<CurrentUser>());
builder.Services.AddSingleton<TokenService>();
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddPosDatabase(connectionString);
builder.Services.AddOpenApi();
builder.Services.ConfigureHttpJsonOptions(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.MapInboundClaims = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        IssuerSigningKey = jwt.SigningKey(),
        NameClaimType = PosClaims.Name,
        RoleClaimType = PosClaims.Role,
        ClockSkew = TimeSpan.FromMinutes(1),
    };
    // A token stops working as soon as its user is deactivated or changes role.
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var db = context.HttpContext.RequestServices.GetRequiredService<PosDbContext>();
            var id = Guid.TryParse(context.Principal?.FindFirst(PosClaims.UserId)?.Value, out var parsed) ? parsed : Guid.Empty;
            var role = context.Principal?.FindFirst(PosClaims.Role)?.Value;
            var user = await db.Users.IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (user is null || !user.IsActive || user.Role.ToString() != role) context.Fail("User is no longer active.");
        },
    };
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(Policies.ManagerUp, p => p.RequireRole(nameof(UserRole.Manager), nameof(UserRole.Owner)))
    .AddPolicy(Policies.OwnerOnly, p => p.RequireRole(nameof(UserRole.Owner)));

// Slows down password guessing: a few sign-in attempts per minute from one address.
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.AddPolicy("auth", context => RateLimitPartition.GetFixedWindowLimiter(
        context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
        _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = builder.Configuration.GetValue("RateLimit:AuthPerMinute", 10),
            Window = TimeSpan.FromMinutes(1),
        }));
});

var allowedOrigins = builder.Configuration.GetSection("Cors:Origins").Get<string[]>() ?? [];
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Configuration.GetValue("Database:MigrateOnStartup", false))
{
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<PosDbContext>().Database.MigrateAsync();
}

app.UseCors();
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapAuth();
app.MapShop();
app.MapCatalog();
app.MapSales();

app.Run();

public partial class Program;
