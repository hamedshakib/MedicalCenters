using MedicalCenters.Identity.Models.Domains;

namespace MedicalCenters.Identity.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<User?> FindUser(string Username);

        Task<bool> SaveRefreshToken(long UserId, string RefreshToken);

        Task<string> GetRefreshToken(long UserId);
    }
}
