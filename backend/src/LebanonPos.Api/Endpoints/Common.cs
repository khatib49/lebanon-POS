using System.Text.Json;
using LebanonPos.Api.Auth;
using LebanonPos.Domain.Entities;
using LebanonPos.Infrastructure;

namespace LebanonPos.Api.Endpoints;

public static class Common
{
    public static readonly TimeZoneInfo Beirut = TimeZoneInfo.FindSystemTimeZoneById("Asia/Beirut");

    public static IResult Invalid(string field, string message) =>
        Results.ValidationProblem(new Dictionary<string, string[]> { [field] = [message] });

    public static string? Clean(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    /// <summary>Adds an audit entry to the current unit of work; it is saved together with the change it describes.</summary>
    public static void Audit(this PosDbContext db, CurrentUser user, string action, string? entityType = null, object? entityId = null, object? details = null) =>
        db.AuditEntries.Add(new AuditEntry
        {
            ShopId = user.RequiredShopId,
            UserId = user.UserId,
            Action = action,
            EntityType = entityType,
            EntityId = entityId?.ToString(),
            Details = details is null ? null : JsonSerializer.Serialize(details, JsonSerializerOptions.Web),
        });
}
