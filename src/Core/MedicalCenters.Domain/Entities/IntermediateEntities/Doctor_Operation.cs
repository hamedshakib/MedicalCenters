﻿using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Oprerations;
using MedicalCenters.Domain.Entities.Persons.Staffs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Entities.IntermediateEntities
{
    [PrimaryKey(nameof(DoctorId), nameof(OperationId))]
    public class Doctor_Operation : BaseCreateableDomainEntity
    {
        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public long OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
