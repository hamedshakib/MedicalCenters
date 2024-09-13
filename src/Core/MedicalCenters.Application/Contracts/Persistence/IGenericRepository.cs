namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        ValueTask<T?> GetAsync(long id, CancellationToken cancellationToken = default);
        ValueTask<T?> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        ValueTask<bool> ExistAsync(long id, CancellationToken cancellationToken = default);
        ValueTask<bool> ExistAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity);
        Task UpdateAsync(long id);
        Task UpdateAsync(int id);
        Task DeleteAsync(long id);
        Task DeleteAsync(int id);
        Task DeleteAsync(T entity);

    }
}
