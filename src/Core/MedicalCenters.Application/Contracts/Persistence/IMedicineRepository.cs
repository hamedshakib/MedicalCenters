using MedicalCenters.Domain.Entities.Medicines;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        Task<MedicineType> GetMedicineType(int id, CancellationToken cancellationToken = default);
        Task<IList<Medicine>> GetAllMedicineTypeMedicines(int medicineType, CancellationToken cancellationToken = default);
    }
}
