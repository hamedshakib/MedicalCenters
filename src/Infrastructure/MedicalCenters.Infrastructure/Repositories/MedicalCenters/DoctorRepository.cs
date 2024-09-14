using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.Persons.Staffs;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class DoctorRepository(MedicalCentersDBContext _dBContext)
        : GenericRepository<Doctor>(_dBContext), IDoctorRepository
    {
    }
}
