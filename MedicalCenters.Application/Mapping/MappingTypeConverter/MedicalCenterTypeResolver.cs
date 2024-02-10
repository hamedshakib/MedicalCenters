using AutoMapper;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Domain.Classes;
using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalCenters.Application.Mapping.MappingTypeConverter
{
    internal class MedicalCenterTypeResolver<T>(IMedicalCentersUnitOfWork unitOfWork) : IValueResolver<T, MedicalCenter, MedicalCenterType>
        where T : IMedicalCenterDto
    {
        public MedicalCenterType Resolve(T source, MedicalCenter destination, MedicalCenterType destMember, ResolutionContext context)
        {
            var dataNullable = unitOfWork.MedicalCenterRepository.GetMedicalCenterType(source.Type).Result;

            dataNullable = dataNullable ?? throw new ArgumentNullException(nameof(dataNullable));

            return (MedicalCenterType)dataNullable;
        }
    }
}
