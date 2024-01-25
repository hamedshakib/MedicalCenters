﻿using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    public class Visit : BaseModifiableDomainEntity
    {
        public Sick Sick { get; set; }
        public DateTime DateTime { get; set; }
        public IList<Doctor> Doctors {  get; set; }
    }
}
