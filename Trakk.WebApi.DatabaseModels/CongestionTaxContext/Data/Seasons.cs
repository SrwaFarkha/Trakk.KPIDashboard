using System;
using System.Collections.Generic;
using System.Linq;
using CongestionTaxProcessor.Models;

namespace Trakk.WebApi.DatabaseModels.CongestionTaxContext.Data;

public enum SeasonType
{
    Normal,
    HighSeason,
    Excepted
}

public static class Seasons
{
    internal static class Stockholm
    {
        public static IEnumerable<Season> HighSeasons = new[]
        {
            new(new DateTime(2020, 3, 1), new DateTime(2020, 6, 24), SeasonType.HighSeason),
            new Season(new DateTime(2020, 8, 15), new DateTime(2020, 11, 30), SeasonType.HighSeason),
            new Season(new DateTime(2021, 3, 1), new DateTime(2021, 6, 24), SeasonType.HighSeason),
            new Season(new DateTime(2021, 8, 15), new DateTime(2021, 11, 30), SeasonType.HighSeason),
            new Season(new DateTime(2022, 3, 1), new DateTime(2022, 6, 24), SeasonType.HighSeason),
            new Season(new DateTime(2022, 8, 15), new DateTime(2022, 11, 30), SeasonType.HighSeason),
            new Season(new DateTime(2023, 3, 1), new DateTime(2023, 6, 24), SeasonType.HighSeason),
            new Season(new DateTime(2023, 8, 15), new DateTime(2023, 11, 30), SeasonType.HighSeason),
        };

        internal static class Excepted
        {
            public static IEnumerable<Season> Excepted_2019 = new[]
            {
                new Season(new DateTime(2019, 1, 1)),
                new Season(new DateTime(2019, 4, 18), new DateTime(2019, 4, 19), SeasonType.Excepted),
                new Season(new DateTime(2019, 4, 22)),
                new Season(new DateTime(2019, 4, 30), new DateTime(2019, 5, 1), SeasonType.Excepted),
                new Season(new DateTime(2019, 5, 29), new DateTime(2019, 5, 30), SeasonType.Excepted),
                new Season(new DateTime(2019, 6, 5), new DateTime(2019, 6, 6), SeasonType.Excepted),
                new Season(new DateTime(2019, 6, 21)),
                new Season(new DateTime(2019, 7, 1), new DateTime(2019, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2019, 11, 1)),
                new Season(new DateTime(2019, 12, 24), new DateTime(2019, 12, 26), SeasonType.Excepted),
                new Season(new DateTime(2019, 12, 31))
            };

            public static IEnumerable<Season> Excepted_2020 = new[]
            {
                new Season(new DateTime(2020, 1, 1)),
                new Season(new DateTime(2020, 1, 5), new DateTime(2020, 1, 6), SeasonType.Excepted),
                new Season(new DateTime(2020, 4, 10)),
                new Season(new DateTime(2020, 4, 30), new DateTime(2020, 5, 1), SeasonType.Excepted),
                new Season(new DateTime(2020, 5, 21)),
                new Season(new DateTime(2020, 6, 6)),
                new Season(new DateTime(2020, 6, 24), new DateTime(2020, 6, 25), SeasonType.Excepted),
                new Season(new DateTime(2020, 7, 4), new DateTime(2020, 7, 5), SeasonType.Excepted),
                new Season(new DateTime(2020, 7, 8), new DateTime(2020, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2020, 10, 31)),
                new Season(new DateTime(2020, 12, 24), new DateTime(2020, 12, 26), SeasonType.Excepted),
                new Season(new DateTime(2020, 12, 31))
            };

