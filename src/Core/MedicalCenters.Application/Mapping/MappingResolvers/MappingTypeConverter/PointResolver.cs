using AutoMapper;
using MedicalCenters.Application.DTOs;
using NetTopologySuite.Geometries;

namespace MedicalCenters.Application.Mapping.MappingResolvers.MappingTypeConverter
{
    internal class PointResolver<T, Y> : IValueResolver<T, Y, Point>
        where T : MedicalCenterDto
    {
        public Point? Resolve(T source, Y destination, Point destMember, ResolutionContext context)
        {
            if(source.GPSx is null || source.GPSy is null)
                return null;
            return new Point(source.GPSx.Value, source.GPSy.Value)
            {
                SRID = 4326
            };
        }
    }
}
