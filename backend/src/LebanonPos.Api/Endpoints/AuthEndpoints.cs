using LebanonPos.Api.Auth;
using LebanonPos.Domain;
using LebanonPos.Domain.Entities;
using LebanonPos.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LebanonPos.Api.Endpoints;

public record RegisterShopRequest(string ShopName, string OwnerName, string Email, string Password);
public record LoginRequest(string Email, string Password);
public record UserDto(Guid Id, string Name, string Email, UserRole Role, bool IsActive);
public record AuthResponse(string Token, DateTimeOffset ExpiresAt, UserDto User, Guid ShopId);
public record CreateUserRequest(string Name, string Email, string Password, UserRole Role);
public record UpdateUserRequest(string? Name, UserRole? Role, bool? IsActive, string? Password);

public static class AuthEndpoints
{
    public const int MinPasswordLength = 8;
    /// <summary>VAT has been 11% since 2018; a later change is added as a new dated rate.</summary>
    private static readonly DateOnly VatStart = new(2018, 1, 1);
    private const int DefaultVatBps = 1100;

    public static UserDto ToDto(this User u) => new(u.Id, u.Name, u.Email, u.Role, u.IsActive);

    public static string NormalizeEmail(string email) => email.Trim().ToLowerInvariant();

    public static void MapAuth(this IEndpointRouteBuilder app)
    {
        var auth = app.MapGroup("/api/auth").RequireRateLimiting("auth");

        auth.MapPost("/register-shop", async (RegisterShopRequest req, PosDbContext db, IPasswordHasher<User> hasher, TokenService tokens) =>
        {
            if (Common.Clean(req.ShopName) is not { } shopName) return Common.Invalid("shopName", "Shop name is required.");
            if (Common.Clean(req.OwnerName) is not { } ownerName) return Common.Invalid("ownerName", "Owner name is required.");
            if (string.IsNullOrWhiteSpace(req.Email) || !req.Email.Contains('@')) return Common.Invalid("email", "A valid email is required.");
            if ((req.Password?.Length ?? 0) < MinPasswordLength) return Common.Invalid("password", $"Password must be at least {MinPasswordLength} characters.");

            var email = NormalizeEmail(req.Email);
            if (await db.Users.IgnoreQueryFilters().AnyAsync(u => u.Email == email))
                return Common.Invalid("email", "This email is already registered.");

            var shop = new Shop { Name = shopName };
            var owner = new User { ShopId = shop.Id, Name = ownerName, Email = email, Role = UserRole.Owner };
            owner.PasswordHash = hasher.HashPassword(owner, req.Password!);

            db.Shops.Add(shop);
            db.Users.Add(owner);
            db.Registers.Add(new Register { ShopId = shop.Id, Code = "T1", Name = "Till 1" });
            db.VatRates.Add(new VatRate { ShopId = shop.Id, RateBps = DefaultVatBps, EffectiveFrom = VatStart });
            await db.SaveChangesAsync();

            var (token, expires) = tokens.Create(owner);
            return Results.Ok(new AuthResponse(token, expires, owner.ToDto(), shop.Id));
        });

        auth.MapPost("/login", async (LoginRequest req, PosDbContext db, IPasswordHasher<User> hasher, TokenService tokens) =>
        {
            var email = NormalizeEmail(req.Email ?? "");
            var user = await db.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Email == email);
            // The same answer for a wrong email and a wrong password, so the login cannot be used to discover accounts.
            if (user is null || !user.IsActive) return Results.Unauthorized();

            var check = hasher.VerifyHashedPassword(user, user.PasswordHash, req.Password ?? "");
            if (check == PasswordVerificationResult.Failed) return Results.Unauthorized();
            if (check == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = hasher.HashPassword(user, req.Password!);
                await db.SaveChangesAsync();
            }

            var (token, expires) = tokens.Create(user);
            return Results.Ok(new AuthResponse(token, expires, user.ToDto(), user.ShopId));
        });

        app.MapGet("/api/me", async (CurrentUser current, PosDbContext db) =>
            await db.Users.FirstOrDefaultAsync(u => u.Id == current.UserId) is { } user
                ? Results.Ok(user.ToDto())
                : Results.Unauthorized())
            .RequireAuthorization();

        var users = app.MapGroup("/api/users").RequireAuthorization(Policies.OwnerOnly);

        users.MapGet("/", async (PosDbContext db) =>
            (await db.Users.OrderBy(u => u.Name).ToListAsync()).Select(u => u.ToDto()));

        users.MapPost("/", async (CreateUserRequest req, PosDbContext db, CurrentUser current, IPasswordHasher<User> hasher) =>
        {
            if (Common.Clean(req.Name) is not { } name) return Common.Invalid("name", "Name is required.");
            if (string.IsNullOrWhiteSpace(req.Email) || !req.Email.Contains('@')) return Common.Invalid("email", "A valid email is required.");
            if ((req.Password?.Length ?? 0) < MinPasswordLength) return Common.Invalid("password", $"Password must be at least {MinPasswordLength} characters.");
            if (!Enum.IsDefined(req.Role)) return Common.Invalid("role", "Unknown role.");

            var email = NormalizeEmail(req.Email);
            if (await db.Users.IgnoreQueryFilters().AnyAsync(u => u.Email == email))
                return Common.Invalid("email", "This email is already registered.");

            var user = new User { ShopId = current.RequiredShopId, Name = name, Email = email, Role = req.Role };
            user.PasswordHash = hasher.HashPassword(user, req.Password!);
            db.Users.Add(user);
            db.Audit(current, "user.created", nameof(User), user.Id, new { user.Email, user.Role });
            await db.SaveChangesAsync();
            return Results.Created($"/api/users/{user.Id}", user.ToDto());
        });

        users.MapPatch("/{id:guid}", async (Guid id, UpdateUserRequest req, PosDbContext db, CurrentUser current, IPasswordHasher<User> hasher) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null) return Results.NotFound();

            var removesOwner = user.Role == UserRole.Owner
                && ((req.Role is { } newRole && newRole != UserRole.Owner) || req.IsActive == false);
            if (removesOwner && !await db.Users.AnyAsync(u => u.Id != id && u.Role == UserRole.Owner && u.IsActive))
                return Common.Invalid("role", "The shop must keep at least one active owner.");

            if (req.Name is not null)
            {
                if (Common.Clean(req.Name) is not { } name) return Common.Invalid("name", "Name is required.");
                user.Name = name;
            }
            if (req.Role is { } role)
            {
                if (!Enum.IsDefined(role)) return Common.Invalid("role", "Unknown role.");
                user.Role = role;
            }
            if (req.IsActive is { } active) user.IsActive = active;
            if (req.Password is not null)
            {
                if (req.Password.Length < MinPasswordLength) return Common.Invalid("password", $"Password must be at least {MinPasswordLength} characters.");
                user.PasswordHash = hasher.HashPassword(user, req.Password);
            }

            db.Audit(current, "user.updated", nameof(User), user.Id, new { user.Role, user.IsActive, PasswordChanged = req.Password is not null });
            await db.SaveChangesAsync();
            return Results.Ok(user.ToDto());
        });
    }
}
