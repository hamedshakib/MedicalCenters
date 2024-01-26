using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Classes;
using MedicalCenters.Infrastructure.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Repositories
{
    public class MedicalCenterRepository : GenericRepository<MedicalCenter>, IMedicalCenterRepository
    {
        private readonly MedicalCentersDBContext _dBContext;
        public MedicalCenterRepository(MedicalCentersDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }
    }
}
