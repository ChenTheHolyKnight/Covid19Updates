using Covid19Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.WebDataScrappingService.WebDataToModelMapper
{
    public class WebDataStatsMapper
    {
        public static DailyStats ConvertData(List<string> data)
        {
            int num = 0;
            data = data.Select(x => x.Replace(",", "")).ToList();
            return new DailyStats() {
                ConfirmedCases = int.TryParse(data[0], out num) ? num : 0,
                ConfirmedNewCases = int.TryParse(data[1], out num) ? num : 0,
                ProbableCases = int.TryParse(data[2], out num) ? num : 0,
                TotalCases = int.TryParse(data[4], out num) ? num : 0,
                TotalNewCases= int.TryParse(data[5], out num) ? num : 0,
                RecoveredCases = int.TryParse(data[8], out num) ? num : 0,
                TotalDeath = int.TryParse(data[10], out num) ? num : 0,
                NewDeathCases = int.TryParse(data[11], out num) ? num : 0
            }
                ;
        }
    }
}
