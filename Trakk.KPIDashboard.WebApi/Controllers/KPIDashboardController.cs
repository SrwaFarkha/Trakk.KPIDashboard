using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trakk.KPIDashboard.WebApi.Services;
using Trakk.WebApi.DatabaseModels.Models;
using Route = Microsoft.AspNetCore.Routing.Route;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


        // GET api/<KPIDashboardController>/5
        //[HttpGet()]
        //public string Get()
        //{

        //    var db = new TrakkDbContext();

        //    var accounts = db.Accounts.Where(x => x.AccountId == 1).FirstOrDefault();
        //    return accounts.Email;
        //}

        [HttpGet]
        public async Task<string> GetAccountName()
        {
            return await _kpiDashboardService.GetAccountName();
           
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


    }
}
