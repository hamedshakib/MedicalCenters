using AutoMapper;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Mapping.MappingResolvers;
using MedicalCenters.Application.Mapping.MappingResolvers.MappingTypeConverter;
using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using MedicalCenters.Domain.Entities.Medicines;
using NetTopologySuite.Geometries;
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
                    .ForMember(dest => dest.Location, opt => opt.MapFrom<PointResolver<CreateMedicalCenterDto, MedicalCenter>>());
            CreateMap<MedicalCenter, CreateMedicalCenterDto>()
                    .ForMember(dest => dest.GPSx, opt => opt.MapFrom(src => src.Location.X))
                    .ForMember(dest => dest.GPSy, opt => opt.MapFrom(src => src.Location.Y));


            CreateMap<MedicalCenterDto, MedicalCenter>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom<PointResolver<MedicalCenterDto, MedicalCenter>>());
            CreateMap<MedicalCenter, MedicalCenterDto>()
                    .ForMember(dest => dest.GPSx, opt => opt.MapFrom(src => src.Location.X))
                    .ForMember(dest => dest.GPSy, opt => opt.MapFrom(src => src.Location.Y));





            CreateMap<CreateMedicalWardDto, MedicalWard>()
                    .ReverseMap();

            CreateMap<MedicalWardDto, MedicalWard>()
                    .ReverseMap();

            CreateMap<CreateMedicineDto, Medicine>()
                    .ReverseMap();

            CreateMap<MedicineDto, Medicine>()
                    .ReverseMap();
        }
    }
}
