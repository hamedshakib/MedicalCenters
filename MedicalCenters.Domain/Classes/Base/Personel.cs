using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Base
{
    public abstract class Personel : Person
    {
        [Required,StringLength(50)]
        public string PersonnelCode { get; set; }
    }
}
