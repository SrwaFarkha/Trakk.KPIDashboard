using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using Trakk.Utils.Extensions.EnumerableExtensions;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;
using Trakk.WebApi.Models;
using Position = Trakk.WebApi.DatabaseModels.Models.Position;

namespace Trakk.WebApi.DatabaseModels.Helpers;

public static class GeometryExtensions
{
    public static FeatureCollection ToFeatureCollection(this IEnumerable<Position> positions)
    {
        var featureCollection = new FeatureCollection();
        foreach (var position in positions)
            featureCollection.Add(new Feature(position.ToGeometry(), new AttributesTable()));

        return featureCollection;
    }
    public static LineString ToLineString(this IEnumerable<Position> positions)
    {
        return new LineString(positions.Select(x => x.ToCoordinate()).ToArray());
    }

    public static Feature ToFeature(this Geometry geometry, KnownColor? stroke = null, params (string key, object value)[] additionalProps)
    {
        var attributes = new AttributesTable();
        if (stroke != null)
            attributes.Add("marker-color",stroke.ToString() );
        
        foreach (var additional in additionalProps)
        {
            attributes.Add(additional.key, additional.value);
        }
        return new Feature(geometry, attributes);
    }
    public static Feature ToFeature(this LineSegment ls, KnownColor stroke, double width = 2, double opacity = 1) =>
        ToFeature(new LineString(new[] { ls.P0, ls.P1 }), stroke, width, opacity);
    public static Feature? ToFeature(this LineString ls, KnownColor stroke, double width = 2, double opacity = 1)
    {
        if (ls.Coordinates.Length > 1)
        {
            return new Feature(ls, new AttributesTable
            {
                {"stroke", stroke.ToString()},
                {"stroke-width", width},
                {"stroke-opacity", opacity}
            });
        }

        return null;
    }
    
    public static Polygon ToCircle(this Coordinate center, double radiusInMeters, int numberOfPoints = 32)
    {
        var earthRadius = 6378137; // Earth's radius in meters
        var lat = center.Y * Math.PI / 180; // convert latitude to radians
        var lng = center.X * Math.PI / 180; // convert longitude to radians

        var d = radiusInMeters / earthRadius; // angular distance covered on earth's surface
        var points = new Coordinate[numberOfPoints + 1];
        for (var i = 0; i < numberOfPoints; i++)
        {
            var theta = 2 * Math.PI * i / numberOfPoints;
            var pointLat = Math.Asin(Math.Sin(lat) * Math.Cos(d) + Math.Cos(lat) * Math.Sin(d) * Math.Cos(theta));
            var pointLng = lng + Math.Atan2(Math.Sin(theta) * Math.Sin(d) * Math.Cos(lat), Math.Cos(d) - Math.Sin(lat) * Math.Sin(pointLat));
            points[i] = new Coordinate(pointLng * 180 / Math.PI, pointLat * 180 / Math.PI);
        }
        points[numberOfPoints] = points[0];

        return new Polygon(new LinearRing(points));
    }
    public static string ToGeoJsonString(this FeatureCollection collection) => new GeoJsonWriter().Write(collection);

    public static double Distance2(this Coordinate src, Coordinate pos2, bool meters = true)
    {
        var km =  6371;
        var lat = Radians((pos2.Y - src.Y));
        var lng = Radians((pos2.X - src.X));
        var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                 Math.Cos(Radians(src.Y)) * Math.Cos(Radians(pos2.Y)) *
                 Math.Sin(lng / 2) * Math.Sin(lng / 2);
            
        var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            
        return meters ? Math.Round((km * h2) * 1000) : km * h2;
    }

    private static double Radians(double degree)
    {
        return (Math.PI / 180) * (double)degree;
    }
    public static ICollection<Feature> ToFeatureCollection(this VehicleEvent ev, KnownColor stroke, double width = 2, double opacity = 1)
    {
        var collection = new List<Feature>();
        if (ev.PositionCount > 1)
        {
            collection.Add(ev.Positions.FirstOrDefault().Position.ToGeometry().ToFeature(stroke));
            collection.Add(ev.Positions.Select(x => x.Position).ToLineString().ToFeature(stroke, width, opacity));
        }
        else
        {
            collection.AddRange(ev.Positions.Select(x => x.Position.ToGeometry().ToFeature(stroke)));
        }

        return collection;
    }
    
