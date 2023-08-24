using System;
using System.Collections.Generic;
using System.Linq;

namespace CongestionTaxProcessor.Models;

public class TariffPeriod
{
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public List<Tariff> Tariffs { get; set; }
    public bool HighSeason { get; set; }

    public Tariff? GetTariff(TimeOnly time)
    {
        return Tariffs.FirstOrDefault(x => x.StartTime <= time && x.EndTime >= time);
    }
}