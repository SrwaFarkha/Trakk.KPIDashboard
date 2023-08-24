using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CongestionTaxProcessor.Enums;
using CongestionTaxProcessor.Models.TaxAreas;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trakk.Utils.Extensions;
using Trakk.Utils.Extensions.StringExtensions;
using Trakk.WebApi.DatabaseModels.CongestionTaxContext.Data;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;
using Point = NetTopologySuite.Geometries.Point;

namespace CongestionTaxProcessor.Models;
public class EssingeTaxBorder : ITaxBorder
{
    public static readonly Geometry Geometry = new Polygon(new LinearRing(new[]
    {
        new Coordinate(18.012205818873554,59.34082436066933),// north högra hörn
        new Coordinate(18.009576750397997,59.341148276593856),// north vänstra
        new Coordinate(18.00837600082265,59.332974870732926),// mitten övre
        new Coordinate(17.994351999059234,59.33496804126278),// west övre
        new Coordinate(17.993909058788645,59.33267809164964),// west nedre
        new Coordinate(18.00770337307287,59.330813364774116),// mitten nedre
        new Coordinate(18.004744792074135,59.32700593122976),// south vänster
        new Coordinate(18.002937160980586, 59.32641921325008), // lilla essinge South buffer zoon
        new Coordinate(17.999372001212794, 59.32598511078597), // lilla essinge South buffer zoon
        new Coordinate(18.002093765769118, 59.32234359962976), // lilla essinge South buffer zoon
        new Coordinate(18.007165654037617, 59.322344528440034), // lilla essinge South buffer zoon
        new Coordinate(18.010565353303072, 59.32422740597498), // lilla essinge South buffer zoon
        new Coordinate(18.01039805082093, 59.32562518305077), // lilla essinge South buffer zoon
        new Coordinate(18.008409227392946,59.326110283509934),// south höger
        new Coordinate(18.011983722872728,59.33226754677591),// mitten höger
        new Coordinate(18.012205818873554,59.34082436066933),// north högra hörn
    }));
    public EssingeTaxBorder(TaxArea area, List<TariffPeriod> tariffPeriods)
    {
        TaxArea = area;
        TariffPeriods = tariffPeriods;
    }
    public TaxArea TaxArea { get; }
    public TaxBorder Id => TaxBorder.Essingeleden;

    public List<TariffPeriod> TariffPeriods { get; set; }
    
    // Alla positioner måste vara innom Bounds för att bli en passage
    public Geometry Bounds => Geometry;

    public readonly LineString[] CrossingBorders = new[]
    {
        new LineString(new[] //North måste passera South för att bli en essinge passage
        {
            new Coordinate { X = 18.027812933044657, Y = 59.339032017815384 }, // mot klarastrandsleden
            new Coordinate { X = 18.01218841797649, Y = 59.34084304736314 }, // innan lilla bron (bind med south)
            new Coordinate { X = 18.002717510388692, Y = 59.34197123938887 }, // mot huvudsta (bind med west huvudsta)
        }),
        new LineString(new[] //West måste passera South för att bli en passage
        {
            new Coordinate { X = 17.99565900981085, Y = 59.3394852215724 }, // mot huvudsta
            new Coordinate(17.994351999059234,59.33496804126278),// west övre
            new Coordinate(17.993909058788645,59.33267809164964),// west nedre
            new Coordinate { X = 17.99365553654289, Y = 59.328210651044145 }, // mot ekensberg bind med west ekens
        }),
        new LineString(new[] // South måste passera South eller West för att bli en essinge passage
        {
            new Coordinate { X = 17.99910809695035, Y = 59.32838909362019 }, // mot traneberg
            new Coordinate(18.004744792074135, 59.32700593122976),
            new Coordinate(18.008409227392946, 59.326110283509934),
            new Coordinate { X =  18.016420012350295, Y = 59.32414238488488 }, // mot långholmen
        })
    };
    private LineString this[EssingeBorderCrossing essingeBorder] => CrossingBorders[(int)essingeBorder];
    
    private PassageInput CreatePassage(TaxBorder border,  DateTime passageTime)
    {
        var tariff = GetTariff(passageTime);
        return new PassageInput
        {
            TaxBorder = border,
            Area = Area.Stockholm,
            Cost = tariff?.Toll?? 0,
            PassageTime = passageTime
        };
    }

