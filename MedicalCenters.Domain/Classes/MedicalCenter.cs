using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    public class MedicalCenter : BaseModifiableDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<MedicalDepartment> Departments { get; set; }
    }
}
