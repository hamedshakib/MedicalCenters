using MedicalCenters.Identity.Basic;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Exceptions;
using MedicalCenters.Identity.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MedicalCenters.Identity.Classes
{
    public class JWTTokenCreator(IAuthenticationRepository _authenticationRepository)
    {
        private static string? _GetJWTToken(List<Claim> claims)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = "Medical Center Server",
                Audience = "Medical Center Client",
                SigningCredentials = new SigningCredentials(CustomSecurityKeyBasic.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }

        private static string? _GetJWTRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
            return null;
        }

        public async Task<TokenDto> GenerateTokenDtoAsync(long userId, string username)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName ,username),
                new Claim(JwtRegisteredClaimNames.Sid , userId.ToString()),
            };

            var accessToken = _GetJWTToken(claims);
            var refreshToken = _GetJWTRefreshToken();

            await _authenticationRepository.SaveRefreshTokenAsync(userId, refreshToken);

            return new TokenDto() { AccessToken = accessToken, RefreshToken = refreshToken };
        }
        public async Task<TokenDto> GenerateTokenDtoAsync(string AccessToken, string RefreshToken)
        {
            var principal = _GetPrincipalFromExpiredToken(AccessToken);

            long userId = Convert.ToInt64(principal.FindFirstValue(JwtRegisteredClaimNames.Sid));
            //var vvvvv = principal.FindFirst(JwtRegisteredClaimNames.UniqueName);
            string username = principal.Identity.Name;

            var savedRefreshToken = await _authenticationRepository.GetRefreshTokenAsync(userId);


            if (string.IsNullOrEmpty(RefreshToken) || savedRefreshToken != RefreshToken)
            {
                throw new RefreshTokenFailedException();
            }

            var tokenDto = await GenerateTokenDtoAsync(userId, username);

            await _authenticationRepository.SaveRefreshTokenAsync(userId, tokenDto.RefreshToken);

            return tokenDto;
        }

        private static ClaimsPrincipal _GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = PreparerTokenValidationParameters.GetTokenValidationParameters();
            tokenValidationParameters.ValidateLifetime = false;
            tokenValidationParameters.LifetimeValidator = null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || jwtSecurityToken.Header.Alg != SecurityAlgorithms.HmacSha256)
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

    }
}
