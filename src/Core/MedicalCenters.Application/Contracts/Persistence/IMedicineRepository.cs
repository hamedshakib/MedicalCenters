using MedicalCenters.Domain.Entities.Medicines;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        ValueTask<MedicineType?> GetMedicineTypeAsync(int id, CancellationToken cancellationToken = default);
        Task<IList<Medicine>> GetAllMedicineTypeMedicinesAsync(int medicineType, CancellationToken cancellationToken = default);
    }
}
