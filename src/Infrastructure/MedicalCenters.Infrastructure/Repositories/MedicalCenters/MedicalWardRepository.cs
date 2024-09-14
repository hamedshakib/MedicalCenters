using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicalWardRepository(MedicalCentersDBContext _dBContext)
        : GenericRepository<MedicalWard>(_dBContext), IMedicalWardRepository
    {
        private readonly MedicalCentersDBContext _dBContext = _dBContext;

        public async Task<IList<MedicalWard>> GetAllMedicalCenterWardsAsync(long id, CancellationToken cancellationToken = default)
        {

            var wards = await (from ward in _dBContext.MedicalWard
                               where ward.MedicalCenterId == id
                               select ward).ToListAsync(cancellationToken);

            return wards;
        }

        public ValueTask<MedicalWardType?> GetMedicalWardTypeAsync(long id, CancellationToken cancellationToken = default)
        {
            return _dBContext.MedicalWardType.FindAsync(id, cancellationToken);
        }
    }
}
