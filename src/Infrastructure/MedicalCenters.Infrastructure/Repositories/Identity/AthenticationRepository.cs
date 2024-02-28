﻿using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenters.Persistence.Repositories.Identity
{
    internal class AthenticationRepository : IAuthenticationRepository
    {
        private readonly IdentityDBContext _dBContext;
        public AthenticationRepository(IdentityDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<User?> FindUser(string Username)
        {
            var findUser = await (from user in _dBContext.User
                                  where user.UserName == Username
                                  select user).FirstOrDefaultAsync();

            return findUser;
        }
    }
}
