using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Specialties
{
    public class SpecialtyGroup : BaseCreateableDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
