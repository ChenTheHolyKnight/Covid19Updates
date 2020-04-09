using Covid19Backend.Services.GitHubDataAcquiringService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.GitHubDataAcquiringService
{
    public class GitService:IGitService
    {
        private readonly IGitHelper _gitHelper;
        public GitService(IGitHelper gitHelper)
        {
            _gitHelper = gitHelper;
        }

        public void GetCovidData()
        {
            _gitHelper.Clone();
        }
    }
}
