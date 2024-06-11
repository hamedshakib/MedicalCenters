using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MedicalCenters.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionScopeAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
    }
}
