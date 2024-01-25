using MedicalCenters.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Base
{
    public abstract class MedicalStaff : BaseModifiableDomainEntity, IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
