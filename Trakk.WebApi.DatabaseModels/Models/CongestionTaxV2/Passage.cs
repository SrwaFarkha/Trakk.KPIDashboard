using System;
using CongestionTaxProcessor.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

public class Passage
{
    public int Id { get; set; }
    public int VehicleEventId { get; set; }
    [JsonConverter(typeof(StringEnumConverter))] public Area Area { get; set; }
    [JsonConverter(typeof(StringEnumConverter))] public TaxBorder TaxBorder { get; set; }
    public bool ViaEssingeleden { get; set; }
    public DateTime PassageTime { get; set; }
    public int? BorderCrossingId { get; set; }
    public double Cost { get; set; }
}