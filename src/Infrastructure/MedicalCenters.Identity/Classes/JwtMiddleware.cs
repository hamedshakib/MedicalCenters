using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Classes
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            if(!string.IsNullOrEmpty(token))
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

                long UserId = Convert.ToInt64(context.User.FindFirst(JwtRegisteredClaimNames.Sid).Value);

                if(IsBlockedToken(jwtSecurityToken, UserId))
                    throw new UnauthorizedAccessException();
            }


            await _next(context);
        }

        private bool IsBlockedToken(JwtSecurityToken securityToken,long UserId)
        {
            var CreatedTime = securityToken.IssuedAt;
            DateTime? LastBlockDatetime = null;


            if(LastBlockDatetime.HasValue && CreatedTime <= LastBlockDatetime)
                return true;

            return false;
        }

    }
}
