using Covid19Backend.Models.Database;
using Covid19Backend.Repositories;
using Covid19Backend.Services.EmailServices.Helpers;
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
        private readonly IEmailRepository _emailRepository;
        private readonly IEmailSender _emailSender;
        public EmailService(IEmailBodyFormatter emailBodyFormatter, IWebDataScrapingService webDataScrappingService,IEmailRepository emailRepository,IEmailSender emailSender)
        {
            _emailBodyFormatter = emailBodyFormatter;
            _webDataScrapingService = webDataScrappingService;
            _emailRepository = emailRepository;
            _emailSender = emailSender;
        }
        public void SendEmail()
        {
            List<UserProfile> destEmails = _emailRepository.Get();

            destEmails.ForEach(item => _emailSender.SendEmail(_webDataScrapingService.GetDailySummary(),item.Email));
        }

        public void RegisterEmail(string email)
        {
            _emailRepository.AddEmail(email);
        }

        public void UnregisterEmail(string email)
        {
            _emailRepository.Delete(email);
        }
    }
}
