using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Contracts
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        Task Save();

        IAthenticationRepository AthenticationRepository { get; }
    }
}
