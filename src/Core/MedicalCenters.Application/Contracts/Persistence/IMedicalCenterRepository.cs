using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicalCenterRepository : IGenericRepository<MedicalCenter>
    {
        Task<MedicalCenterType> GetMedicalCenterType(long id, CancellationToken cancellationToken = default);
    }
}
