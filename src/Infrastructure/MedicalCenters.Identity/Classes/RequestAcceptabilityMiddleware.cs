using MedicalCenters.Cache;
using MedicalCenters.Identity.Exceptions;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using StackExchange.Redis;

namespace MedicalCenters.Identity.Classes
{
    public class RequestAcceptabilityMiddleware(RequestDelegate _next, IMasterCacheProvider _cacheProvider,OverLimitRequestChecker overLimitRequestChecker)
    {
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrEmpty(token))
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

                long UserId = Convert.ToInt64(context.User.FindFirst(JwtRegisteredClaimNames.Sid).Value);

                if (IsBlockedToken(jwtSecurityToken, UserId).Result)
                    throw new TokenBlockedException();
                if (!overLimitRequestChecker.Check(UserId))
                    throw new UserOverLimitRequestedException();
            }


            await _next(context);
        }

        private async Task<bool> IsBlockedToken(JwtSecurityToken securityToken, long UserId)
        {
            var CreatedTime = securityToken.IssuedAt;

            var LastBlockDatetime = await _cacheProvider.GetDistributedCacheAsync<DateTime?>($"Users:{UserId}:BlockedTokenDateTime");

            if (LastBlockDatetime.HasValue && CreatedTime <= LastBlockDatetime)
                return true;
            else
                return false;
        }
    }
}
