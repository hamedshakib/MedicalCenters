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

namespace MedicalCenters.Application.Mapping.MappingResolvers.MappingTypeConverter
{
    internal class PointResolver<T, Y> : IValueResolver<T, Y, Point>
        where T : IMedicalCenterDto
    {
        public Point Resolve(T source, Y destination, Point destMember, ResolutionContext context)
        {
            return new Point(source.GPSx, source.GPSy)
            {
                SRID = 4326
            };
        }
    }

    internal class GPSxResolver<T, Y> : IValueResolver<T, Y, double>
    where T : IMedicalCenterDto
    {
        double IValueResolver<T, Y, double>.Resolve(T source, Y destination, double destMember, ResolutionContext context)
        {
            return source.GPSx;
        }
    }
}
