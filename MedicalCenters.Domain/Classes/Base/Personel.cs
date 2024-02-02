using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Base
{
    public abstract class Personel : Person
    {
        public string PersonnelCode { get; set; }
    }
}
