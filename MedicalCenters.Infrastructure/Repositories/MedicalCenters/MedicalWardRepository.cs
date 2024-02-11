using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Classes;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Infrastructure.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicalWardRepository : GenericRepository<MedicalWard>, IMedicalWardRepository
    {
        private readonly MedicalCentersDBContext _dBContext;
        public MedicalWardRepository(MedicalCentersDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IList<MedicalWard>> GetAllMedicalCenterWards(long id)
        {
            var Wards = (from medicalCenter in _dBContext.MedicalCenter
                         where medicalCenter.Id == id
                         select medicalCenter.Wards).FirstOrDefault();

            return Wards;
        }

        public async Task<MedicalWardType> GetMedicalWardType(long id)
        {
            var value = await _dBContext.MedicalWardType.FindAsync(id);
            return value;
        }
    }
}
