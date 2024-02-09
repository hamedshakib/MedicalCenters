using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Authoize
{
    public class RequiresPermitionAttribute(string Permition) : Attribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            bool HasPermition = false;
            var UsernameObject = context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.UniqueName);
            if (UsernameObject is not null)
            {
                string Username=context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.UniqueName).Value;

                //Check Permition
                //Check User Permition

                //Check Group Permition

                HasPermition = true;
            }




            if (!HasPermition)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
