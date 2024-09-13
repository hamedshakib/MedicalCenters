using MedicalCenters.Identity.Models.Domains;

namespace MedicalCenters.Identity.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<User?> FindUserAsync(string Username);

        Task<bool> SaveRefreshTokenAsync(long UserId, string RefreshToken);

        Task<string> GetRefreshTokenAsync(long UserId);
    }
}
