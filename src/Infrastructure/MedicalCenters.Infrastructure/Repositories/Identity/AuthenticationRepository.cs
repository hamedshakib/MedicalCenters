using MedicalCenters.Cache;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace MedicalCenters.Persistence.Repositories.Identity
{
    internal class AuthenticationRepository(IdentityDBContext _dBContext, IMasterCacheProvider _masterCacheProvider)
        : IAuthenticationRepository
    {
        public async Task<User?> FindUserAsync(string username)
        {
            var findUser = await (from user in _dBContext.User
                                    where user.UserName == username
                                    select user).FirstOrDefaultAsync();

            return findUser;
        }

        async Task<string> IAuthenticationRepository.GetRefreshTokenAsync(long userId)
        {
            var data = await _masterCacheProvider.GetDistributedCacheAsync<string>($"Users:{userId}:RefreshToken");
            return data ?? string.Empty;
        }

        Task IAuthenticationRepository.SaveRefreshTokenAsync(long userId, string refreshToken)
        {
            return _masterCacheProvider.SetDistributedCacheAsync($"Users:{userId}:RefreshToken", refreshToken);
        }
    }
}
