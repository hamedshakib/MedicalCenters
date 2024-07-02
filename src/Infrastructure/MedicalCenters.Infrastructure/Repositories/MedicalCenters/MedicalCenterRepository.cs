using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Infrastructure.Repositories;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicalCenterRepository : GenericRepository<MedicalCenter>, IMedicalCenterRepository
    {
        private readonly MedicalCentersDBContext _dBContext;
        public MedicalCenterRepository(MedicalCentersDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<MedicalCenterType?> GetMedicalCenterType(long id, CancellationToken cancellationToken = default)
        {
            var value = await _dBContext.MedicalCenterType.FindAsync(id, cancellationToken);
            return value;
        }
    }
}
