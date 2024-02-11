using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Get(long id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Exist(long id);
        Task<bool> Exist(int id);
        Task Update(T entity);
        Task Update(long id);
        Task Update(int id);
        Task Delete(long id);
        Task Delete(int id);
        Task Delete(T entity);

    }
}
