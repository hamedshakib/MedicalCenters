﻿using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Oprerations
{
    [Table("OperationType")]
    public class OperationType : BaseCreateableDomainEntity
    {
        public const string EntityTitle = "نوع عمل";

        [Key]
        public int Id { get; set; }
        [Required, StringLength(70)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
