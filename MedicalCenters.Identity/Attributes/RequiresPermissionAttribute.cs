using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Models.Domains;
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
using Microsoft.Extensions.DependencyInjection;
using IAuthorizationFilter = Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter;
using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalCenters.Identity.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresPermissionAttribute(int permissionId) : Attribute, IAuthorizationFilter
    {
        async void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            bool HasPermission = false;
            try
            {
                var identityUnitOfWork = (IIdentityUnitOfWork)context.HttpContext.RequestServices.GetService<IIdentityUnitOfWork>();

                var User = context.HttpContext.User;
                var Authenticalted = User.Identities.Any(e => e.IsAuthenticated == true);

                if (Authenticalted && HasClaimsPrinciple_UserId(User))
                {
                    long UserId = Convert.ToInt64(User.FindFirst(JwtRegisteredClaimNames.Sid).Value);

                    //Check User Permission
                    HasPermission = await identityUnitOfWork.AuthorizationRepository.HasUserPermission(UserId, permissionId);

                    //Check Group Permission
                    if(!HasPermission)
                        HasPermission=await identityUnitOfWork.AuthorizationRepository.HasUserGroupPermission(UserId, permissionId);
                }
            }
            catch { }

#if (!DEBUG)
            if (!HasPermission)
            {
                context.Result = new ForbidResult();
            }
#endif
        }

        private bool HasClaimsPrinciple_UserId(ClaimsPrincipal? User)
        {
            return User.FindFirst(JwtRegisteredClaimNames.Sid) is not null;
        }
    }
}
