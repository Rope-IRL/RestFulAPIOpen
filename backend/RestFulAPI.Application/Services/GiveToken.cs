using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RestFulAPI.Application.DTOs;

namespace RestFulAPI.Application.Services;

public static class GiveToken
{
    public static async  Task<string> Token(ICanHaveToken user)
    {
        var identity = GetIdentity(user);
        if (identity == null)
        {
            return null;
        }

        var now = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
            issuer: Authenticate.ISSUER,
            audience: Authenticate.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(Authenticate.LIFETIME)),
            signingCredentials: new SigningCredentials(Authenticate.GetSymmetricKey(), SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt.ToString();

    }

    private static ClaimsIdentity GetIdentity(ICanHaveToken user)
    {
        if (user != null)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Role, user.RoleForToken()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.NameForToken()));
            ci.AddClaim(new Claim("id", user.UserId().ToString()));
            return ci;

        }
        return null;

    }
}