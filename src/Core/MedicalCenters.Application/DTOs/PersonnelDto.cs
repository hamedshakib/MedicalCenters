using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs
{
    public abstract record PersonnelDto : PersonDto
    {
        public string PersonnelCode { get; set; }
    }
}
