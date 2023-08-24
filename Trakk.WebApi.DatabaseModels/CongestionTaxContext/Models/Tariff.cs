using System;

namespace CongestionTaxProcessor.Models;

public class Tariff
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int Toll { get; set; }
}