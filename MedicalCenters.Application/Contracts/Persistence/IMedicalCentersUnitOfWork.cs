using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicalCentersUnitOfWork : IDisposable
    {
        Task Save();

        IMedicalCenterRepository MedicalCenterRepository { get; }
        IMedicalWardRepository MedicalWardRepository { get; }
        IMedicineRepository MedicineRepository { get; }

    }
}