            public static IEnumerable<Season> Excepted_2021 = new[]
            {
                new Season(new DateTime(2021, 1, 1)),
                new Season(new DateTime(2021, 1, 5), new DateTime(2021, 1, 6), SeasonType.Excepted),
                new Season(new DateTime(2021, 4, 2)),
                new Season(new DateTime(2021, 4, 5)),
                new Season(new DateTime(2021, 5, 1)),
                new Season(new DateTime(2021, 5, 13)),
                new Season(new DateTime(2021, 6, 6)),
                new Season(new DateTime(2021, 6, 25)),
                new Season(new DateTime(2021, 7, 1), new DateTime(2021, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2021, 11, 6)),
                new Season(new DateTime(2021, 12, 24), new DateTime(2021, 12, 26), SeasonType.Excepted),
                new Season(new DateTime(2021, 12, 31))
            };

            public static IEnumerable<Season> Excepted_2022 = new[]
            {
                new Season(new DateTime(2022, 1, 1)),
                new Season(new DateTime(2022, 1, 5), new DateTime(2022, 1, 6), SeasonType.Excepted),
                new Season(new DateTime(2022, 4, 15)),
                new Season(new DateTime(2022, 4, 18)),
                new Season(new DateTime(2022, 5, 26)),
                new Season(new DateTime(2022, 6, 6)),
                new Season(new DateTime(2022, 6, 24)),
                new Season(new DateTime(2022, 7, 8), new DateTime(2022, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2022, 12, 26)),
                new Season(new DateTime(2022, 12, 31))
            };
            
            public static IEnumerable<Season> Excepted_2023 = new[]
            {
                new Season(new DateTime(2023, 1, 1)),
                new Season(new DateTime(2023, 1, 5), new DateTime(2023, 1, 6), SeasonType.Excepted),
                new Season(new DateTime(2023, 4, 10)),
                new Season(new DateTime(2023, 5, 18)),
                new Season(new DateTime(2023, 6, 6)),
                new Season(new DateTime(2023, 6, 23)),
                new Season(new DateTime(2023, 7, 8), new DateTime(2023, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2023, 12, 25),new DateTime(2023, 12, 26), SeasonType.Excepted ),
            };

   
        }
               public static List<Season> All =
            HighSeasons.Concat(Excepted.Excepted_2019)
                .Concat(Excepted.Excepted_2020)
                .Concat(Excepted.Excepted_2021)
                .Concat(Excepted.Excepted_2022)
                .Concat(Excepted.Excepted_2023)
                .ToList();
    }

    internal static class Göteborg
    {
        internal static class Excepted
        {
            public static IEnumerable<Season> Excepted_2019 = new[]
            {
                new Season(new DateTime(2019, 1, 1)),
                new Season(new DateTime(2019, 4, 18), new DateTime(2019, 4, 19), SeasonType.Excepted),
                new Season(new DateTime(2019, 4, 22)),
                new Season(new DateTime(2019, 4, 30), new DateTime(2019, 5, 1), SeasonType.Excepted),
                new Season(new DateTime(2019, 5, 29), new DateTime(2019, 5, 30), SeasonType.Excepted),
                new Season(new DateTime(2019, 6, 5), new DateTime(2019, 6, 6), SeasonType.Excepted),
                new Season(new DateTime(2019, 6, 21)),
                new Season(new DateTime(2019, 7, 1), new DateTime(2019, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2019, 11, 1)),
                new Season(new DateTime(2019, 12, 24), new DateTime(2019, 12, 26), SeasonType.Excepted),
                new Season(new DateTime(2019, 12, 31))
            };

