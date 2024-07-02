using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicineRepository : GenericRepository<Medicine>, IMedicineRepository
    {
        private readonly MedicalCentersDBContext _dBContext;
        public MedicineRepository(MedicalCentersDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IList<Medicine>> GetAllMedicineTypeMedicines(int medicineType, CancellationToken cancellationToken = default)
        {
            var Medicines = await (from medicine in _dBContext.Medicine
                                   where medicine.TypeId == medicineType
                                   select medicine).ToListAsync(cancellationToken);

            return Medicines;
        }

        public async Task<MedicineType> GetMedicineType(int medicineType, CancellationToken cancellationToken = default)
        {
            var value = await _dBContext.MedicineType.FindAsync(medicineType, cancellationToken);
            return value;
        }
    }
}
