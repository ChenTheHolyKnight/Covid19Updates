using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19Backend.Services.WebDataScrappingService;
using Microsoft.AspNetCore.Mvc;

namespace Covid19Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebDataController : ControllerBase
    {
        private readonly IWebDataScrapingService _service;
        public WebDataController(IWebDataScrapingService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<string> GetWebData()
        {
            
            return Ok(_service.GetDailySummary());
        }
    }
}