using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.GitHubDataAcquiringService
{
    public interface IGitService
    {
        public void GetCovidData();
    }
}
