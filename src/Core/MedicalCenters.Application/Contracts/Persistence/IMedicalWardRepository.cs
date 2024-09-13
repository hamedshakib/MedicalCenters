using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicalWardRepository : IGenericRepository<MedicalWard>
    {
        ValueTask<MedicalWardType?> GetMedicalWardTypeAsync(long id, CancellationToken cancellationToken = default);
        Task<IList<MedicalWard>> GetAllMedicalCenterWardsAsync(long id, CancellationToken cancellationToken = default);
    }
}
