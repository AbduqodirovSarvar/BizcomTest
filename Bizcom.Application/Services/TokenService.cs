using Bizcom.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GetAccessToken(Claim[] claims)
        {
            Claim[] jwtClaim = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, DateTime.UtcNow.ToString()),
            };

            var jwtCLaims = claims.Concat(jwtClaim);

            var token = new JwtSecurityToken(
                "Something",
                "Something",
                jwtCLaims,
                expires: DateTime.UtcNow.AddDays(1)
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
