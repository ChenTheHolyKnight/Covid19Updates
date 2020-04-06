using Covid19Backend.Services.Formatter;
using Covid19Backend.Services.WebDataScrappingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Covid19Backend.Services
{
    public class EmailService:IEmailService
    {
        private readonly IEmailBodyFormatter _emailBodyFormatter;
        private readonly IWebDataScrapingService _webDataScrapingService;
        public EmailService(IEmailBodyFormatter emailBodyFormatter, IWebDataScrapingService webDataScrappingService)
        {
            _emailBodyFormatter = emailBodyFormatter;
            _webDataScrapingService = webDataScrappingService;
        }
        public void SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("covid19info1@gmail.com");
                mail.To.Add("czha959@aucklanduni.ac.nz");
                mail.Subject = "Covid-19 Updates";
                string body = _emailBodyFormatter.GenerateEmailBody(_webDataScrapingService.GetDailySummary());
                mail.Body = body;
                mail.IsBodyHtml = true;
                

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("covid19info1@gmail.com", "zc83608810");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
