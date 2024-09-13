using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenters.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MedicalCentersDBContext _dBContext;
        public GenericRepository(MedicalCentersDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dBContext.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetAsync(id);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dBContext.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async ValueTask<bool> ExistAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await GetAsync(id, cancellationToken);
            return entity != null;
        }

        public async ValueTask<bool> ExistAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetAsync(id, cancellationToken);
            return entity != null;
        }

        public async ValueTask<T?> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _dBContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public ValueTask<T?> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return _dBContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dBContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity)
        {
            _dBContext.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(long id)
        {
            var entity = await GetAsync(id);
            _dBContext.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(int id)
        {
            var entity = await GetAsync(id);
            _dBContext.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
