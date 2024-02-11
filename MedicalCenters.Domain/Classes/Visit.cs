﻿using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Patients;
using MedicalCenters.Domain.Classes.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    [Table("Visit")]
    public class Visit : BaseModifiableDomainEntity
    {
        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get; set; }
        public IList<Doctor> Doctors {  get; set; }
        public long? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
