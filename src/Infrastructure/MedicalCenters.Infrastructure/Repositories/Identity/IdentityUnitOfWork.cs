using MedicalCenters.Domain.Contracts;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace MedicalCenters.Persistence.Repositories.Identity
{
    internal class IdentityUnitOfWork(IdentityDBContext _dBContext) : IUnitOfWork
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
