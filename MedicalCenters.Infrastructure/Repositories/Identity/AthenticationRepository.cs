using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Entities;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Infrastructure.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Repositories.Identity
{
    internal class AthenticationRepository : IAthenticationRepository
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