    public List<PassageInput> GetPassages(IEnumerable<CoordinateLine> lines)
    {
        var passages = new List<PassageInput>();
        lines = lines.DistinctBy(x => x.CrossTime).OrderBy(x => x.CrossTime);
        Crossing? lastCrossing = null;
        foreach (var line in lines)
        {
            var isCrossing = (
                north :line.Crosses(this[EssingeBorderCrossing.North]), 
                west: line.Crosses(this[EssingeBorderCrossing.West]), 
                south: line.Crosses(this[EssingeBorderCrossing.South]));
            
            switch (isCrossing)
            {
                case {north: true, south: true} or {west: true, south: true}:
                    passages.Add(CreatePassage(TaxBorder.Essingeleden, line.CrossTime));
                    lastCrossing = null;
                    break;
                case {north: true } when lastCrossing is { EssingeBorderCrossing: EssingeBorderCrossing.South }:
                    passages.Add(CreatePassage(TaxBorder.Essingeleden, line.CrossTime));                    
                    lastCrossing = null;
                    break;
                case {north: true} when line.Coordinates.Any(x => Bounds.Contains(new Point(x))):
                {
                    lastCrossing = new Crossing { CrossTime = line.CrossTime, EssingeBorderCrossing = EssingeBorderCrossing.North };
                    break;
                }
                case {west: true } when lastCrossing is { EssingeBorderCrossing: EssingeBorderCrossing.South }:
                    passages.Add(CreatePassage(TaxBorder.Essingeleden, line.CrossTime));                   
                    lastCrossing = null;
                    break;
                case {west: true } when line.Coordinates.Any(x => Bounds.Contains(new Point(x))):
                {
                    lastCrossing = new Crossing { CrossTime = line.CrossTime, EssingeBorderCrossing = EssingeBorderCrossing.West };
                    break;
                }
                case {south: true } when lastCrossing is { EssingeBorderCrossing: EssingeBorderCrossing.West }:
                    passages.Add(CreatePassage(TaxBorder.Essingeleden, line.CrossTime));
                    lastCrossing = null;
                    break;
                case {south: true } when lastCrossing is { EssingeBorderCrossing: EssingeBorderCrossing.North }:
                    passages.Add(CreatePassage(TaxBorder.Essingeleden, line.CrossTime));
                    lastCrossing = null;
                    break;
                case {south: true } when lastCrossing is { EssingeBorderCrossing: EssingeBorderCrossing.South }:
                    passages.Add(CreatePassage(TaxBorder.Innerstaden, line.CrossTime));                   
                    lastCrossing = new Crossing { CrossTime = line.CrossTime, EssingeBorderCrossing = EssingeBorderCrossing.South };
                    break;
                case {south: true } when line.Coordinates.Any(x => Bounds.Contains(new Point(x))):
                {
                    lastCrossing = new Crossing { CrossTime = line.CrossTime, EssingeBorderCrossing = EssingeBorderCrossing.South };
                    break;
                }
                default:
                {
                    if (lastCrossing != null && line.Coordinates.Any(x => !Bounds.Covers(new Point(x))))
                        lastCrossing = null;

                    break;
                }
            }
        }

        return passages;
    }

    public Tariff? GetTariff(DateTime dateTime)
    {
        dateTime = dateTime.ToLocalTime();
        var season =
            TariffPeriods.FirstOrDefault(x => x.ValidFrom <= dateTime && x.ValidTo >= dateTime) ??
            TariffPeriods.OrderByDescending(x => x.ValidFrom)
                .FirstOrDefault(x => x.ValidFrom <= dateTime && !x.ValidTo.HasValue);
        return season?.GetTariff(TimeOnly.FromDateTime(dateTime));
    }

    public IEnumerable<Feature> ToFeatures(KnownColor color = KnownColor.Gray)
    {
        yield return new Feature(Bounds, new AttributesTable
        {
            { "fill", color.ToString() },
        });

        foreach (var b in CrossingBorders)
        {
            yield return new Feature(b, new AttributesTable
            {
                { "fill", color.ToString() },
            });
        }
    }

    private DateTime AverageTime(DateTime first, DateTime second) =>
        new DateTime((first.Ticks + second.Ticks) / 2);

    public enum EssingeBorderCrossing
    {
        North,
        West,
        South,
    }
    private struct Crossing
    {
        public EssingeBorderCrossing EssingeBorderCrossing { get; set; }
        public DateTime CrossTime { get; set; }
    }
}