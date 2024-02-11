using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Classes.Base;

namespace MedicalCenters.Domain.Classes.Patients
{
    [Table("Patient")]
    public class Patient : Person
    {
    }
}
