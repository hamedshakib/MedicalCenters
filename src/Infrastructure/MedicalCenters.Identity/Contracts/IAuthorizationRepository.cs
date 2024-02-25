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
        Task<bool> HasUserPermission(long userId,int permitionId);
        Task<bool> HasUserGroupPermission(long userId, int permitionId);
    }
}
