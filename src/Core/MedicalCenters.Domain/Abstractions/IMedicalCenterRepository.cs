using MedicalCenters.Domain.Entities.MedicalCenter_Parts;

namespace MedicalCenters.Domain.Abstractions
{
    public interface IMedicalCenterRepository : IGenericRepository<MedicalCenter>
    {
        ValueTask<MedicalCenterType?> GetMedicalCenterTypeAsync(long id, CancellationToken cancellationToken = default);
    }
}
