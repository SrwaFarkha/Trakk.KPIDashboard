using System;
using System.ComponentModel.DataAnnotations.Schema;
using CongestionTaxProcessor.Enums;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

namespace CongestionTaxProcessor.Models;

public class PassageInput
{
    public double Cost { get; set; }
    public DateTime PassageTime { get; set; }
    [JsonConverter(typeof(StringEnumConverter))] public Area Area { get; set; }   
    [JsonConverter(typeof(StringEnumConverter))] public Enums.TaxBorder TaxBorder { get; set; }
    public Tariff? Tariff { get; set; }
    public bool ViaEssingeleden { get; set; }

    public Passage ToPassage(int vehicleEventId)
    {
        return new Passage
        {
            Area = Area,
            VehicleEventId = vehicleEventId,
            TaxBorder = TaxBorder,
            Cost = Cost,
            PassageTime = PassageTime,
            ViaEssingeleden = ViaEssingeleden
        };
    }
}

public class PartialEssingePassageInput : PassageInput
{
    public EssingeTaxBorder.EssingeBorderCrossing BorderCrossing { get; set; }
}