using Covid19Backend.Services.ExcelService;
using Covid19Backend.Services.GitHubDataAcquiringService;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Backend.Services.Worker
{
    public class StatsWorker: IHostedService
    {
        private readonly IGitService _gitService;
        private readonly IExcelService _excelService;
        public StatsWorker(IGitService gitService,IExcelService excelService)
        {
            _gitService = gitService;
            _excelService = excelService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(TaskRoutine, cancellationToken);
            return Task.CompletedTask; ;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return null;
        }

        public Task TaskRoutine()
        {
            while (true)
            {
                _gitService.GetCovidData();
                _excelService.GenerateStats();


                //Wait 5 minutes till next execution
                DateTime nextStop = DateTime.Now.AddDays(1);
                var timeToWait = nextStop - DateTime.Now;
                var millisToWait = timeToWait.TotalMilliseconds;
                Thread.Sleep((int)millisToWait);
            }
        }
    }
}
