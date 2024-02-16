using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Entities.Base;

namespace MedicalCenters.Domain.Entities.Patients
{
    [Table("Patient")]
    public class Patient : Person
    {
        [Key]
        public long Id { get; set; }
    }
}
