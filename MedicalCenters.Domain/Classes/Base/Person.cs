using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Base
{
    public abstract class Person : BaseModifiableDomainEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string NationalCode { get; set; }
    }
}
