

using MedicalCenters.Identity.Authoize;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedicalCenters.Identity.Classes
{
    public class JWTTokenCreator
    {
        public static string? GetJWTToken(List<Claim> claims)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = "Medical Center Server",
                Audience = "Medical Center Client",
                SigningCredentials = new SigningCredentials(CustomSecurityKey.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}
