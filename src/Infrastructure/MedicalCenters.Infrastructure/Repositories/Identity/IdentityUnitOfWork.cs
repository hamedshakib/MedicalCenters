﻿using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Entities;
using MedicalCenters.Identity.Contracts;
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
    internal class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private readonly IdentityDBContext _dBContext;

        private IAuthenticationRepository _athenticationRepository;
        public IAuthenticationRepository AuthenticationRepository => _athenticationRepository ??= new AthenticationRepository(_dBContext);

        private IAuthorizationRepository _authorizationRepository;
        public IAuthorizationRepository AuthorizationRepository => _authorizationRepository ??= new AuthorizationRepository(_dBContext);


        public IdentityUnitOfWork(IdentityDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task Save()
        {
            //long UserId = 
            await _dBContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dBContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
