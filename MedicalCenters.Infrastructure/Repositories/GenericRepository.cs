using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MedicalCentersDBContext _dBContext;
        public GenericRepository(MedicalCentersDBContext dBContext)
        {
            _dBContext= dBContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dBContext.AddAsync(entity);
            return entity;
        }

        public async Task Delete(long id)
        {
            var entity = await Get(id);
            Delete(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            Delete(entity);
        }

        public async Task Delete(T entity)
        {
            _dBContext.Set<T>().Remove(entity);
        }

        public async Task<bool> Exist(long id,CancellationToken cancellationToken = default)
        {
            var entity = await Get(id,cancellationToken);
            return entity != null;
        }

        public async Task<bool> Exist(int id, CancellationToken cancellationToken = default)
        {
            var entity = await Get(id,cancellationToken);
            return entity != null;
        }

        public async Task<T> Get(long id,CancellationToken cancellationToken=default)
        {
            return await _dBContext.Set<T>().FindAsync(id,cancellationToken);
        }

        public async Task<T> Get(int id,CancellationToken cancellationToken = default)
        {
            return await _dBContext.Set<T>().FindAsync(id,cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dBContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task Update(T entity)
        {
            _dBContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Update(long id)
        {
            var entity = await Get(id);
            _dBContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Update(int id)
        {
            var entity = await Get(id);
            _dBContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
