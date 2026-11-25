using System.Security.Claims;
using LebanonPos.Domain;
using LebanonPos.Infrastructure;

namespace LebanonPos.Api.Auth;

public static class PosClaims
{
    public const string UserId = "sub";
    public const string ShopId = "shop";
    public const string Role = "role";
    public const string Name = "name";
}

public static class Policies
{
    public const string ManagerUp = "ManagerUp";
    public const string OwnerOnly = "OwnerOnly";
}

/// <summary>The signed-in user, read from the access token of the current request.</summary>
public class CurrentUser(IHttpContextAccessor accessor) : ICurrentShop
{
    private ClaimsPrincipal? Principal => accessor.HttpContext?.User;

    public Guid? ShopId => Guid.TryParse(Principal?.FindFirstValue(PosClaims.ShopId), out var id) ? id : null;

    public Guid UserId => Guid.TryParse(Principal?.FindFirstValue(PosClaims.UserId), out var id)
        ? id
        : throw new InvalidOperationException("No signed-in user.");

    public Guid RequiredShopId => ShopId ?? throw new InvalidOperationException("No signed-in user.");

    public UserRole Role => Enum.Parse<UserRole>(Principal?.FindFirstValue(PosClaims.Role) ?? nameof(UserRole.Cashier));
}
