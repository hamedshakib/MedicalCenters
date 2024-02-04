﻿using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Medicines
{
    [Table("MedicineType")]
    public class MedicineType : BaseCreateableDomainEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }

        public IList<Allergy> Allergies { get; set; }
    }
}
