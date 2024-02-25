using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class BaseUser : BaseCreateableDomainEntity
    {
        [Required, StringLength(100)]
        public string UserName { get; set; }
    }
}
