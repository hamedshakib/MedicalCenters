using AutoMapper;
using MedicalCenters.Application.DTOs.MedicalCenter;
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
}
