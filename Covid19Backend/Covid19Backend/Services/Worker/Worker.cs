using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Backend.Services.Worker
{
    public class Worker : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return null; 
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return null;
        }

        public Task TaskRoutine()
        {
            return null;
        }
    }
}
