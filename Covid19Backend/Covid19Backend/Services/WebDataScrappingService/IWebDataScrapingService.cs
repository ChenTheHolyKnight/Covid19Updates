using Covid19Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.WebDataScrappingService
{
    public interface IWebDataScrapingService
    {
        public DailyStats GetDailySummary();

    }
}
