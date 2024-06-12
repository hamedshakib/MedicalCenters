using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
    }
}
