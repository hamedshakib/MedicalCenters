using MedicalCenters.Cache;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace MedicalCenters.Persistence.Repositories.Identity
{
    internal class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IdentityDBContext _dBContext;
        private readonly IDatabase _redisDatabase;
        public AuthenticationRepository(IdentityDBContext dBContext,IDatabase redisDatabase)
        {
            _dBContext = dBContext;
            _redisDatabase = redisDatabase;
        }

        public async Task<User?> FindUserAsync(string Username)
        {
            var findUser = await (from user in _dBContext.User
                                    where user.UserName == Username
                                    select user).FirstOrDefaultAsync();

            return findUser;
        }

        async Task<string> IAuthenticationRepository.GetRefreshTokenAsync(long UserId)
        {
            var data = await _redisDatabase.StringGetAsync($"Users:{UserId}:RefreshToken");

            return data.HasValue ? data.ToString() : string.Empty;
        }

        Task<bool> IAuthenticationRepository.SaveRefreshTokenAsync(long UserId, string RefreshToken)
        {
            return _redisDatabase.StringSetAsync($"Users:{UserId}:RefreshToken", RefreshToken);
        }
    }
}
