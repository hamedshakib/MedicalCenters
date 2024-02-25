using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCenters.Domain.Entities.Patients;
using MedicalCenters.Domain.Entities.Oprerations;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Entities.Staffs
{
    [Table("Doctor")]
    public class Doctor : Personel
    {
        [Key]
        public long Id { get; set; }
    }
}
