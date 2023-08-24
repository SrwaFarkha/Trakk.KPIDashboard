using System;
using System.Collections.Generic;
using System.Linq;
using CongestionTaxProcessor.Models;
using CongestionTaxProcessor.Models.TaxAreas;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

namespace Trakk.WebApi.DatabaseModels.CongestionTaxContext.Models.Filters;

public class WeekendFilter : IPrePreviousFilter
{
    private readonly TaxArea _area;

    public WeekendFilter(TaxArea area)
    {
        _area = area;
    }

    public List<PassageInput> ApplyFilter(List<PassageInput> passages)
    {
        passages.RemoveAll(x => x.PassageTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday);
        return passages;
    }
}