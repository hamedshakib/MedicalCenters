﻿using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Persons.Staffs
{
    [Table(nameof(Nurse))]
    public class Nurse : Personnel
    {
        public new const string EntityTitle = "پرستار";
    }
}
