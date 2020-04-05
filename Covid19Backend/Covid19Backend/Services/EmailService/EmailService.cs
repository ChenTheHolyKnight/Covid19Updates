using Covid19Backend.Services.Formatter;
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
        public EmailService(IEmailBodyFormatter emailBodyFormatter)
        {
            _emailBodyFormatter = emailBodyFormatter;
        }
        public void SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("covid19info1@gmail.com");
                mail.To.Add("czha959@aucklanduni.ac.nz");
                mail.Subject = "Covid-19 Updates";
                string body = _emailBodyFormatter.GenerateEmailBody();
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
