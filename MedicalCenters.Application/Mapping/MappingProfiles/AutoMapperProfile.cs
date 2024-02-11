using AutoMapper;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Mapping.MappingResolvers;
using MedicalCenters.Application.Mapping.MappingResolvers.MappingTypeConverter;
using MedicalCenters.Domain.Classes;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Mapping.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateMedicalCenterDto, MedicalCenter>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom<PointResolver<CreateMedicalCenterDto, MedicalCenter>>())
                    .ReverseMap();

            CreateMap<MedicalCenterDto,MedicalCenter>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom<PointResolver<MedicalCenterDto, MedicalCenter>>())
                    .ReverseMap();


            CreateMap<CreateMedicalWardDto, MedicalWard>()
                    .ReverseMap();

            CreateMap<MedicalWardDto, MedicalWard>()
                    .ReverseMap();
        }
    }
}
