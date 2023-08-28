using Microsoft.EntityFrameworkCore;
using NetTopologySuite.GeometriesGraph;
using Trakk.KPIDashboard.Models.KPIDashboardModels;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.Models;

namespace Trakk.KPIDashboard.WebApi.Services
{
    public class KPIDashboardService
    {
        private readonly TrakkDbContext _db;

        public KPIDashboardService(TrakkDbContext db)
        {
            _db = db;
        }

        public async Task<StatisticsDto> GetStatistics()
        {
            var data = await _db.Customers
                .Include(x => x.Accounts)
                .Include(x => x.Hardwares)
                .ThenInclude(x => x.HardwareType)
                .Include(x => x.Trakkers).ToListAsync();

            var hardwares = await _db.Hardwares.Include(x => x.HardwareType).ToListAsync();
            var statisticsDto = new StatisticsDto
            {
                TotalAccounts = data.SelectMany(x => x.Accounts).Count(),
                TotalCustomers = data.Count,
                TotalLora = hardwares.Count(x => x.HardwareTypeId == (int)Enums.HardwareType.GL52LP),
                TotalGsm = hardwares.Count(x => x.HardwareType.HasSimCardSlot),
                TotalTrakkers = data.SelectMany(x => x.Trakkers).Count()
            };

            return statisticsDto;
        }

        public async Task<LoraGsmGeneralDto> GetLoraGsmGeneral()
        {
            var hardwares = await _db.Hardwares.Include(x => x.HardwareType).ToListAsync();

            var loraCount = hardwares
                .Count(x => x.HardwareTypeId == (int)Enums.HardwareType.GL52LP);
            var gsmCount = hardwares
                .Count(x => x.HardwareType.HasSimCardSlot);
            var othersCount = hardwares
                .Count(x => x.HardwareTypeId != (int)Enums.HardwareType.GL52LP && !x.HardwareType.HasSimCardSlot);

            var loraGsmGeneralDto = new LoraGsmGeneralDto
            {
                TotalLora = loraCount,
                TotalGsm = gsmCount,
                Others = othersCount
            };

            return loraGsmGeneralDto;
        }

        public async Task<HeartBeatDto> GetHeartBeats()
        {
            var heartBeats = await _db.TrakkerEvents
                .Where(x => x.TrakkerEventTypeId == Enums.TrakkerEventType.Heartbeat)
                .OrderBy(x => x.OccuredOn)
                .Select(x => new HeartBeats
                {
                    TrakkerEventId = x.TrakkerEventId,
                    OccuredOn = x.OccuredOn,
                })
                .Take(500)// dont take 500 
                .ToListAsync();

            DateTime now = DateTime.UtcNow;
            DateTime todayStart = now.Date;
            DateTime yesterday = now.AddDays(-1);

            var heartBeatsToday = heartBeats.Count(x => x.OccuredOn > todayStart);
            var heartBeatsYesterday = heartBeats.Count(x => x.OccuredOn > yesterday);
            var heartBeatsOtherDays = heartBeats.Count(x => x.OccuredOn < yesterday);
            var heartBeatDto = new HeartBeatDto
            {
                HeartBeatCountToday = heartBeatsToday,
                HeartBeatCountYesterday = heartBeatsYesterday,
                HeartBeatCountEarlier = heartBeatsOtherDays
            };

            return heartBeatDto;
        }

        public async Task<PositionDto> GetPositions()
        {
            var positions = await _db.Positions
                .Select(x => new PositionsData
                {
                    PositionId = x.PositionId,
                    CreatedOn = x.CreatedOn,
                }).ToListAsync();

            DateTime now = DateTime.UtcNow;
            DateTime todayStart = now.Date;
            DateTime yesterday = now.AddDays(-1);

            var positionsToday = positions.Count(x => x.CreatedOn > todayStart);
            var positionsYesterday = positions.Count(x => x.CreatedOn > yesterday);
            var positionsOtherDays = positions.Count(x => x.CreatedOn < yesterday);
            var positionDto = new PositionDto
            {
                PositionCountToday = positionsToday,
                PositionCountYesterday = positionsYesterday,
                PositionCountEarlier = positionsOtherDays
            };

            return positionDto;
        }


        public async Task<PositionCountContext> GetPositionsLatest12Months()
        {

            DateTime now = DateTime.UtcNow;
            DateTime startDate = now.AddMonths(-11);

            var positionCountsByMonth = await _db.Positions
                .Where(p => p.CreatedOn >= startDate)
                .GroupBy(p => new { p.CreatedOn.Year, p.CreatedOn.Month })
                .Select(group => new PositionCountDto
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    Count = group.Count()
                })
                .OrderByDescending(entry => entry.Year)
                .ThenByDescending(entry => entry.Month)
                .ToListAsync();


            int totalPositions = positionCountsByMonth.Sum(entry => entry.Count);

            var result = new PositionCountContext
            {
                TotalPositions = totalPositions,
                PositionCount = positionCountsByMonth
            };

            return result;

        }

        public async Task<List<TrakkerLatestPositionDto>> GetHeatMap()
        {
            var trakkerPositions = await _db.Trakkers
                .Where(x => x.LatestPositionEventId != null)
                .Select(x => x.LatestPositionEvent.Position)
                .ToListAsync();

            var collectedData = trakkerPositions
                .GroupBy(position => new { position.Latitude, position.Longitude })
                .Select(group => new TrakkerLatestPositionDto
                {
                    Latitude = group.Key.Latitude,
                    Longitude = group.Key.Longitude,
                })
                .ToList();

            return collectedData;
        }
    }
}
