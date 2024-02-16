using MedicalCenters.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities.Staffs
{
    [Table("Nurse")]
    public class Nurse : Personel
    {
        [Key]
        public long Id { get; set; }
    }
}
