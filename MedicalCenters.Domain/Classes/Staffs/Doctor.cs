using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCenters.Domain.Classes.Patients;
using MedicalCenters.Domain.Classes.Oprerations;

namespace MedicalCenters.Domain.Classes.Staffs
{
    [Table("Doctor")]
    public class Doctor : Personel
    {
        public IList<Specialty> Specialties { get; set; }


        public IList<Operation>? Operations { get; set; }
        public IList<PatientHistory>? PatientHistories { get; set; }
        public IList<Visit> Visits { get; set; }
    }
}
