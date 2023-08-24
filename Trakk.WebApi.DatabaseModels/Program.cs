


using System;
using Microsoft.Extensions.Configuration;
using Trakk.Configuration;

ConfigManager.Setup(c => c.AddJsonFile("db_appsettings.json"));
Console.WriteLine(".");

// // See https://aka.ms/new-console-template for more information
//
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Trakk.WebApi.DatabaseModels.CongestionTaxContext;
// using Trakk.WebApi.DatabaseModels.CongestionTaxContext.Context;
// using Trakk.WebApi.DatabaseModels.CongestionTaxContext.Models;
// using Trakk.WebApi.DatabaseModels.CongestionTaxContext.Models.Enums;
//
// try
// {
//     var context = new CongestionContext();
//     context.Database.EnsureDeleted();
//     //context.SaveChanges();
//     context.Database.EnsureCreated();
//     context.SaveChanges();
//     var areas = context.TaxAreas
//         .Include(x => x.Borders)
//         .ThenInclude(x => x.TariffSeasons)
//         .Include(x => x.Borders)
//         .ThenInclude(x => x.CoordinateLines)
//         .ThenInclude(x => x.Coordinates)
//         .Include(x => x.SpecialPeriods)
//         .ToDictionary(x => (Area)x.Id, x => x);
//     //context.SaveChanges();
//
//     var now = DateTime.Now;
//     Console.WriteLine($"********{now}********");
//     foreach (var area in areas)
//         Console.WriteLine($"    {area.Key.ToString()}: " +
//                           $"IsDateRuleApplied: {area.Value.IsDateRuleApplied} " +
//                           $"IsMaxTollPerDayRuleApplied: {area.Value.IsMaxTollPerDayRuleApplied} " +
//                           $"ExceptedDate: {area.Value.IsExceptedDate(now)} : " +
//                           $"HighSeason: {area.Value.IsHighSeasonDate(now)}\n" +
//                           $"Has multipassRule: {area.Value.HasMultiPassRule}");
//     // var areas = context.TaxAreas.ToList();
//     // var coordinate = new Coordinate
//     // {
//     //     Longitude = 17.92694091796875,
//     //     Latitude = 59.16325967368097
//     // };
//     // var area = FindClosestArea(coordinate);
//
//     var positions = new List<Coordinate>
//     {
//         new()
//         {
//             Longitude = 17.92694091796875,
//             Latitude = 59.16325967368097
//         },
//         new()
//         {
//             Longitude = 12.132339477539062,
//             Latitude = 57.62261077612513
//         },
//         new()
//         {
//             Longitude = 12.132339477539062,
//             Latitude = 57.62261077612513
//         }
//     };
//     var areasToCheck = positions.Select(FindClosestArea).ToHashSet();
//
//     foreach (var a in areasToCheck) Console.WriteLine(a.ToString());
//
//
//     foreach (var line in areas[Area.Göteborg].Borders.FirstOrDefault(x => x.TaxBorderArea == TaxBorderArea.Göteborg)
//                  .CoordinateLines) Console.WriteLine(line + ",");
// }
// catch (Exception e)
// {
//     Console.WriteLine($"ERROR: {e}");
// }
//
// Console.WriteLine("done!");
//
// Area FindClosestArea(Coordinate coordinate)
// {
//     var minDistance = double.MaxValue;
//
//     var distances = Constants.Areas.Select(x => new { Area = x.Key, Distance = x.Value.Distance(coordinate, false) });
//
//     var closest = distances.OrderBy(x => x.Distance).First();
//     return closest.Area;
// }