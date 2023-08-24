using System;
using System.Collections.Generic;
using CongestionTaxProcessor.Models;

namespace Trakk.WebApi.DatabaseModels.CongestionTaxContext.Data;

public static class Tariffs
{
    internal static class Göteborg
    {
        public static readonly IEnumerable<TariffPeriod> Tariffs = new TariffPeriod[]
        {
            new()
            {
                ValidFrom = DateTime.MinValue,
                Tariffs = new List<Tariff>
                {
                    new() { StartTime = new TimeOnly(06, 00, 0), EndTime = new TimeOnly(06, 29, 59), Toll = 9 },
                    new() { StartTime = new TimeOnly(06, 30, 0), EndTime = new TimeOnly(06, 59, 59), Toll = 16 },
                    new() { StartTime = new TimeOnly(07, 00, 0), EndTime = new TimeOnly(07, 59, 59), Toll = 22 },
                    new() { StartTime = new TimeOnly(08, 00, 0), EndTime = new TimeOnly(08, 29, 59), Toll = 16 },
                    new() { StartTime = new TimeOnly(08, 30, 0), EndTime = new TimeOnly(14, 59, 59), Toll = 9 },
                    new() { StartTime = new TimeOnly(15, 00, 0), EndTime = new TimeOnly(15, 29, 59), Toll = 16 },
                    new() { StartTime = new TimeOnly(15, 30, 0), EndTime = new TimeOnly(16, 59, 59), Toll = 22 },
                    new() { StartTime = new TimeOnly(17, 00, 0), EndTime = new TimeOnly(17, 59, 59), Toll = 16 },
                    new() { StartTime = new TimeOnly(18, 00, 0), EndTime = new TimeOnly(18, 29, 59), Toll = 9 }
                }
            }
        };
    }

