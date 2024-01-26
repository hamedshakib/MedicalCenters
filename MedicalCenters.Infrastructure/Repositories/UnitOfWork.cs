using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Infrastructure.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalCentersDBContext _dBContext;
        private IMedicalCenterRepository _medicalCenterRepository;
        public IMedicalCenterRepository MedicalCenterRepository => _medicalCenterRepository ??= new MedicalCenterRepository(_dBContext);

        public UnitOfWork(MedicalCentersDBContext dBContext)
        {
            _dBContext=dBContext;
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
