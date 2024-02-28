namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Get(long id, CancellationToken cancellationToken = default);
        Task<T> Get(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
        Task<bool> Exist(long id, CancellationToken cancellationToken = default);
        Task<bool> Exist(int id, CancellationToken cancellationToken = default);
        Task Update(T entity);
        Task Update(long id);
        Task Update(int id);
        Task Delete(long id);
        Task Delete(int id);
        Task Delete(T entity);

    }
}
