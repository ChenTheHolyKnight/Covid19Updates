using Covid19Backend.Services.GitHubDataAcquiringService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitController: ControllerBase
    {
        private readonly IGitService _gitService;
        public GitController(IGitService gitService)
        {
            _gitService = gitService;
        }

        [HttpGet]
        public ActionResult<string> GetGitRepoData()
        {
            _gitService.GetCovidData();
            return Ok("Cloned");
        }
    }
}
