using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Base
{
    public abstract class BaseUser : BaseCreateableDomainEntity
    {
        public string UserName { get; set; }
    }
}
