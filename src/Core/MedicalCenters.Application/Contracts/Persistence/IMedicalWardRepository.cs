using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicalWardRepository : IGenericRepository<MedicalWard>
    {
        Task<MedicalWardType> GetMedicalWardType(long id, CancellationToken cancellationToken = default);
        Task<IList<MedicalWard>> GetAllMedicalCenterWards(long id, CancellationToken cancellationToken = default);
    }
}
