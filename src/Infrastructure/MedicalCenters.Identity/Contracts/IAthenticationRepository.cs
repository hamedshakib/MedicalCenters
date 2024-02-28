using MedicalCenters.Identity.Models.Domains;

namespace MedicalCenters.Identity.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<bool> IsToken
        Task<User?> FindUser(string Username);
    }
}
