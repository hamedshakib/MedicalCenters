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

            var result = (from u in _dBContext.User
                          where u.Id == userId &&
                          u.PermissionGroups.Select(pg => pg.Permissions)
                          .Where(ps => ps.Select(p => p.Id).Contains(permitionId)).Any()
                          select 1).Any();

            return result;
        }

        public async Task<bool> HasUserPermition(long userId, int permitionId)
        {
            var result =(from u in _dBContext.User
            where u.Id== userId && u.Permissions.Any(u => u.Id == permitionId)
            select 1).Any();

            return result;
        }
    }
}
