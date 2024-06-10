using MedicalCenters.Domain.Entities.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
    }
}
