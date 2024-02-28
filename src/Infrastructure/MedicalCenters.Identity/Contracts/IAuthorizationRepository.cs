namespace MedicalCenters.Identity.Contracts
{
    public interface IAuthorizationRepository
    {
        Task<bool> HasUserPermission(long userId, int permitionId);
        Task<bool> HasUserGroupPermission(long userId, int permitionId);
    }
}
