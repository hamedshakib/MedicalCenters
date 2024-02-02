using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Oprerations
{
    public class OperationType : BaseCreateableDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
