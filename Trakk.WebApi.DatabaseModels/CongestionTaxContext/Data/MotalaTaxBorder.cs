using System;
using System.Collections.Generic;
using System.Linq;
using CongestionTaxProcessor.Models.TaxAreas;
using NetTopologySuite.Geometries;

namespace CongestionTaxProcessor.Models;

public class MotalaTaxBorder : ITaxBorder
{
    public static readonly Geometry Geometry =  new LineString(new[]
    {
        new Coordinate { Y = 58.52788, X = 15.01002 },
        new Coordinate { Y = 58.53117, X = 15.02862 }
    });
    public MotalaTaxBorder(TaxArea area, List<TariffPeriod> tariffPeriods)
    {
        TaxArea = area;
        TariffPeriods = tariffPeriods;
    }
    public TaxArea TaxArea { get; }
    public Enums.TaxBorder Id => Enums.TaxBorder.Motala;
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
            .Where(x => Bounds.Crosses(x) || x.Crosses(Bounds))
            .Select(line => new { line, tariff = GetTariff(line.CrossTime) })
            .Where(t => t.tariff != null)
            .Select(t => new PassageInput
            {
                TaxBorder = Id, Area = Area, PassageTime = t.line.CrossTime, Cost = t.tariff?.Toll ?? 0, Tariff = t.tariff,
            }).ToList();
}

public class SundsvallTaxBorder : ITaxBorder
{
    public static readonly Geometry Geometry = new LineString(new[]
    {
        new Coordinate { Y = 62.38903, X = 17.33167 },
        new Coordinate { Y = 62.38877, X = 17.36031 }
    });
    public SundsvallTaxBorder(TaxArea area, List<TariffPeriod> tariffPeriods)
    {
        TaxArea = area;
        TariffPeriods = tariffPeriods;
    }
    public TaxArea TaxArea { get; }
    public Enums.TaxBorder Id => Enums.TaxBorder.Sundsvall;
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
            .Where(x => Bounds.Crosses(x) || x.Crosses(Bounds))
            .Select(line => new { line, tariff = GetTariff(line.CrossTime) })
            .Where(t => t.tariff != null)
            .Select(t => new PassageInput
            {
                TaxBorder = Id, Area = Area, PassageTime = t.line.CrossTime, Cost = t.tariff?.Toll ?? 0, Tariff = t.tariff,
            }).ToList();
}