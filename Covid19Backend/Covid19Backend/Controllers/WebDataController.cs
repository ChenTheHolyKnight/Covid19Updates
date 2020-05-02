using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19Backend.Services.WebDataScrappingService;
using Covid19Backend.Services.WorldDataServices;
using Microsoft.AspNetCore.Mvc;

namespace Covid19Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebDataController : ControllerBase
    {
        private readonly IWebDataScrapingService _service;
        private readonly IWorldDataService _worldDataService;
        public WebDataController(IWebDataScrapingService service, IWorldDataService worldDataService)
        {
            _service = service;
            _worldDataService = worldDataService;
        }

        [HttpGet]
        public ActionResult<string> GetWebData()
        {
            
            return Ok(_service.GetDailySummary());
        }

        [HttpGet("nation_date")]
        public ActionResult<int> GetWebDataByNationandDate([FromQuery]string nation,[FromQuery]string date)
        {
            //_worldDataService.GetCasesbyNationForADate(date,nation);
            return Ok(_worldDataService.GetCasesbyNationForADate(date, nation));
        }
    }
}