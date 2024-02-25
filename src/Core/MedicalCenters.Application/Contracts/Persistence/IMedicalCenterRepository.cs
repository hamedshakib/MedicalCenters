using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicalCenterRepository : IGenericRepository<MedicalCenter>
    {
        Task<MedicalCenterType> GetMedicalCenterType(long id, CancellationToken cancellationToken = default);
    }
}
