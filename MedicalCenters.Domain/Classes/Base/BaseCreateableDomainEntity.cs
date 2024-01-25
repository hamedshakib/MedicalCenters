using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Base
{
    public abstract class BaseCreateableDomainEntity : BaseDomainEntity
    {
        public DateTime? DateTimeCreated { get; set; }
        public long CreatedBy { get; set; }
    }
}
