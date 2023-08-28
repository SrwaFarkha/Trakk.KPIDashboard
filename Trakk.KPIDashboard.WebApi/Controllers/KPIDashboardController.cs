using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trakk.KPIDashboard.WebApi.Services;
using Trakk.WebApi.DatabaseModels.Models;
using Route = Microsoft.AspNetCore.Routing.Route;

namespace Trakk.KPIDashboard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPIDashboardController : ControllerBase
    {
        private readonly KPIDashboardService _kpiDashboardService;

        public KPIDashboardController(KPIDashboardService kpiDashboardService)
        {
            _kpiDashboardService = kpiDashboardService;
        }

        [HttpGet]
        [Route("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _kpiDashboardService.GetStatistics();
            return Ok(result);
        }

        [HttpGet]
        [Route("Lora-gsm-general")]
        public async Task<IActionResult> GetLoraGsmGeneral()
        {
            var result = await _kpiDashboardService.GetLoraGsmGeneral();
            return Ok(result);
        }

        [HttpGet]
        [Route("heart-beats")]
        public async Task<IActionResult> GetHeartBeats()
        {
            var result = await _kpiDashboardService.GetHeartBeats();
            return Ok(result);
        }

        [HttpGet]
        [Route("positions")]
        public async Task<IActionResult> GetPositions()
        {
            var result = await _kpiDashboardService.GetPositions();
            return Ok(result);
        }

        [HttpGet]
        [Route("positions-latest-12-months")]
        public async Task<IActionResult> GetPositionsLatest12Months()
        {
            var result = await _kpiDashboardService.GetPositionsLatest12Months();
            return Ok(result);
        }

        [HttpGet]
        [Route("heat-map")]
        public async Task<IActionResult> GetHeatMap()
        {
            var result = await _kpiDashboardService.GetHeatMap();
            return Ok(result);
        }

    }
}
