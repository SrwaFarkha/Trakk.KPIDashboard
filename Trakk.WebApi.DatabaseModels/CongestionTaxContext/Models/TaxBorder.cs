// using System;
// using System.Collections.Generic;
// using System.Linq;
// using CongestionTaxProcessor.Enums;
// using CongestionTaxProcessor.Models.TaxAreas;
// using NetTopologySuite.Geometries;
// using NetTopologySuite.IO.Converters;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Converters;
// using Trakk.WebApi.DatabaseModels.CongestionTaxContext.Data;
//
// namespace CongestionTaxProcessor.Models;
//
// public class TaxBorder
// {
//
//     public TaxBorder(TaxArea area)
//     {
//         TaxArea = area;
//     }
//     public TaxArea TaxArea { get; }
//     
//     [JsonConverter(typeof(StringEnumConverter))]
//     public Enums.TaxBorder Id { get; set; }
//
//     public Enums.Area Area => TaxArea.Id;
//
//     public List<TariffPeriod> TariffPeriods { get; set; }
//
//     [JsonConverter(typeof(GeometryConverter))]
//     public Geometry Bounds { get; set; }
//
//     public Tariff? GetTariff(DateTime dateTime)
//     {
//         dateTime = dateTime.ToLocalTime();
//         var season =
//             TariffPeriods?.FirstOrDefault(x => x.ValidFrom <= dateTime && x.ValidTo >= dateTime) ??
//             TariffPeriods?.OrderByDescending(x => x.ValidFrom)
//                 .FirstOrDefault(x => x.ValidFrom <= dateTime && !x.ValidTo.HasValue);
//         return season?.GetTariff(TimeOnly.FromDateTime(dateTime));
//     }
//
//     public virtual List<PassageInput> GetPassages(IEnumerable<CoordinateLine> lines) =>
//         lines.DistinctBy(x => x.CrossTime)
//             .OrderBy(x => x.CrossTime)
//             .Where(x => Bounds.Crosses(x) || x.Crosses(Bounds))
//             .Select(line => new { line, tariff = GetTariff(line.CrossTime) })
//             .Where(t => t.tariff != null)
//             .Select(t => new PassageInput
//             {
//                 TaxBorder = Id, Area = Area, PassageTime = t.line.CrossTime, Cost = t.tariff?.Toll ?? 0, Tariff = t.tariff,
//                 InsideEssingeleden = Area == Area.Stockholm && TaxBorders.Stockholm.EssingeledenGeofence.Intersects(t.line),
//                 InvalidateEssingeleden = Area == Area.Stockholm && TaxBorders.Stockholm.EssingeledenInvalidatorGeofence.Intersects(t.line)
//             }).ToList();
// }