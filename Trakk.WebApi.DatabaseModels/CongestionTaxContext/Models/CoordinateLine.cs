using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using Trakk.Utils.Extensions;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

namespace CongestionTaxProcessor.Models;

public class CoordinateLine : LineString
{
    public DateTime CrossTime { get; set; }
    public DateTime OriginalFirstTimeStamp { get; set; }
    public DateTime OriginalSecondTimeStamp { get; set; }

    public CoordinateLine(EventPosition[] coordinates) : base(new NetTopologySuite.Geometries.Coordinate[] {coordinates[0].Position.ToCoordinate(), coordinates[1].Position.ToCoordinate()})
    {
        OriginalFirstTimeStamp = coordinates[0].TimeStamp;
        OriginalSecondTimeStamp = coordinates[1].TimeStamp;
        CrossTime = OriginalFirstTimeStamp.Average(OriginalSecondTimeStamp);
    }
}