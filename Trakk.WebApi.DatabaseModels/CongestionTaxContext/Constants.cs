
using System.Collections.Generic;
using CongestionTaxProcessor;
using CongestionTaxProcessor.Enums;
using NetTopologySuite.Geometries;


namespace Trakk.WebApi.DatabaseModels.CongestionTaxContext;

public class Constants
{
    public static readonly Dictionary<Area, Coordinate> Areas = new()
    {
        { Area.Stockholm, new Coordinate { X = 18.069076538085938, Y = 59.32495826118314 } },
        { Area.Göteborg, new Coordinate { X = 11.968574523925781, Y  = 57.706715223690026 } },
        { Area.Sundsvall, new Coordinate { X = 17.304153442382812, Y  = 62.389096521436116 } },
        { Area.Motala, new Coordinate { X = 15.041570663452147, Y  = 58.541924072269886 } }
    };
    /// <summary>
    /// KM
    /// </summary>
    public static readonly int CheckRadius = 50;
}