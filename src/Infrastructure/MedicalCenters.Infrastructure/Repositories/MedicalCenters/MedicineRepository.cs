using MedicalCenters.Domain.Abstractions;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicineRepository(MedicalCentersDBContext dBContext)
        : GenericRepository<Medicine>(dBContext), IMedicineRepository
    {
        private readonly MedicalCentersDBContext _dBContext = dBContext;

        public async Task<IList<Medicine>> GetAllMedicineTypeMedicinesAsync(int medicineType, CancellationToken cancellationToken = default)
        {
            var medicines = await (from medicine in _dBContext.Medicine
                                   where medicine.TypeId == medicineType
                                   select medicine).ToListAsync(cancellationToken);

            return medicines;
        }

        public ValueTask<MedicineType?> GetMedicineTypeAsync(int medicineType, CancellationToken cancellationToken = default)
        {
            return _dBContext.MedicineType.FindAsync(medicineType, cancellationToken);
        }
    }
}
