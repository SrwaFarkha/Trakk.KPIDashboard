using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CongestionTaxProcessor.Enums;
using CongestionTaxProcessor.Models;
using CongestionTaxProcessor.Models.Filters;
using CongestionTaxProcessor.Models.TaxAreas;
using NetTopologySuite.Geometries;
using Trakk.WebApi.DatabaseModels.CongestionTaxContext.Models.Filters;
using Trakk.WebApi.Models;

namespace Trakk.WebApi.DatabaseModels.CongestionTaxContext.Data;

public static class Areas
{
    public static Dictionary<string, ITaxBorder> AreaGeofences => new ()
    {
        {"Göteborg", GetArea(Area.Göteborg)?[TaxBorder.Göteborg]! },
        {"Stockholm Essingeleden", GetArea(Area.Stockholm)?[TaxBorder.Essingeleden]! },
        {"Stockholm Innerstaden", GetArea(Area.Stockholm)?[TaxBorder.Innerstaden]! },
        {"Motala", GetArea(Area.Motala)?[TaxBorder.Motala]! },
        {"Sundsvall", GetArea(Area.Sundsvall)?[TaxBorder.Sundsvall]! },
    };
    public static TaxArea? GetArea(Area? area) => 
        area switch
        {
            Area.Göteborg => Göteborg,
            Area.Motala => Motala,
            Area.Stockholm => Stockholm,
            Area.Sundsvall => Sundsvall,
            _ => null
        };
    

    public static readonly TaxArea? Göteborg =
        AreaBuilder.Start(Area.Göteborg)
            .SetSeasons(Seasons.Göteborg.Excepted.All)
            .SetMaxToll(60).SetMultiPassTimeLimit(TimeSpan.FromMinutes(60))
            .AddFilter<WeekendFilter>()
            .AddFilter<MultiPassFilter>()
            .AddFilter<MaxTollPerDayFilter>()
            .AddBorder(
                TaxBorder.Göteborg, 
                Tariffs.Göteborg.Tariffs.ToList())
            .Build();


    public static readonly TaxArea? Stockholm =
        AreaBuilder.Start(Area.Stockholm)
            .SetSeasons(Seasons.Stockholm.All)
            .SetMaxToll(105)
            .SetHighSeasonMaxToll(135)
            .AddFilter<WeekendFilter>()
            .AddFilter<EssingeFilter>()
            .AddFilter<MaxTollPerDayFilter>()
            .AddBorder(TaxBorder.Essingeleden,
                Tariffs.Stockholm.Essingeleden.Tariffs.ToList())
            .AddBorder(TaxBorder.Innerstaden,
                Tariffs.Stockholm.Innerstaden.Tariffs.ToList())
            .Build();


    public static readonly TaxArea? Sundsvall =
        AreaBuilder.Start(Area.Sundsvall)
            .AddBorder(TaxBorder.Sundsvall, Tariffs.Sundsvall.Tariffs.ToList())
            .Build();
    public static readonly TaxArea? Motala =
        AreaBuilder.Start(Area.Motala)
            .AddBorder(TaxBorder.Motala, Tariffs.Motala.Tariffs.ToList())
            .Build();


    private class AreaBuilder
    {
        private TaxArea _area;

        public AreaBuilder(Area area)
        {
            _area = new TaxArea
            {
                Id = area
            };
        }

        public static AreaBuilder Start(Area area)
        {
            return new AreaBuilder(area);
        }
        
        public AreaBuilder AddBorder(TaxBorder id, List<TariffPeriod> periods)
        {
            ITaxBorder border = id switch
            {
                TaxBorder.Göteborg => new GöteborgTaxBorder(_area, periods),
                TaxBorder.Essingeleden => new EssingeTaxBorder(_area, periods),
                TaxBorder.Innerstaden => new InnerstadenTaxBorder(_area, periods),
                TaxBorder.Motala => new MotalaTaxBorder(_area, periods),
                TaxBorder.Sundsvall => new SundsvallTaxBorder(_area, periods),
                _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
            };

            _area.Borders.Add(border);
            return this;
        }
        public AreaBuilder SetSeasons(List<Season> seasons)
        {
            _area.Seasons = seasons;
            return this;
        }

        public AreaBuilder AddFilter<TFilter>(params object?[] extraArgs) where TFilter : IFilter
        {
            var args = new object[] { _area };
            if (extraArgs.Any())
                args = args.Concat(extraArgs).ToArray();
            
            var filter = (TFilter)Activator.CreateInstance(typeof(TFilter), args);
            _area.Filters.Add(filter);
            return this;
        }
        
        public AreaBuilder SetMaxToll(int maxToll)
        {
            _area.MaxTollPerDay = maxToll;
            return this;
        }
        public AreaBuilder SetHighSeasonMaxToll(int maxToll)
        {
            _area.HighSeasonMaxTollPerDay = maxToll;
            return this;
        }

        public AreaBuilder SetMultiPassTimeLimit(TimeSpan timeSpan)
        {
            _area.MultiPassTimeLimit = timeSpan;
            return this;
        }

        public TaxArea Build()
        {
            return _area;
        }
        
    }
    
}