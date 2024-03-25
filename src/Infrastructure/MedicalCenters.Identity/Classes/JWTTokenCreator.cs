﻿using MedicalCenters.Identity.Basic;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Exceptions;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Identity.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MedicalCenters.Identity.Classes
{
    public class JWTTokenCreator(IIdentityUnitOfWork identityUnitOfWork)
    {
        private string? GetJWTToken(List<Claim> claims)
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

        private string? GetJWTRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
            return null;
        }

        public TokenDto GenerateTokenDto(long UserId,string Username)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName ,Username),
                new Claim(JwtRegisteredClaimNames.Sid , UserId.ToString()),
            };

            var AccessToken = GetJWTToken(claims);
            var RefreshToken = GetJWTRefreshToken();

            identityUnitOfWork.AuthenticationRepository.SaveRefreshToken(UserId, RefreshToken);

            return new TokenDto() { AccessToken = AccessToken, RefreshToken = RefreshToken };
        }
        public TokenDto GenerateTokenDto(string AccessToken,string RefreshToken) 
        {
            var principal = GetPrincipalFromExpiredToken(AccessToken);

            long userId = Convert.ToInt64(principal.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var vvvvv=principal.FindFirst(JwtRegisteredClaimNames.UniqueName);
            string Username = principal.Identity.Name;

            var savedRefreshToken = identityUnitOfWork.AuthenticationRepository.GetRefreshToken(userId).Result;


            if (string.IsNullOrEmpty(RefreshToken) || savedRefreshToken != RefreshToken)
            {
                throw new RefreshTokenFailedException();
            }

            var tokenDto = GenerateTokenDto(userId, Username);

            identityUnitOfWork.AuthenticationRepository.SaveRefreshToken(userId, tokenDto.RefreshToken);

            return tokenDto;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = PreparerTokenValidationParameters.GetTokenValidationParameters();

            tokenValidationParameters.ValidateLifetime = false;
            tokenValidationParameters.LifetimeValidator = null;

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);


                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                bool isnull = jwtSecurityToken == null;
                bool IsAlg_equal = jwtSecurityToken.Header.Alg == SecurityAlgorithms.HmacSha256;

                if (jwtSecurityToken == null)
                {
                    throw new SecurityTokenException("Invalid token");
                }

                return principal;
            }
            catch (Exception ex)
            {
                int i = 8;
                i++;
                return null;
            }
        }

    }
}
