using MedicalCenters.Identity.Basic;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Classes
{
    internal class PreparerTokenValidationParameters
    {
        internal static Microsoft.IdentityModel.Tokens.TokenValidationParameters GetTokenValidationParameters()
        {
            return new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                IssuerSigningKey = CustomSecurityKeyBasic.SymmetricSecurityKey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = "Medical Center Server",
                ValidAudience = "Medical Center Client",
                ValidateAudience = true,
                LifetimeValidator = CustomLifetimeValidator
            };
        }
        private static bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires,
                                    SecurityToken tokenToValidate, TokenValidationParameters @param)
        {
            if (expires != null)
            {
                return expires > DateTime.UtcNow;
            }
            return false;
        }
    }
}
