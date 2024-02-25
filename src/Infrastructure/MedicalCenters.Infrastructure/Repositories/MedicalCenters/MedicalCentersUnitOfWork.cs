using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Infrastructure.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicalCentersUnitOfWork : IMedicalCentersUnitOfWork
    {
        private readonly MedicalCentersDBContext _dBContext;

        private IMedicalCenterRepository _medicalCenterRepository;
        public IMedicalCenterRepository MedicalCenterRepository => _medicalCenterRepository ??= new MedicalCenterRepository(_dBContext);

        private IMedicalWardRepository _medicalWardRepository;
        public IMedicalWardRepository MedicalWardRepository => _medicalWardRepository ??= new MedicalWardRepository(_dBContext);

        private IMedicineRepository _medicineRepository;
        public IMedicineRepository MedicineRepository => _medicineRepository ??= new MedicineRepository(_dBContext);

        public MedicalCentersUnitOfWork(MedicalCentersDBContext dBContext)
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
