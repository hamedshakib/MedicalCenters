using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.MedicalCenter_Parts
{
    [Table("MedicalWardType")]
    public class MedicalWardType : BaseCreateableDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
