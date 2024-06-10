using MedicalCenters.Identity.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IAuthorizationFilter = Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter;

namespace MedicalCenters.Identity.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresPermissionAttribute(PermissionEnum permission) : Attribute, IAuthorizationFilter
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
                    HasPermission = await identityUnitOfWork.AuthorizationRepository.HasUserPermission(UserId, (int)permission);

                    //Check Group Permission
                    if (!HasPermission)
                        HasPermission = await identityUnitOfWork.AuthorizationRepository.HasUserGroupPermission(UserId, (int)permission);
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
