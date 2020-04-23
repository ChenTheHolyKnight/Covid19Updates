using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services
{
    public interface IEmailService
    {
        public void SendEmail();
        public void RegisterEmail(string email);

    }
}
