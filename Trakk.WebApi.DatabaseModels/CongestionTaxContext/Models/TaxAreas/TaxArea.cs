using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CongestionTaxProcessor.Enums;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using Trakk.WebApi.DatabaseModels.CongestionTaxContext.Data;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

namespace CongestionTaxProcessor.Models.TaxAreas;

public class TaxArea
{
    public Enums.Area Id { get; set; }
    public List<ITaxBorder> Borders { get; set; } = new List<ITaxBorder>();
    public ITaxBorder? this[TaxBorder border] => Borders.FirstOrDefault(x => x.Id == border);
    public List<Season> Seasons { get; set; } = new List<Season>();
    public int MaxTollPerDay { get; set; }
    public int HighSeasonMaxTollPerDay { get; set; }
    public TimeSpan? MultiPassTimeLimit { get; set; }
    public List<IFilter> Filters { get; set; } = new List<IFilter>();
    [NotMapped] public List<Season> HighSeasonPeriods => Seasons.Where(x => x.Type == SeasonType.HighSeason).ToList();
    [NotMapped] public List<Season> ExceptedDates => Seasons.Where(x => x.Type == SeasonType.Excepted).ToList();
    [NotMapped] public bool IsDateRuleApplied => Seasons.Any();


    public int MaxToll(DateTime dateTime) => HighSeasonPeriods.Any(x => x.IsActive(dateTime)) ? HighSeasonMaxTollPerDay : MaxTollPerDay;

    public bool IsExceptedDate(DateTime dateTime)
    {
        return ExceptedDates.Any(x => x.IsActive(dateTime));
    }

    public bool IsHighSeasonDate(DateTime dateTime)
    {
        return HighSeasonPeriods.Any(x => x.IsActive(dateTime));
    }

    public Tariff? GetTariff(Enums.TaxBorder borderArea, DateTime dateTime)
    {
        if (IsDateRuleApplied && IsExceptedDate(dateTime)) return null;
        return Borders.FirstOrDefault(x => x.Id == borderArea)?.GetTariff(dateTime);
    }

    public int CountCrossings(ICollection<LineString> lines)
    {
        return lines.Count(x => Borders.Any(y => y.Bounds.Crosses(x)));
    }

    public virtual List<PassageInput> GetPassages(ICollection<CoordinateLine> lines)
    {
        return Borders.SelectMany(x =>
        {
            return x.GetPassages(lines.Where(y => !IsExceptedDate(y.CrossTime)));
        }).ToList();
    }

    public virtual List<PassageInput> ApplyPreRules(List<PassageInput> passages)
    {
        return Filters.Where(x => x is IPrePreviousFilter)
            .Cast<IPrePreviousFilter>().Aggregate(passages, (current, filter) => filter.ApplyFilter(current));
    }
    public virtual List<PassageInput> ApplyAfterRules(List<PassageInput> passages, ref List<Passage> existing, TrakkDbContext db)
    {
        foreach (var filter in Filters.Where(x => x is IInclidingPreviousFilter).Cast<IInclidingPreviousFilter>())
        {
            passages = filter.ApplyFilter(passages, ref existing, db);
        }

        return passages;
    }
}