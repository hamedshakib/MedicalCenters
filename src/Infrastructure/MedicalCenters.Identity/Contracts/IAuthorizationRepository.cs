namespace MedicalCenters.Identity.Contracts
{
    public interface IAuthorizationRepository
    {
        Task<bool> HasUserPermission(long userId, int permissionId);
        Task<bool> HasUserGroupPermission(long userId, int permissionId);
    }
}
