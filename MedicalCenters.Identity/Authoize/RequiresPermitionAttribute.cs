using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Authoize
{
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresPermitionAttribute(string Permition) : Attribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            bool HasPermition = false;
            try
            {
                var User = context.HttpContext.User;
                var Authenticalted = User.Identities.Any(e => e.IsAuthenticated == true);

                if (Authenticalted && HasClaimsPrinciple_UserId(User))
                {
                    long UserId = Convert.ToInt64(User.FindFirst(JwtRegisteredClaimNames.Sid).Value);

                    //Check Permition
                    //Check User Permition

                    //Check Group Permition

                    HasPermition = true;
                }
            }
            catch { }

            if (!HasPermition)
            {
                context.Result = new ForbidResult();
            }
        }

        private bool HasClaimsPrinciple_UserId(ClaimsPrincipal? User)
        {
            return User.FindFirst(JwtRegisteredClaimNames.Sid) is not null;
        }
    }
}
