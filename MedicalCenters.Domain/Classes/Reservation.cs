﻿using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    [Table("Reservation")]
    public class Reservation : BaseModifiableDomainEntity
    {
        public DateTime ReservationDT { get; set; }
        public Patient Patient { get; set; }

    }
}
