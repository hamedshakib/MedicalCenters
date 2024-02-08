using AutoMapper;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Mapping.MappingTypeConverter;
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
            //CreateMap<int, MedicalCenterType>().ReverseMap().ConvertUsing(typeof(MedicalCenterType_TypeConverter));
            //CreateMap<MedicalCenter, MedicalCenterDto>().ReverseMap();

            CreateMap<CreateMedicalCenterDto, MedicalCenter>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom<MedicalCenterTypeResolver>())
                    .ForMember(dest => dest.Location , opt => opt.MapFrom<CreateMedicalCenterDto_PointResolver>());
        }
    }
}
