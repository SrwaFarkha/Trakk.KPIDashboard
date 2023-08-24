using System;
using System.Collections.Generic;
using System.Linq;
using NetTopologySuite.Geometries;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Route : IEntity
    {
        public int RouteId { get; set; } // RouteId (Primary key)
        public string RouteHandle { get; set; }
        public double GetDuration() => Sections.Sum(x => x.Duration);
        public double GetLength() => Sections.Sum(x => x.Length);
        public List<RouteSection> Sections { get; set; }
        public LineString GetFullPath() =>
            new LineString(GetAllCoordinates().ToArray());

        public IEnumerable<Coordinate> GetAllCoordinates() =>
            Sections.OrderBy(x => x.From).SelectMany(x => x.Path.Coordinates);
    }

    public class RouteSection : IEntity
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public double Duration { get; set; }
        public double Length { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int? StartReferencePositionId { get;set; }
        public int? StopReferencePositionId { get;set; }
        public EventPosition? StartReferencePosition { get;set; }
        public EventPosition? StopReferencePosition { get;set; }
        public virtual Route Route { get; set; } = null!;
        public Geometry Path { get; set; }
    }
}