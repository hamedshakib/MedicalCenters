﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCenters.Domain.Entities.Base;
using NetTopologySuite.Geometries;

namespace MedicalCenters.Domain.Entities.MedicalCenter_Parts
{
    [Table(nameof(MedicalCenter))]
    public class MedicalCenter : BaseModifiableDomainEntity
    {
        public new const string EntityTitle = "مرکز درمانی";


        [Key]
        public int Id { get; set; }
        [Required, MaxLength(70)]
        public string Name { get; set; }
        [Required]
        public int TypeId { get; set; }
        public MedicalCenterType Type { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public Point? Location { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
