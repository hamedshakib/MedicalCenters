using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using MedicalCenters.Domain.Entities.Medicines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        Task<MedicineType> GetMedicineType(int id, CancellationToken cancellationToken = default);
        Task<IList<Medicine>> GetAllMedicineTypeMedicines(int medicineType, CancellationToken cancellationToken = default);
    }
}
