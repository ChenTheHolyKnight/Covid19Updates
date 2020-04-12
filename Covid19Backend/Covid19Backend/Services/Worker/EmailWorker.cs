using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Backend.Services.Worker
{
    public class EmailWorker : IHostedService
    {
        private readonly IEmailService _emailService;
        public EmailWorker(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(TaskRoutine, cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return null;
        }

        public Task TaskRoutine()
        {
            while (true)
            {
                _emailService.SendEmail();


                //Wait 5 minutes till next execution
                DateTime nextStop = DateTime.Now.AddDays(1);
                var timeToWait = nextStop - DateTime.Now;
                var millisToWait = timeToWait.TotalMilliseconds;
                Thread.Sleep((int)millisToWait);
            }
        }
    }
}
