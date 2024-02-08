using AutoMapper;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using MedicalCenters.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace MedicalCenters.Application.Mapping.MappingTypeConverter
{
    internal class CreateMedicalCenterDto_PointResolver : IValueResolver<CreateMedicalCenterDto, MedicalCenter, Point>
    {
        public Point Resolve(CreateMedicalCenterDto source, MedicalCenter destination, Point destMember, ResolutionContext context)
        {
            return new Point(source.GPSx, source.GPSy)
            {
                SRID = 4326
            };
        }
    }

    //internal class UpdateMedicalCenterDto_PointResolver : IValueResolver<UpdateMedicalCenterDto, MedicalCenter, Point>
    //{
    //    public Point Resolve(UpdateMedicalCenterDto source, MedicalCenter destination, Point destMember, ResolutionContext context)
    //    {
    //        return new Point(source.GPSx, source.GPSy)
    //        {
    //            SRID = 4326
    //        };
    //    }
    //}

}
