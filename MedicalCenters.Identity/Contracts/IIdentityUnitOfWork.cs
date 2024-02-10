using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Contracts
{
    public interface IIdentityUnitOfWork
    {
        Task Save();

        IAthenticationRepository AthenticationRepository { get; }
    }
}
