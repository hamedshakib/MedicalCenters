﻿using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Oprerations
{
    public class Operation : BaseModifiableDomainEntity
    {
        public DateTime OperationDT { get; set; }
        public OperationType OperationType { get; set; }
        public IList<Medicine>? Medicines { get; set; }
        public IList<Doctor>? Doctors { get; set; }
    }
}