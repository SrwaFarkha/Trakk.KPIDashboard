using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CongestionTaxProcessor.Models.TaxAreas;
using NetTopologySuite.Geometries;
using Trakk.Utils.Extensions.StringExtensions;

namespace CongestionTaxProcessor.Models;

public class InnerstadenTaxBorder : ITaxBorder
{
    public static readonly Geometry Geometry = new Polygon(new LinearRing(new[]
    {
        new Coordinate (18.074103087204463, 59.30258923959269 ),
        new Coordinate (18.097940507730897, 59.307082148986325 ),
        new Coordinate (18.110287069132653, 59.31843657956591 ),
        new Coordinate (18.162100021435293, 59.320185735093816 ),
        new Coordinate (18.162789488390473, 59.33314621700373 ),
        new Coordinate (18.09161234969085, 59.37049748724476 ),
        new Coordinate (18.05825264332583, 59.376973069272594 ),
        new Coordinate (18.04444911363845, 59.375055376123896 ),
        new Coordinate (18.038871929926216, 59.37065137407535 ),
        new Coordinate (18.049172276746674, 59.357132166316404 ),
        new Coordinate (18.04171440725571, 59.35168044368476 ),
        new Coordinate (18.03086018767462, 59.34821093630191 ),
        new Coordinate (18.025132887255495, 59.34407700041032 ),
        new Coordinate (18.024616032363184, 59.33902892329559 ), //enter essinge North
        new Coordinate (18.012847644023623, 59.34069142512479 ), //enter essinge North
        new Coordinate (18.006790870769493, 59.3410774908356 ), //enter essinge North
        new Coordinate (17.99482289900368, 59.33627167727326 ), // enter essinge west
        new Coordinate (17.99363203901487, 59.330197766536344 ), // enter essinge west
        new Coordinate (17.975791216954775, 59.318224389189965 ),
        new Coordinate (17.982720054185563, 59.31578597513939 ),  //Enter essinge south
        new Coordinate (18.00733285982639, 59.32013049211699 ),   //Enter essinge south
        new Coordinate (18.04602443246469, 59.309120196132056 ),
        new Coordinate (18.074103087204463, 59.30258923959269 ),
    }));

    public static LineString EnterEssingeNorth => new LineString(new[]
    {
        new Coordinate(18.024616032363184, 59.33902892329559), //enter essinge North 
        new Coordinate(18.012847644023623, 59.34069142512479), //enter essinge North 
        new Coordinate(18.006790870769493, 59.3410774908356), //enter essinge North  
    });
    
    public static LineString EnterEssingeWest => new LineString(new[]
    {
        new Coordinate (17.99482289900368, 59.33627167727326 ), // enter essinge west
        new Coordinate (17.99363203901487, 59.330197766536344 ), // enter essinge west
    });
    public static LineString EnterEssingeSouth => new LineString(new[]
    {
        new Coordinate (17.982720054185563, 59.31578597513939 ),  //Enter essinge south
        new Coordinate (18.00733285982639, 59.32013049211699 ),   //Enter essinge south
    });
    public InnerstadenTaxBorder(TaxArea area, List<TariffPeriod> tariffPeriods)
    {
        TaxArea = area;
        TariffPeriods = tariffPeriods;
    }
    public TaxArea TaxArea { get; }
    public Enums.TaxBorder Id => Enums.TaxBorder.Innerstaden;
    public List<TariffPeriod> TariffPeriods { get; set; }
    public Enums.Area Area => TaxArea.Id;
    public Geometry Bounds => Geometry;
    public Tariff? GetTariff(DateTime dateTime)
    {
        dateTime = dateTime.ToLocalTime();
        var season =
            TariffPeriods?.FirstOrDefault(x => x.ValidFrom <= dateTime && x.ValidTo >= dateTime) ??
            TariffPeriods?.OrderByDescending(x => x.ValidFrom)
                .FirstOrDefault(x => x.ValidFrom <= dateTime && !x.ValidTo.HasValue);
        return season?.GetTariff(TimeOnly.FromDateTime(dateTime));
    }

    public virtual List<PassageInput> GetPassages(IEnumerable<CoordinateLine> lines) =>
        lines.DistinctBy(x => x.CrossTime)
            .OrderBy(x => x.CrossTime)
            .Where(x => x.Crosses(Bounds))
            .SelectMany(t =>
            {
                var passages = new List<PassageInput>();
                if (Bounds.Covers(t.StartPoint) && Bounds.Covers(t.EndPoint) && !Bounds.Covers(t))
                {
                    var firstTariff = GetTariff(t.OriginalFirstTimeStamp);
                    var secondTariff = GetTariff(t.OriginalSecondTimeStamp);
                    passages.Add(new PassageInput
                    {
                        TaxBorder = Id, Area = Area, PassageTime = t.OriginalFirstTimeStamp, Cost = firstTariff?.Toll ?? 0,
                        Tariff = firstTariff, ViaEssingeleden = CrossesViaEssingeleden(t)
                    });
                    passages.Add(new PassageInput
                    {
                        TaxBorder = Id, Area = Area, PassageTime = t.OriginalSecondTimeStamp, Cost = secondTariff?.Toll ?? 0,
                        Tariff = secondTariff, ViaEssingeleden = CrossesViaEssingeleden(t)
                    });
                }
                else
                {
                    var tariff = GetTariff(t.CrossTime);
                    passages.Add(new PassageInput
                    {
                        TaxBorder = Id, Area = Area, PassageTime = t.CrossTime, Cost = tariff?.Toll ?? 0,
                        Tariff = tariff, ViaEssingeleden = CrossesViaEssingeleden(t)
                    });
                }

                return passages;
            })   
            .Where(t => t.Tariff != null)
            .ToList();


    private bool CrossesViaEssingeleden(CoordinateLine line)
    {
        return line.Crosses(EnterEssingeNorth) || line.Crosses(EnterEssingeWest) || line.Crosses(EnterEssingeSouth);
    }
}