            public static IEnumerable<Season> Excepted_2020 = new[]
            {
                new Season(new DateTime(2020, 1, 1)),
                new Season(new DateTime(2020, 1, 5), new DateTime(2020, 1, 6), SeasonType.Excepted),
                new Season(new DateTime(2020, 4, 9), new DateTime(2020, 4, 10), SeasonType.Excepted),
                new Season(new DateTime(2020, 4, 30), new DateTime(2020, 5, 1), SeasonType.Excepted),
                new Season(new DateTime(2020, 5, 20), new DateTime(2020, 5, 21), SeasonType.Excepted),
                new Season(new DateTime(2020, 6, 5), new DateTime(2020, 6, 6), SeasonType.Excepted),
                new Season(new DateTime(2020, 6, 24), new DateTime(2020, 6, 25), SeasonType.Excepted),
                new Season(new DateTime(2020, 7, 1), new DateTime(2020, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2020, 10, 30), new DateTime(2020, 10, 31), SeasonType.Excepted),
                new Season(new DateTime(2020, 12, 24), new DateTime(2020, 12, 26), SeasonType.Excepted),
                new Season(new DateTime(2020, 12, 31))
            };

            public static IEnumerable<Season> Excepted_2021 = new[]
            {
                new Season(new DateTime(2021, 1, 1)),
                new Season(new DateTime(2021, 1, 5), new DateTime(2021, 1, 6), SeasonType.Excepted),
                new Season(new DateTime(2021, 4, 1), new DateTime(2021, 4, 2), SeasonType.Excepted),
                new Season(new DateTime(2021, 4, 5)),
                new Season(new DateTime(2021, 4, 30), new DateTime(2021, 5, 1), SeasonType.Excepted),
                new Season(new DateTime(2021, 5, 12), new DateTime(2021, 5, 13), SeasonType.Excepted),
                new Season(new DateTime(2021, 6, 25)),
                new Season(new DateTime(2021, 7, 1), new DateTime(2021, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2021, 11, 5)),
                new Season(new DateTime(2021, 12, 24), new DateTime(2021, 12, 26), SeasonType.Excepted),
                new Season(new DateTime(2021, 12, 31))
            };

            public static IEnumerable<Season> Excepted_2022 = new[]
            {
                new Season(new DateTime(2022, 1, 1)),
                new Season(new DateTime(2022, 1, 5), new DateTime(2022, 1, 6), SeasonType.Excepted),
                new Season(new DateTime(2022, 4, 14), new DateTime(2022, 4, 15), SeasonType.Excepted),
                new Season(new DateTime(2022, 4, 18)),
                new Season(new DateTime(2022, 5, 25), new DateTime(2022, 5, 26), SeasonType.Excepted),
                new Season(new DateTime(2022, 6, 6)),
                new Season(new DateTime(2022, 6, 24)),
                new Season(new DateTime(2022, 7, 1), new DateTime(2022, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2022, 11, 4)),
                new Season(new DateTime(2022, 12, 26)),
                new Season(new DateTime(2022, 12, 31))
            };
            
            public static IEnumerable<Season> Excepted_2023 = new[]
            {
                new Season(new DateTime(2023, 1, 1)),
                new Season(new DateTime(2023, 1, 5), new DateTime(2023, 1, 6), SeasonType.Excepted),
                new Season(new DateTime(2023, 4, 6), new DateTime(2023, 4, 7), SeasonType.Excepted),
                new Season(new DateTime(2023, 4, 10)),
                new Season(new DateTime(2023, 5, 1)),
                new Season(new DateTime(2023, 5, 17), new DateTime(2023, 5, 18), SeasonType.Excepted),
                new Season(new DateTime(2023, 6, 5), new DateTime(2023, 6, 6), SeasonType.Excepted),
                new Season(new DateTime(2023, 6, 23)),
                new Season(new DateTime(2023, 7, 1), new DateTime(2023, 7, 31), SeasonType.Excepted),
                new Season(new DateTime(2023, 11, 3)),
                new Season(new DateTime(2023, 12, 25), new DateTime(2023, 12, 26), SeasonType.Excepted),
                new Season(new DateTime(2023, 12, 31))
            };

            public static List<Season> All =
                new List<Season>()
                    .Concat(Excepted_2019)
                    .Concat(Excepted_2020)
                    .Concat(Excepted_2021)
                    .Concat(Excepted_2022)
                    .Concat(Excepted_2023)
                    .ToList();
        }
    }
}