using MedicalCenters.Cache;
using MedicalCenters.Identity.Exceptions;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace MedicalCenters.Identity.Classes
{
    public class RequestAcceptabilityMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestAcceptabilityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrEmpty(token))
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

                long UserId = Convert.ToInt64(context.User.FindFirst(JwtRegisteredClaimNames.Sid).Value);

                if (IsBlockedToken(jwtSecurityToken, UserId))
                    throw new TokenBlockedException();
                if (!OverLimitRequestChecker.Check(UserId))
                    throw new UserOverLimitRequestedException();
            }


            await _next(context);
        }

        private bool IsBlockedToken(JwtSecurityToken securityToken, long UserId)
        {
            var CreatedTime = securityToken.IssuedAt;

            var data = RedisDatabase.Database.StringGet($"Users:{UserId}:BlockedTokenDateTime");

            if (data.HasValue)
            {
                DateTime LastBlockDatetime;
                if (DateTime.TryParse(data.ToString(), out LastBlockDatetime))
                {
                    if (CreatedTime <= LastBlockDatetime)
                        return true;
                }
            }
            return false;
        }
    }
}
