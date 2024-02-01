using AutoMapper;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MedicalCenter,MedicalCenterDto>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<MedicalCenter,CreateMedicalCenterDto>().ReverseMap();
        }
    }
}
