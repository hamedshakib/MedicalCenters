using MedicalCenters.Domain.Entities;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Identity.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Contracts
{
    public interface IAthenticationRepository
    {
        Task<User?> FindUser(string Username);
    }
}
