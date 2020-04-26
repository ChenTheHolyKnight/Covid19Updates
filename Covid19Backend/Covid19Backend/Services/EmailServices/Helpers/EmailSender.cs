using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Covid19Backend.Models;
using Covid19Backend.Services.Formatter;

namespace Covid19Backend.Services.EmailServices.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailBodyFormatter _formatter;
        public EmailSender(IEmailBodyFormatter formatter)
        {
            _formatter = formatter;
        }

        public void SendEmail(DailyStats stats, string email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("covid19info1@gmail.com");
                mail.To.Add(email);
                //mail.To.Add("czha959@aucklanduni.ac.nz");
                mail.Subject = "Covid-19 Updates";
                string body = _formatter.GenerateEmailBody(stats);
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
