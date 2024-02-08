using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();

        IMedicalCenterRepository MedicalCenterRepository { get; }
        IMedicalWardRepository MedicalWardRepository { get; }

    }
}