    public static ICollection<Feature> ToFeatures(this VehicleEvent ev)
    {
        var collection = new List<Feature>();
        var color = ev is StopEvent ? KnownColor.Red : KnownColor.Black;
        var positions = ev.Positions.OrderBy(x =>x.TimeStamp).ToList();
        if (positions.Count > 1)
        {
            collection.Add(positions.First().Position.ToGeometry().ToFeature(color, ("marker-size", "medium"),("marker-symbol", "car")));
            collection.Add(positions.Select(x => x.Position).ToLineString().ToFeature(color, 2, 1));
        }
        else
        {
            collection.AddRange(positions.Select(x => x.Position.ToGeometry().ToFeature(color, 
                ("marker-size", "medium"), ("marker-symbol", "parking") )));
        }

        return collection;
    }
    
    public static ICollection<Feature> ToTripFeature(this TripEvent ev)
    {
        var collection = new List<Feature>();
      
        var start = ev.PreviousStop.StopPosition;
        var stop = ev.NextStop.StopPosition;
        var positions = new List<Position>();
        if (start != null)
            positions.Add(start);
        
        positions.AddRange(ev.Positions.OrderBy(x => x.TimeStamp).Select(x => x.Position));
        if (stop != null)
            positions.Add(stop);
        if (positions.Count > 1)
            collection.Add(positions.ToLineString().ToFeature(KnownColor.Black));
        
        if (stop != null)
            collection.Add(stop.ToGeometry().ToFeature(KnownColor.Red));

        return collection;
    }


    public static string ToGeoJsonString(this Feature feature, bool asFeatureCollection = false)
    {
        var writer = new GeoJsonWriter();
        return writer.Write(asFeatureCollection ? ToFeatureCollection(new[] { feature }) : feature);
    }

    public static FeatureCollection ToTripFeatures(this IEnumerable<VehicleEvent> vehicleEvents)
    {
        var data = new FeatureCollection();
        var trips = vehicleEvents.Where(x => x.Type == Enums.VehicleEventType_V2.Trip).OrderBy(x =>x.StartTime).Cast<TripEvent>();
        foreach (var trip in trips)
        {
            foreach (var f in trip.ToTripFeature())
            {
                data.Add(f);
            }
        }

        return data;
    }

    public static List<Feature> ToTripFeatures(this TripEvent trip)
    {
        var data = new List<Feature>();
        if(trip.Previous == null) Console.WriteLine($"prev was null : {trip.Id}");
        if (trip.PreviousStop.StopPosition != null)
            data.Add(trip.PreviousStop.StopPosition.ToGeometry().ToFeature(KnownColor.Black));
        if (trip.NextStop.StopPosition != null)
            data.Add(trip.NextStop.StopPosition.ToGeometry().ToFeature(KnownColor.Red));
        if (trip.Positions.Count > 1)
            data.Add(new LineString(trip.Positions.OrderBy(x => x.TimeStamp)
                    .Select(x => x.Position.ToCoordinate())
                    .ToArray())
                .ToFeature(KnownColor.Black));

        return data;

    }
    public static ICollection<Feature> ToFeatures(this IEnumerable<VehicleEvent> evs)
    {
        var collection = new List<Feature>();
        foreach (var ev in evs)
        {
            if (ev is TripEvent trip)
            {
                if (trip.Route != null)
                {
                    collection.Add(trip.Route.GetFullPath().ToFeature(trip.Valid ? KnownColor.Black : KnownColor.Red));
                    var simple = trip.Simplify().Select(x => x.coordinate).ToArray();

                    if (simple.Length > 1)
                    {
                        var l2 = new LineString(simple);
                        collection.Add(l2.ToFeature(KnownColor.Blue, 8));
                    }
                        
                }
                else
                {
                    var l2 = trip.GetPositionsWithStartAndStop().ToLineString();
                    if (l2.Coordinates.Length > 1 )
                        collection.Add(l2.ToFeature(trip.Valid ? KnownColor.Black : KnownColor.Red));
                }

            }

            if (ev is StopEvent stop)
                collection.Add(stop.StopPosition?.ToGeometry().ToFeature(KnownColor.Red));
            

            //collection.AddRange(new []{start.ToFeature(KnownColor.Black), stop.ToFeature(KnownColor.Black), line.ToFeature(KnownColor.Black)});
        }

        return collection;
    }

    public static FeatureCollection ToFeatureCollection(this IEnumerable<Feature> src)
    {
        var collection = new FeatureCollection();
        foreach (var f in src.Where(x => x.Geometry != null))
        {
            collection.Add(f);
        }

        return collection;
    }

