using Covid19Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.EmailServices.Helpers
{
    public interface IEmailSender
    {
        public void SendEmail(DailyStats stats,string email);
    }
}
