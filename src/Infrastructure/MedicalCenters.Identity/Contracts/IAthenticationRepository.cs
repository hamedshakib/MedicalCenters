using MedicalCenters.Identity.Models.Domains;

namespace MedicalCenters.Identity.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<User?> FindUserAsync(string username);

        Task<bool> SaveRefreshTokenAsync(long userId, string refreshToken);

        Task<string> GetRefreshTokenAsync(long userId);
    }
}
