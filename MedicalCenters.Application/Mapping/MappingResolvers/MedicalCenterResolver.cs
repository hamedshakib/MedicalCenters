using AutoMapper;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Contracts.Persistence;

namespace MedicalCenters.Application.Mapping.MappingResolvers
{
    internal class MedicalCenterResolver(IMedicalCentersUnitOfWork unitOfWork) : IValueResolver<CreateMedicalWardDto, MedicalWard, MedicalCenter> 
    {
        public MedicalCenter Resolve(CreateMedicalWardDto source, MedicalWard destination, MedicalCenter destMember, ResolutionContext context)
        {
            var dataNullable = unitOfWork.MedicalCenterRepository.Get(source.MedicalCenterId).Result;

            dataNullable = dataNullable ?? throw new ArgumentNullException(nameof(dataNullable));

            return dataNullable;
        }
    }
}
