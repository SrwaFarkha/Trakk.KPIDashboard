using System.Collections.Generic;
using CongestionTaxProcessor.Models.TaxAreas;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

namespace CongestionTaxProcessor.Models;

public interface IFilter
{
    //List<PassageInput> ApplyFilter(List<PassageInput> passages, List<Passage> existing, TrakkDbContext db);
}

public interface IInclidingPreviousFilter : IFilter
{
    List<PassageInput> ApplyFilter(List<PassageInput> passages, ref List<Passage> existing, TrakkDbContext db);
}
public interface IPrePreviousFilter : IFilter
{
    List<PassageInput> ApplyFilter(List<PassageInput> passages);
}
