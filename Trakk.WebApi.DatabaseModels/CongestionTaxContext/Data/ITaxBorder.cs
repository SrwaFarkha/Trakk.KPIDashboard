using System;
using System.Collections.Generic;
using System.Drawing;
using CongestionTaxProcessor.Models.TaxAreas;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CongestionTaxProcessor.Models;

public interface ITaxBorder
{
    TaxArea TaxArea { get; }
    [JsonConverter(typeof(StringEnumConverter))]
    Enums.TaxBorder Id { get; }
    Enums.Area Area => TaxArea.Id;
    List<TariffPeriod> TariffPeriods { get; set; }
    Geometry Bounds { get; }
    List<PassageInput> GetPassages(IEnumerable<CoordinateLine> lines);
    Tariff? GetTariff(DateTime dateTime);

    virtual IEnumerable<Feature> ToFeatures(KnownColor color = KnownColor.Gray)
    {
        yield return new Feature(Bounds, new AttributesTable
        {
            { "fill", color.ToString() },
        });
    }

}