using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Intermediary
{
    public class Location : Point
    {
        const int GoogleMapSRID = 4326;

        public Location(double latitude, double longitude)
            : base(x: longitude, y: latitude) =>
              base.SRID = GoogleMapSRID;

        public Location(Point point)  
            : base(point.X,point.Y) => base.SRID = GoogleMapSRID;

        [DataMember]
        public double Longitude => base.X;

        [DataMember]
        public double Latitude => base.Y;
    }
}
