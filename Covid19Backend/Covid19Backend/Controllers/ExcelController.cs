using Covid19Backend.Services.ExcelService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcelController:ControllerBase
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> SendEmail()
        {
            _excelService.GenerateStats();
            return Ok("Generated");
        }
    }
}