    public static ICollection<Feature> ToFeatureCollection(this TripEvent ev)
    {
        var collection = new List<Feature>();
        var color = KnownColor.Black;
        var positions = new List<Position>();
        if (ev.PreviousStop != null)
            positions.Add(ev.PreviousStop.StopPosition);
        if (ev.Positions.Any())
            positions.AddRange(ev.Positions.Select(x => x.Position));
        if (ev.NextStop != null)
            positions.Add(ev.NextStop.StopPosition);

        collection.Add(positions.FirstOrDefault()?.ToGeometry().ToFeature(color, ("marker-size", "medium"),("marker-symbol", "car")));

        if (positions.Count > 1 )
        {
            collection.Add(positions.ToLineString().ToFeature(color, 2, 1));
        }
        collection.Add(positions.LastOrDefault()?.ToGeometry().ToFeature(color, ("marker-size", "medium"),("marker-symbol", "car")));


        return collection;
    }

    public static Coordinate GetClosestPoint(this LineString line, Coordinate point)
    {
        var lineStart = line.StartPoint;
        var lineEnd = line.EndPoint;
        var startToPoint = new Coordinate( point.X - lineStart.X,  point.Y - lineStart.Y); 
        var startToEnd = new Coordinate(lineEnd.X - lineStart.X,lineEnd.Y - lineStart.Y );

        var x = startToEnd.X * startToEnd.X + startToEnd.Y * startToEnd.Y;
        var y = startToPoint.X * startToEnd.X + startToPoint.Y * startToEnd.Y;
        var z = y / x;  //  # The normalized "distance" from a to the closest point
        if (z > 1) z = 1; if (z < 0) z = 0;
        return new Coordinate(lineStart.X + startToEnd.X * z, lineStart.Y + startToEnd.Y * z);
    }
    
    
    public static LineString Simplify(this LineString ls, double inflection_threshold_degrees = 45)
    {
        return new LineString(ls.Coordinates.Simplify(inflection_threshold_degrees).ToArray());
    }
    public static IEnumerable<Coordinate> Simplify(this IEnumerable<Coordinate> coordinates, double inflection_threshold_degrees = 45)
    {
        return coordinates.Reduce((p0, p1, p2) =>
        {
            var p0p1 = Math.Pow(p1[0] - p0[0], 2) + Math.Pow(p1[1] - p0[1], 2);
            var p2p1 = Math.Pow(p1[0] - p2[0], 2) + Math.Pow(p1[1] - p2[1], 2);
            var p0p2 = Math.Pow(p2[0] - p0[0], 2) + Math.Pow(p2[1] - p0[1], 2);
            var angle = Math.Acos((p2p1 + p0p1 - p0p2) / Math.Sqrt(4 * p2p1 * p0p1)) * 180 / Math.PI;
            var degrees = Math.Abs(180 - angle);
            return degrees > inflection_threshold_degrees;
        });
    }

    public static string GetGoogleMapsLink(this Coordinate fromCoordinate , Coordinate? toCoordinate)
    {
        var fromLatString = fromCoordinate.Y.ToString().Replace(',', '.');
        var fromLngString = fromCoordinate.X.ToString().Replace(',', '.');
        var toLatString = toCoordinate?.Y.ToString().Replace(',', '.');
        var toLngString = toCoordinate?.X.ToString().Replace(',', '.');

        var googleMapsLink = toCoordinate != null
            ? $"https://www.google.com/maps/dir/{fromLatString},{fromLngString}/{toLatString},{toLngString}/@{fromLatString},{fromLngString},14.6z/data=!3m1!4b1!4m2!4m1!3e0"
            : $"https://www.google.com/maps/dir/{fromLatString},{fromLngString}/@{fromLatString},{fromLngString},14.6z/data=!3m1!4b1!4m2!4m1!3e0";

        return googleMapsLink;
    }

    public static string GetGoogleMapsLink(this Position fromCoordinate, Position? toCoordinate)
    {
        return GetGoogleMapsLink(fromCoordinate.ToCoordinate(), toCoordinate.ToCoordinate());
    }
    public static string GetGoogleMapsLink(this EventPosition fromCoordinate, EventPosition? toCoordinate)
    {
        return GetGoogleMapsLink(fromCoordinate.Position.ToCoordinate(), toCoordinate.Position.ToCoordinate());
    }

}