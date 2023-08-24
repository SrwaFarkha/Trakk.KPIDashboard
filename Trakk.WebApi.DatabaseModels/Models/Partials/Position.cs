using System;
using NetTopologySuite.Geometries;

namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class Position
    {
        public Position(int positionId, decimal longitude, decimal latitude) : this()
        {
            PositionId = positionId;
            Longitude = longitude;
            Latitude = latitude;
        }

        public Point ToGeometry()
        {
            var factory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory();

            return factory.CreatePoint(new Coordinate((double)Longitude,(double)Latitude));
        }
        public Coordinate ToCoordinate()
        {
            return new Coordinate((double)Longitude,(double)Latitude);
        }
        public double Distance2(Position point2)
        {
            var d1 = decimal.ToDouble(Latitude) * (Math.PI / 180.0);
            var num1 = decimal.ToDouble(Longitude) * (Math.PI / 180.0);
            var d2 = decimal.ToDouble(point2.Latitude) * (Math.PI / 180.0);
            var num2 = decimal.ToDouble(point2.Longitude) * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
        
        public double Distance(Position pos2, bool meters = true)
        {
            var km =  6371;
            var lat = Radians((pos2.Latitude - this.Latitude));
            var lng = Radians((pos2.Longitude - this.Longitude));
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                     Math.Cos(Radians(this.Latitude)) * Math.Cos(Radians(pos2.Latitude)) *
                     Math.Sin(lng / 2) * Math.Sin(lng / 2);
            
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            
            return meters ? Math.Round((km * h2) * 1000) : km * h2;
        }
        private double Radians(decimal val)
        {
            return (Math.PI / 180) * (double)val;
        }
        public string ToLabel()
        {
            return !string.IsNullOrEmpty(GeocodedPosition?.ToLabel())? GeocodedPosition?.ToLabel() : $"{Longitude} {Latitude}";
        }
    }
}