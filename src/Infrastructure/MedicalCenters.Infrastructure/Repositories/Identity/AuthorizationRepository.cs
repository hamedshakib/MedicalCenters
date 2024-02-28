using MedicalCenters.Identity.Contracts;
using MedicalCenters.Persistence.DBContexts;

namespace MedicalCenters.Persistence.Repositories.Identity
{
    internal class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly IdentityDBContext _dBContext;
        public AuthorizationRepository(IdentityDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<bool> HasUserGroupPermission(long userId, int permissionId)
        {
            var result = (from PGU in _dBContext.PermissionGroup_User
                          join PG in _dBContext.PermissionGroup on PGU.PermissionGroupId equals PG.Id
                          join PPG in _dBContext.Permission_PermissionGroup on PG.Id equals PPG.PermissionGroupId
                          where PGU.UserId == userId && PPG.PermissionId == permissionId
                          select 1
                ).Any();

            return result;
        }

        public async Task<bool> HasUserPermission(long userId, int permissionId)
        {

            var result = (from U in _dBContext.User
                          join PU in _dBContext.Permission_User on U.Id equals PU.UserId
                          where PU.UserId == userId && PU.PermissionId == permissionId
                          select 1).Any();
            return result;
        }
    }
}
