using AutoMapper;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Mapping.MappingResolvers.MappingTypeConverter;
using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.Medicines;

namespace MedicalCenters.Application.Mapping.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MedicalCenterDto, MedicalCenter>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom<PointResolver<MedicalCenterDto, MedicalCenter>>());
            CreateMap<MedicalCenter, MedicalCenterDto>()
                    .ForMember(dest => dest.GPSx, opt => opt.MapFrom(src => src.Location.X))
                    .ForMember(dest => dest.GPSy, opt => opt.MapFrom(src => src.Location.Y));


            CreateMap<MedicalCenterDto, MedicalCenter>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom<PointResolver<MedicalCenterDto, MedicalCenter>>());
            CreateMap<MedicalCenter, MedicalCenterDto>()
                    .ForMember(dest => dest.GPSx, opt => opt.MapFrom(src => src.Location.X))
                    .ForMember(dest => dest.GPSy, opt => opt.MapFrom(src => src.Location.Y));





            CreateMap<MedicalWardDto, MedicalWard>()
                    .ReverseMap();

            CreateMap<MedicalWardDto, MedicalWard>()
                    .ReverseMap();

            CreateMap<MedicineDto, Medicine>()
                    .ReverseMap();

            CreateMap<MedicineDto, Medicine>()
                    .ReverseMap();
        }
    }
}
