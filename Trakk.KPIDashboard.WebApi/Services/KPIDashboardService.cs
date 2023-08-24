using Microsoft.EntityFrameworkCore;
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


        public async Task<string> GetAccountName()
        {
            var account = await _db.Accounts.FirstOrDefaultAsync();
            return account.Name;
        }

        public async Task<StatisticsDto> GetStatistics()
        {
            var accountsCount = await _db.Accounts.CountAsync();
            var customerCount = await _db.Customers.CountAsync();
            var loraCount = await _db.Hardwares.Where(x => x.HardwareTypeId == (int)Enums.HardwareType.GL52LP).CountAsync();
            var gsmCount = await _db.Hardwares.Where(x => x.HardwareType.HasSimCardSlot).CountAsync();
            var trakkersCount = await _db.Trakkers.CountAsync();

            var statisticsDto = new StatisticsDto
            {
                TotalAccounts = accountsCount,
                TotalCustomers = customerCount,
                TotalLora = loraCount,
                TotalGsm = gsmCount,
                TotalTrakkers = trakkersCount
            };

            return statisticsDto;
        }

        public async Task<LoraGsmGeneralDto> GetLoraGsmGeneral()
        {
            var loraCount = await _db.Hardwares.Where(x => x.HardwareTypeId == (int)Enums.HardwareType.GL52LP).CountAsync();
            var gsmCount = await _db.Hardwares.Where(x => x.HardwareType.HasSimCardSlot).CountAsync();
            var othersCount = await _db.Hardwares.Where(x =>
                x.HardwareTypeId != (int)Enums.HardwareType.GL52LP && !x.HardwareType.HasSimCardSlot).CountAsync();

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
                .Select(x => new TestHeartBeatClass
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


        public async Task<PositionDto> GetPosition()
        {
           // var gsmCount = await _db.Hardwares.Where(x => x.HardwareType.HasSimCardSlot).CountAsync();
           return new PositionDto();
        }
    }

    public class TestHeartBeatClass
    {
        public int TrakkerEventId { get; set; }
        public DateTime  OccuredOn { get; set; }
    }

}
