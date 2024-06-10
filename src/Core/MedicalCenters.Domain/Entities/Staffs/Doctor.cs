﻿using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Staffs
{
    [Table("Doctor")]
    public class Doctor : Personnel
    {
        [Key]
        public long Id { get; set; }
    }
}
