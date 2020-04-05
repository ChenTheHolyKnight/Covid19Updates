using Covid19Backend.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.WebDataScrappingService.WebScrappers
{
    public class HealthWebScrapper
    {
        private const string MINISTTY_OF_HEALTH_URL = "https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-situation/covid-19-current-cases";

        public List<string> GetWebData()
        {
            List<string> dataList = new List<string>();
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(MINISTTY_OF_HEALTH_URL);

                IList<IWebElement> allElement = driver.FindElements(By.TagName("td"));
                
                foreach (IWebElement element in allElement.Take(12))
                {
                    dataList.Add(element.Text);                              
                }

            }
            return dataList;
        }
    }
}
