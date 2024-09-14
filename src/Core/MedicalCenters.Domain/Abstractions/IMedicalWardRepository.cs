using MedicalCenters.Domain.Entities.MedicalCenter_Parts;

namespace MedicalCenters.Domain.Abstractions
{
    public interface IMedicalWardRepository : IGenericRepository<MedicalWard>
    {
        ValueTask<MedicalWardType?> GetMedicalWardTypeAsync(long id, CancellationToken cancellationToken = default);
        Task<IList<MedicalWard>> GetAllMedicalCenterWardsAsync(long id, CancellationToken cancellationToken = default);
    }
}
