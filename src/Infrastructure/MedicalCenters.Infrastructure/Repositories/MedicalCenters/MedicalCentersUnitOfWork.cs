﻿using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicalCentersUnitOfWork(MedicalCentersDBContext _dBContext) : IUnitOfWork
    {
        private IDbContextTransaction _transactionScope;


        public void Dispose()
        {
            _dBContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return (await _dBContext.SaveChangesAsync(cancellationToken)) > 0;
        }

        public async Task BeginTransactionScopeAsync(IsolationLevel isolationLevel)
        {
            _transactionScope = await _dBContext.Database.BeginTransactionAsync(isolationLevel);
        }

        public Task CommitTransactionAsync()
        {
            return _transactionScope.CommitAsync();
        }

        public Task RollBackTransactionAsync()
        {
            return _transactionScope.RollbackAsync();
        }
    }
}
