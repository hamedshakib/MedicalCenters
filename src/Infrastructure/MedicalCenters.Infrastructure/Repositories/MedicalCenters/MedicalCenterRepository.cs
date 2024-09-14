using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Infrastructure.Repositories;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicalCenterRepository(MedicalCentersDBContext _dBContext)
        : GenericRepository<MedicalCenter>(_dBContext), IMedicalCenterRepository
    {
        private readonly MedicalCentersDBContext _dBContext = _dBContext;

        public ValueTask<MedicalCenterType?> GetMedicalCenterTypeAsync(long id, CancellationToken cancellationToken = default)
        {
            return _dBContext.MedicalCenterType.FindAsync(id, cancellationToken);
        }
    }
}
