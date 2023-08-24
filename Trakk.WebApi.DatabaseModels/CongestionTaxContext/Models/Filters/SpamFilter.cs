using System;
using System.Collections.Generic;
using System.Linq;
using CongestionTaxProcessor.Models;
using CongestionTaxProcessor.Models.TaxAreas;
using Trakk.Utils.Extensions.StringExtensions;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

namespace Trakk.WebApi.DatabaseModels.CongestionTaxContext.Models.Filters;

public class SpamFilter : IPrePreviousFilter
{
    private readonly TaxArea _area;
    private readonly TimeSpan _timeSpan;

    public SpamFilter(TaxArea area)
    {
        _area = area;
        _timeSpan = TimeSpan.FromMinutes(5);
    }
    public SpamFilter(TaxArea area, TimeSpan minSpan)
    {
        _area = area;
        _timeSpan = minSpan;
    }

    public List<PassageInput> ApplyFilter( List<PassageInput> passages)
    {
        if (!passages.Any())
            return passages;
        
        var linked = new LinkedList<PassageInput>(passages.OrderBy(x => x.PassageTime));
        var selected = linked.First;
        var buffTime = selected?.Value.PassageTime;
        selected = selected?.Next;
        while (selected != null)
        {
            if (selected.Value.PassageTime < buffTime + _timeSpan)
            {
                passages.Remove(selected.Value);
            }
            else
            {
                buffTime = selected.Value.PassageTime;
            }

            selected = selected.Next;
        }

        return passages;
    }
}