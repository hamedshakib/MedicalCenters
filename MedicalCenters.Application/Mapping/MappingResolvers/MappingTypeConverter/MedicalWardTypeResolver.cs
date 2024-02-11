using AutoMapper;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Domain.Classes;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalWard;

namespace MedicalCenters.Application.Mapping.MappingResolvers.MappingTypeConverter
{
    internal class MedicalWardTypeResolver<T>(IMedicalCentersUnitOfWork unitOfWork) : IValueResolver<T, MedicalWard, MedicalWardType>
        where T : IMedicalWardDto
    {
        public MedicalWardType Resolve(T source, MedicalWard destination, MedicalWardType destMember, ResolutionContext context)
        {
            var dataNullable = unitOfWork.MedicalWardRepository.GetMedicalWardType(source.Type).Result;

            dataNullable = dataNullable ?? throw new ArgumentNullException(nameof(dataNullable));

            return dataNullable;
        }
    }
}
