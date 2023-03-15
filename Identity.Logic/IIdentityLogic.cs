using Agro.Shared.Data.Context;
using System.IdentityModel.Tokens.Jwt;

namespace Agro.Identity.Logic
{
    public interface IIdentityLogic
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken(User user);
        JwtSecurityToken DecodeToken(string token);
        bool TokenExpired(string token);
    }
}
