using System;
using System.Globalization;
using NetTopologySuite.Geometries;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;
using Position = Trakk.WebApi.DatabaseModels.Models.Position;

namespace Trakk.WebApi.DatabaseModels.Helpers
{

    public struct Angle
    {
        public double Value { get; set; }

        public Angle(double value)
        {
            Value = value;
        }

        public double Difference(Angle other)
        {
            var diff = Math.Abs(Value - other.Value) % 360;
            return diff > 180 ? 360 - diff : diff;
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
    public static class DecimalExtensions
    {
        private static double ConvertDegreesToRadians(double angle) => Math.PI * angle / 180.0;

        private static double ConvertRadiansToDegrees(double angle) => 180.0 * angle / Math.PI;

        private static (double latitude, double longitude) ToRadians(this Coordinate coordinate) => 
            (ConvertDegreesToRadians(coordinate.Y), ConvertDegreesToRadians(coordinate.X));
        private static (double latitude, double longitude) ToRadians(this Position coordinate) => 
            (ConvertDegreesToRadians((double)coordinate.Latitude), ConvertDegreesToRadians((double)coordinate.Longitude));

        public static Angle GetAngle(this Coordinate position1, Coordinate position2)
        {
            var coord1 = position1.ToRadians();
            var coord2 = position2.ToRadians();

            return GetAngle(coord1.latitude, coord1.longitude, coord2.latitude, coord2.longitude);
        }
        
        public static Angle GetAngle(this Position position1, Position position2)
        {
            var coord1 = position1.ToRadians();
            var coord2 = position2.ToRadians();

            return GetAngle(coord1.latitude, coord1.longitude, coord2.latitude, coord2.longitude);
        }
        public static Angle GetAngle(this EventPosition position1, EventPosition position2)
        {
            var coord1 = position1.Position.ToRadians();
            var coord2 = position2.Position.ToRadians();

            return GetAngle(coord1.latitude, coord1.longitude, coord2.latitude, coord2.longitude);
        }
        public static Angle GetAngle(this EventPosition position1, Coordinate position2)
        {
            var coord1 = position1.Position.ToRadians();
            var coord2 = position2.ToRadians();

            return GetAngle(coord1.latitude, coord1.longitude, coord2.latitude, coord2.longitude);
        }
        
        private static Angle GetAngle(double lat1, double lng1, double lat2, double lng2)
        {
            var dLon = lng1 - lng2;
            var y = Math.Sin(dLon) * Math.Cos(lat2);
            var x = Math.Cos(lat1) 
                    * Math.Sin(lat2) 
                    - Math.Sin(lat1) 
                    * Math.Cos(lat2) 
                    * Math.Cos(dLon);
            var brng = Math.Atan2(y, x);

            return new Angle((ConvertRadiansToDegrees(brng) + 360) % 360);
        }
    }
}