using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Domain.Entities.Persons;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class PatientRepository(MedicalCentersDBContext dBContext)
        : GenericRepository<Patient>(dBContext), IPatientRepository
    {

    }
}
