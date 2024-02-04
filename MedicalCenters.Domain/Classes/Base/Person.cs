using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Base
{
    public abstract class Person : BaseModifiableDomainEntity
    {
        [Required,StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        string nationalCode;
        [Required,StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string NationalCode { get; set; }
    }
}
