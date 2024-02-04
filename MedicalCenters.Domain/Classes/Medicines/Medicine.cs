using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Medicines
{
    [Table("Medicine")]
    public class Medicine : BaseModifiableDomainEntity
    {
        public string Name { get; set; }
        public MedicineType Type { get; set; }
    }
}
