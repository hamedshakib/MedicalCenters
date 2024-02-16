using MedicalCenters.Domain.Classes;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Domain.Classes.Medicines;
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
