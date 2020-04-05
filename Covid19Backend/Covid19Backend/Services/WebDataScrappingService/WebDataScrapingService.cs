using Covid19Backend.Models;
using Covid19Backend.Services.WebDataScrappingService.WebDataToModelMapper;
using Covid19Backend.Services.WebDataScrappingService.WebScrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.WebDataScrappingService
{
    public class WebDataScrapingService: IWebDataScrapingService
    {
        
        public WebDataScrapingService()
        {

        }

        public DailyStats GetDailySummary()
        {
            HealthWebScrapper scrapper = new HealthWebScrapper();
            List<string> data = scrapper.GetWebData();
            return WebDataStatsMapper.ConvertData(data); 
        }



        
    }
}
