using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Infrastructure.DBContexts;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Repositories.Identity
{
    internal class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly IdentityDBContext _dBContext;
        public AuthorizationRepository(IdentityDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<bool> HasUserGroupPermition(long userId,int permitionId)
        {
            var result = (from PGU in _dBContext.PermissionGroup_User
                          join PG in _dBContext.PermissionGroup on PGU.PermissionGroupId equals PG.Id
                          join PPG in _dBContext.Permission_PermissionGroup on PG.Id equals PPG.PermissionGroupId
                          where PGU.UserId == userId && PPG.PermissionId == permitionId
                          select 1
                ).Any();

            return result;
        }

        public async Task<bool> HasUserPermition(long userId, int permitionId)
        {

            var result = (from U in _dBContext.User
                          join PU in _dBContext.Permission_User on  U.Id equals PU.UserId
                          where PU.UserId == userId && PU.PermissionId == permitionId
                          select 1).Any();
            return result;
        }
    }
}
