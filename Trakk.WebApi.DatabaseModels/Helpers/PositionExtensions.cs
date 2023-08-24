using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trakk.Utils.Extensions.EnumerableExtensions;
using Trakk.Utils.Extensions.StringExtensions;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;
using Point = NetTopologySuite.Geometries.Point;
using Position = Trakk.WebApi.DatabaseModels.Models.Position;

namespace Trakk.WebApi.DatabaseModels.Helpers;

public static class PositionExtensions
{

    /// <summary>
    /// For copying data to TestData. 
    /// </summary>
    public static string PrintAsTripRecord(this VehicleEvent vehicleEvent, string recordName = "Placeholder", params Geofence[] fences)
    {

        var positions = vehicleEvent switch
        {
            TripEvent trip => trip.GetEventPositionsWithStartAndStop(),
            _ => vehicleEvent.Positions.OrderBy(x => x.TimeStamp).ToList()
        };
        return PrintAsTripRecord(positions, recordName, fences);
    }
    /// <summary>
    /// For copying data to TestData. 
    /// </summary>
    public static string PrintAsTripRecord(this IEnumerable<EventPosition> positions, string recordName = "Placeholder", params Geofence[] fences)
    {
        
        var variable = $"public static TripRecord {recordName} => new TripRecord()";
        variable = positions.Aggregate(variable, (current, pos) => current +
                                                                   $"\n         .Add({pos.Position.Latitude.ToString(CultureInfo.InvariantCulture)}, " +
                                                                   $"{pos.Position.Longitude.ToString(CultureInfo.InvariantCulture)}, " +
                                                                   $"DateTime.Parse(\"{pos.TimeStamp:u}\"))");
        foreach (var geofence in fences)
        {
            //variable +=
            //    $"\n.AddGeofence(\"{geofence.Name}\", {geofence.GeofenceTypeId}, \"{geofence.GetGeometry().ToFeature().ToGeoJsonString().MakeCodeCopySafe()}\")";
            variable +=
                $"\n.AddGeofence(\"{geofence.ToTestJson().MakeCodeCopySafe()}\")";
        }
        variable += ";";

        return variable;
    }


    public static string ToTestJson(this Geofence geofence)
    {
        geofence.Customer = null;
        geofence.GeofenceEvents = new List<GeofenceEvent>();
        geofence.Contacts = new List<Contact>();
        geofence.Groups = new List<Group>();
        geofence.Trakkers = new List<Trakker>();
        geofence.Geography = geofence.GetGeometry();
        geofence.BufferRadius = null;
        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Converters = new List<JsonConverter>
            {
                new GeometryConverter(),
                new StringEnumConverter()
            }
        };

        return JsonConvert.SerializeObject(geofence, Formatting.None, settings);
    }

    /// <summary>
    /// For copying data to testcases.
    /// ex: .PrintAsVariable<Position, Coordinate>(pos => $"new Coordinate({pos.Longitude.ToString(CultureInfo.InvariantCulture)},{pos.Latitude.ToString(CultureInfo.InvariantCulture)})"));
    /// </summary>
    public static string PrintAsVariable<TType, TCollectionType>(this IEnumerable<TType> collection, Func<TType, string> createEntryString, string variableName = "variables")
    {
        var variable = $"var {variableName} = new List<{typeof(TCollectionType).Name}>() " + "{";
        foreach (var t in collection)
        {
            variable += $"\n    {createEntryString(t)},";
            //$"\n new Coordinate({pos.Longitude.ToString(CultureInfo.InvariantCulture)},{pos.Latitude.ToString(CultureInfo.InvariantCulture)}),";
        }
        variable += "\n}";

        return variable;
    }
    public static IEnumerable<(Coordinate coordinate, EventPosition eventPosition)> Simplify(this VehicleEvent src, double inflection_threshold_degrees = 45)
    {
        return src.Positions.Simplify(null,null,inflection_threshold_degrees);
    }
    public static IEnumerable<(Coordinate coordinate, EventPosition eventPosition)> Simplify(this TripEvent src, double inflection_threshold_degrees = 45)
    {
        return src.Positions.Simplify(src.PreviousStop.StopPosition?.ToCoordinate(),
            src.NextStop.StopPosition?.ToCoordinate(), inflection_threshold_degrees);
    }
    public static IEnumerable<(Coordinate coordinate, EventPosition eventPosition)> Simplify(this ICollection<EventPosition> positions, Coordinate origin = null, Coordinate destination = null, double inflection_threshold_degrees = 45)
    {
        var eventCoordinates = positions.OrderBy(x => x.TimeStamp)
            .Select(x => (coordinate: x.Position.ToCoordinate(), EventPosition: x)).ToList();
        var coordinates = eventCoordinates.Select(x => x.coordinate).ToList();
        if (origin != null)
            coordinates.Insert(0,origin);
        if (destination != null)
            coordinates.Insert(coordinates.Count, destination);
        coordinates = coordinates.Simplify(inflection_threshold_degrees).ToList();
        return eventCoordinates.Where(x => coordinates.Contains(x.coordinate));
    }
}