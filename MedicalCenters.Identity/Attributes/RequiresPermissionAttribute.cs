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
using System.Web.Mvc;
using IAuthorizationFilter = Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter;

namespace MedicalCenters.Identity.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresPermissionAttribute(int permissionId) : Attribute, IAuthorizationFilter
    {
        IIdentityUnitOfWork unitOfWork =DependencyResolver.Current.GetService<IIdentityUnitOfWork>();
        async void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            bool HasPermition = false;
            try
            {
                var User = context.HttpContext.User;
                var Authenticalted = User.Identities.Any(e => e.IsAuthenticated == true);

                if (Authenticalted && HasClaimsPrinciple_UserId(User))
                {
                    long UserId = Convert.ToInt64(User.FindFirst(JwtRegisteredClaimNames.Sid).Value);

                    //Check User Permission
                    HasPermition = await unitOfWork.AuthorizationRepository.HasUserPermition(UserId, permissionId);

                    //Check Group Permission
                    if(!HasPermition)
                        HasPermition=await unitOfWork.AuthorizationRepository.HasUserGroupPermition(UserId, permissionId);

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
