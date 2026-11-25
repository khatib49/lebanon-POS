using System.Security.Claims;
using System.Text;
using LebanonPos.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace LebanonPos.Api.Auth;

public class JwtOptions
{
    public string Issuer { get; set; } = "lebanon-pos";
    public string Audience { get; set; } = "lebanon-pos";
    /// <summary>Secret signing key, at least 32 characters. Set it from the environment, never in the repository.</summary>
    public string Key { get; set; } = "";
    public int LifetimeHours { get; set; } = 12;

    public SymmetricSecurityKey SigningKey()
    {
        if (Encoding.UTF8.GetByteCount(Key) < 32)
            throw new InvalidOperationException("Jwt:Key must be set to a secret of at least 32 characters.");
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}

public class TokenService(IOptions<JwtOptions> options)
{
    private readonly JwtOptions _options = options.Value;

    public (string Token, DateTimeOffset ExpiresAt) Create(User user)
    {
        var expires = DateTimeOffset.UtcNow.AddHours(_options.LifetimeHours);
        var token = new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            Expires = expires.UtcDateTime,
            Subject = new ClaimsIdentity(
            [
                new Claim(PosClaims.UserId, user.Id.ToString()),
                new Claim(PosClaims.ShopId, user.ShopId.ToString()),
                new Claim(PosClaims.Role, user.Role.ToString()),
                new Claim(PosClaims.Name, user.Name),
            ]),
            SigningCredentials = new SigningCredentials(_options.SigningKey(), SecurityAlgorithms.HmacSha256),
        });
        return (token, expires);
    }
}
