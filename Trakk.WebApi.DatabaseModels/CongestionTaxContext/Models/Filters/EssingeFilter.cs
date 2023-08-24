using System;
using System.Collections.Generic;
using System.Linq;
using CongestionTaxProcessor.Enums;
using CongestionTaxProcessor.Models.TaxAreas;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

namespace CongestionTaxProcessor.Models.Filters;

public class EssingeFilter : IInclidingPreviousFilter
{
    private readonly TaxArea _area;
    public EssingeFilter(TaxArea area)
    {
        _area = area;
    }
    public List<PassageInput> ApplyFilter(List<PassageInput> passages, ref List<Passage> existing, TrakkDbContext db)
    {
        var lastExisting = existing.MaxBy(x => x.PassageTime);
        var first = passages.FirstOrDefault();
        if (first is { TaxBorder: TaxBorder.Essingeleden } && lastExisting is {TaxBorder: TaxBorder.Innerstaden, ViaEssingeleden: true})
        {
            db.Remove(lastExisting);
            existing.Remove(lastExisting);
        }
        
        var toRemove = new List<PassageInput>();
        for (var i = 1; i < passages.Count; i++)
        {
            var prev = passages[i - 1];
            var curr = passages[i];
            if (curr is {TaxBorder: TaxBorder.Essingeleden} && prev is {TaxBorder: TaxBorder.Innerstaden, ViaEssingeleden: true})
            {
                toRemove.Add(prev);
            }
            if (curr is {TaxBorder: TaxBorder.Innerstaden, ViaEssingeleden: true} && prev is {TaxBorder: TaxBorder.Essingeleden})
            {
                toRemove.Add(curr);
            }
        }

        foreach (var remove in toRemove)
        {
            passages.Remove(remove);
        }

        return passages;
    }


    
}