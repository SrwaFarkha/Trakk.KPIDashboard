using System;
using System.Collections.Generic;
using System.Linq;
using CongestionTaxProcessor.Models.TaxAreas;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

namespace CongestionTaxProcessor.Models.Filters;

public class MaxTollPerDayFilter : IInclidingPreviousFilter
{
    private readonly TaxArea _area;

    public MaxTollPerDayFilter(TaxArea area)
    {
        _area = area;
    }

    public List<PassageInput> ApplyFilter(List<PassageInput> passages, ref List<Passage> existing, TrakkDbContext db)
    {
        if (!passages.Any()) return passages;
        
        var dailyFee = existing.Sum(x => x.Cost);
        var maxFee = _area.MaxToll(passages.FirstOrDefault()!.PassageTime);
        foreach (var passage in passages.OrderBy(x =>x.PassageTime))
            if (dailyFee < maxFee)
            {
                if (passage.Cost + dailyFee > maxFee)
                {
                    passage.Cost = maxFee - dailyFee;
                }

                dailyFee += passage.Cost;
            }
            else
            {
                passage.Cost = 0;
            }

        return passages;
    }
}