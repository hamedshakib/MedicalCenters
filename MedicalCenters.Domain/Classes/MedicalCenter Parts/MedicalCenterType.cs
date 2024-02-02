using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.MedicalCenter_Parts
{
    public class MedicalCenterType : BaseCreateableDomainEntity
    {
        string Name { get; set; }
    }
}
