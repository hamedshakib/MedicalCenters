using MedicalCenters.Domain.Classes;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicalWardRepository : IGenericRepository<MedicalWard>
    {
        Task<MedicalWardType> GetMedicalWardType(long id, CancellationToken cancellationToken = default);
        Task<IList<MedicalWard>> GetAllMedicalCenterWards(long id, CancellationToken cancellationToken=default);
    }
}