    internal static class Stockholm
    {
        internal static class Innerstaden
        {
            public static readonly IEnumerable<TariffPeriod> Tariffs = new[]
            {
                new TariffPeriod
                {
                    ValidFrom = DateTime.MinValue,
                    ValidTo = new DateTime(2019, 12, 31, 23, 59, 59),
                    Tariffs = new List<Tariff>
                    {
                        new() { StartTime = new TimeOnly(06, 30, 0), EndTime = new TimeOnly(06, 59, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(07, 00, 0), EndTime = new TimeOnly(07, 29, 59), Toll = 25 },
                        new() { StartTime = new TimeOnly(07, 30, 0), EndTime = new TimeOnly(08, 29, 59), Toll = 35 },
                        new() { StartTime = new TimeOnly(08, 30, 0), EndTime = new TimeOnly(08, 59, 59), Toll = 25 },
                        new() { StartTime = new TimeOnly(09, 00, 0), EndTime = new TimeOnly(09, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(09, 30, 0), EndTime = new TimeOnly(14, 59, 59), Toll = 11 },
                        new() { StartTime = new TimeOnly(15, 00, 0), EndTime = new TimeOnly(15, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(15, 30, 0), EndTime = new TimeOnly(15, 59, 59), Toll = 25 },
                        new() { StartTime = new TimeOnly(16, 00, 0), EndTime = new TimeOnly(17, 29, 59), Toll = 35 },
                        new() { StartTime = new TimeOnly(17, 30, 0), EndTime = new TimeOnly(17, 59, 59), Toll = 25 },
                        new() { StartTime = new TimeOnly(18, 00, 0), EndTime = new TimeOnly(18, 29, 59), Toll = 15 }
                    }
                },
                new TariffPeriod
                {
                    ValidFrom = new DateTime(2020, 1, 1, 0, 0, 0),
                    HighSeason = true,
                    Tariffs = new List<Tariff>
                    {
                        new() { StartTime = new TimeOnly(06, 00, 0), EndTime = new TimeOnly(06, 39, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(06, 30, 0), EndTime = new TimeOnly(06, 59, 59), Toll = 30 },
                        new() { StartTime = new TimeOnly(07, 00, 0), EndTime = new TimeOnly(08, 29, 59), Toll = 45 },
                        new() { StartTime = new TimeOnly(08, 30, 0), EndTime = new TimeOnly(08, 59, 59), Toll = 30 },
                        new() { StartTime = new TimeOnly(09, 00, 0), EndTime = new TimeOnly(09, 29, 59), Toll = 20 },
                        new() { StartTime = new TimeOnly(09, 30, 0), EndTime = new TimeOnly(14, 59, 59), Toll = 11 },
                        new() { StartTime = new TimeOnly(15, 00, 0), EndTime = new TimeOnly(15, 29, 59), Toll = 20 },
                        new() { StartTime = new TimeOnly(15, 30, 0), EndTime = new TimeOnly(15, 59, 59), Toll = 30 },
                        new() { StartTime = new TimeOnly(16, 00, 0), EndTime = new TimeOnly(17, 29, 59), Toll = 45 },
                        new() { StartTime = new TimeOnly(17, 30, 0), EndTime = new TimeOnly(17, 59, 59), Toll = 30 },
                        new() { StartTime = new TimeOnly(18, 00, 0), EndTime = new TimeOnly(18, 29, 59), Toll = 20 }
                    }
                },
                new TariffPeriod
                {
                    ValidFrom = new DateTime(2020, 1, 1, 0, 0, 0),
                    Tariffs = new List<Tariff>
                    {
                        new() { StartTime = new TimeOnly(06, 00, 0), EndTime = new TimeOnly(06, 39, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(06, 30, 0), EndTime = new TimeOnly(06, 59, 59), Toll = 25 },
                        new() { StartTime = new TimeOnly(07, 00, 0), EndTime = new TimeOnly(08, 29, 59), Toll = 35 },
                        new() { StartTime = new TimeOnly(08, 30, 0), EndTime = new TimeOnly(08, 59, 59), Toll = 25 },
                        new() { StartTime = new TimeOnly(09, 00, 0), EndTime = new TimeOnly(09, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(09, 30, 0), EndTime = new TimeOnly(14, 59, 59), Toll = 11 },
                        new() { StartTime = new TimeOnly(15, 00, 0), EndTime = new TimeOnly(15, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(15, 30, 0), EndTime = new TimeOnly(15, 59, 59), Toll = 25 },
                        new() { StartTime = new TimeOnly(16, 00, 0), EndTime = new TimeOnly(17, 29, 59), Toll = 35 },
                        new() { StartTime = new TimeOnly(17, 30, 0), EndTime = new TimeOnly(17, 59, 59), Toll = 25 },
                        new() { StartTime = new TimeOnly(18, 00, 0), EndTime = new TimeOnly(18, 29, 59), Toll = 15 }
                    }
                }
            };
        }

        internal static class Essingeleden
        {
            public static readonly IEnumerable<TariffPeriod> Tariffs = new[]
            {
                new TariffPeriod
                {
                    ValidFrom = DateTime.MinValue,
                    ValidTo = new DateTime(2019, 12, 31, 23, 59, 59),
                    Tariffs = new List<Tariff>
                    {
                        new() { StartTime = new TimeOnly(06, 30, 0), EndTime = new TimeOnly(06, 59, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(07, 00, 0), EndTime = new TimeOnly(07, 29, 59), Toll = 22 },
                        new() { StartTime = new TimeOnly(07, 30, 0), EndTime = new TimeOnly(08, 29, 59), Toll = 30 },
                        new() { StartTime = new TimeOnly(08, 30, 0), EndTime = new TimeOnly(08, 59, 59), Toll = 22 },
                        new() { StartTime = new TimeOnly(09, 00, 0), EndTime = new TimeOnly(09, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(09, 30, 0), EndTime = new TimeOnly(14, 59, 59), Toll = 11 },
                        new() { StartTime = new TimeOnly(15, 00, 0), EndTime = new TimeOnly(15, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(15, 30, 0), EndTime = new TimeOnly(15, 59, 59), Toll = 22 },
                        new() { StartTime = new TimeOnly(16, 00, 0), EndTime = new TimeOnly(17, 29, 59), Toll = 30 },
                        new() { StartTime = new TimeOnly(17, 30, 0), EndTime = new TimeOnly(17, 59, 59), Toll = 22 },
                        new() { StartTime = new TimeOnly(18, 00, 0), EndTime = new TimeOnly(18, 29, 59), Toll = 15 }
                    }
                },
                new TariffPeriod
                {
                    ValidFrom = new DateTime(2020, 1, 1, 0, 0, 0),
                    HighSeason = true,
                    Tariffs = new List<Tariff>
                    {
                        new() { StartTime = new TimeOnly(06, 00, 0), EndTime = new TimeOnly(06, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(06, 30, 0), EndTime = new TimeOnly(06, 59, 59), Toll = 27 },
                        new() { StartTime = new TimeOnly(07, 00, 0), EndTime = new TimeOnly(08, 29, 59), Toll = 40 },
                        new() { StartTime = new TimeOnly(08, 30, 0), EndTime = new TimeOnly(08, 59, 59), Toll = 27 },
                        new() { StartTime = new TimeOnly(09, 00, 0), EndTime = new TimeOnly(09, 29, 59), Toll = 20 },
                        new() { StartTime = new TimeOnly(09, 30, 0), EndTime = new TimeOnly(14, 59, 59), Toll = 11 },
                        new() { StartTime = new TimeOnly(15, 00, 0), EndTime = new TimeOnly(15, 29, 59), Toll = 20 },
                        new() { StartTime = new TimeOnly(15, 30, 0), EndTime = new TimeOnly(15, 59, 59), Toll = 27 },
                        new() { StartTime = new TimeOnly(16, 00, 0), EndTime = new TimeOnly(17, 29, 59), Toll = 40 },
                        new() { StartTime = new TimeOnly(17, 30, 0), EndTime = new TimeOnly(17, 59, 59), Toll = 27 },
                        new() { StartTime = new TimeOnly(18, 00, 0), EndTime = new TimeOnly(18, 29, 59), Toll = 20 }
                    }
                },
                new TariffPeriod
                {
                    ValidFrom = new DateTime(2020, 1, 1, 0, 0, 0),
                    Tariffs = new List<Tariff>
                    {
                        new() { StartTime = new TimeOnly(06, 00, 0), EndTime = new TimeOnly(06, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(06, 30, 0), EndTime = new TimeOnly(06, 59, 59), Toll = 22 },
                        new() { StartTime = new TimeOnly(07, 00, 0), EndTime = new TimeOnly(08, 29, 59), Toll = 30 },
                        new() { StartTime = new TimeOnly(08, 30, 0), EndTime = new TimeOnly(08, 59, 59), Toll = 22 },
                        new() { StartTime = new TimeOnly(09, 00, 0), EndTime = new TimeOnly(09, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(09, 30, 0), EndTime = new TimeOnly(14, 59, 59), Toll = 11 },
                        new() { StartTime = new TimeOnly(15, 00, 0), EndTime = new TimeOnly(15, 29, 59), Toll = 15 },
                        new() { StartTime = new TimeOnly(15, 30, 0), EndTime = new TimeOnly(15, 59, 59), Toll = 22 },
                        new() { StartTime = new TimeOnly(16, 00, 0), EndTime = new TimeOnly(17, 29, 59), Toll = 30 },
                        new() { StartTime = new TimeOnly(17, 30, 0), EndTime = new TimeOnly(17, 59, 59), Toll = 22 },
                        new() { StartTime = new TimeOnly(18, 00, 0), EndTime = new TimeOnly(18, 29, 59), Toll = 15 }
                    }
                }
            };
        }
    }

    internal static class Sundsvall
    {
        public static readonly IEnumerable<TariffPeriod> Tariffs = new[]
        {
            new TariffPeriod
            {
                ValidFrom = DateTime.MinValue,
                Tariffs = new List<Tariff>
                {
                    new() { StartTime = new TimeOnly(00, 00, 0), EndTime = new TimeOnly(23, 59, 59), Toll = 9 }
                }
            }
        };
    }

    internal static class Motala
    {
        public static readonly IEnumerable<TariffPeriod> Tariffs = new[]
        {
            new TariffPeriod
            {
                ValidFrom = DateTime.MinValue,
                Tariffs = new List<Tariff>
                {
                    new() { StartTime = new TimeOnly(00, 00, 0), EndTime = new TimeOnly(23, 59, 59), Toll = 5 }
                }
            }
        };
    }
}