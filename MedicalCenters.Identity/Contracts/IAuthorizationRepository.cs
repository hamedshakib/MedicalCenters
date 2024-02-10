using MedicalCenters.Identity.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Contracts
{
    public interface IAuthorizationRepository
    {
        Task<bool> HasUserPermition(long userId,int permitionId);
        Task<bool> HasUserGroupPermition(long userId, int permitionId);
    }
}
