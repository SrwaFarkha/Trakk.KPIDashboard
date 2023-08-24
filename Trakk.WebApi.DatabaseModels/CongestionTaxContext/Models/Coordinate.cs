using System;
using NetTopologySuite.Geometries;

namespace CongestionTaxProcessor;
//
// public class Coordinate : NetTopologySuite.Geometries.Coordinate
// {
//     public double Latitude
//     {
//         get => Y;
//         set => Y = value;
//     }
//
//     public double Longitude
//     {
//         get => X;
//         set => X = value;
//     }
//     
//     public double Distance(Coordinate pos2, bool meters = true)
//     {
//         var km = 6371;
//         var lat = Radians(pos2.Latitude - Latitude);
//         var lng = Radians(pos2.Longitude - Longitude);
//         var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
//                  Math.Cos(Radians(Latitude)) * Math.Cos(Radians(pos2.Latitude)) *
//                  Math.Sin(lng / 2) * Math.Sin(lng / 2);
//         var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
//         return meters ? Math.Round(km * h2 * 1000) : km * h2;
//     }
//     private double Radians(double val)
//     {
//         return Math.PI / 180 * val;
//     }
//
//     public Point ToPoint()
//     {
//         return new(this) { SRID = 4326 };
//     }
// }