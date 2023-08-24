using System;
using System.Collections.Generic;
using System.Linq;
using CongestionTaxProcessor.Models.TaxAreas;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

namespace CongestionTaxProcessor.Models.Filters;

public class MultiPassFilter : IInclidingPreviousFilter
{
    private readonly TaxArea _area;

    public MultiPassFilter(TaxArea area)
    {
        _area = area;
    }

    public List<PassageInput> ApplyFilter(List<PassageInput> passages, ref List<Passage> existing, TrakkDbContext db)
    {
        // if (existing.Sum(x => x.Cost) >= _area.MaxTollPerDay)
        //     return new List<PassageInput>();
        
        var linked = new LinkedList<PassageInput>(passages.OrderBy(x => x.PassageTime));
        var lastExisting = existing.MaxBy(x => x.PassageTime);
        LinkedListNode<PassageInput>? lastBilled = null;
        var selected = linked.First;
        while (selected != null)
        {
            switch (lastBilled)
            {
                case null when lastExisting == null: lastBilled = selected; break;
                case null when selected.Value.PassageTime > lastExisting.PassageTime + _area.MultiPassTimeLimit:
                {
                    lastBilled = selected;
                    break;
                }
                case null:
                {
                    if (selected.Value.Cost > lastExisting.Cost) lastExisting.Cost = selected.Value.Cost;
                    passages.Remove(selected.Value);
                    break;
                }
                case not null when selected.Value.PassageTime > lastBilled.Value.PassageTime + _area.MultiPassTimeLimit:
                {
                    lastBilled = selected;
                    break;
                }
                default:
                {
                    if (selected.Value.Cost > lastBilled.Value.Cost) lastBilled.Value.Cost = selected.Value.Cost;
                    passages.Remove(selected.Value);
                    break;
                }
            }

            selected = selected.Next;
        }

        return passages;
    }
}