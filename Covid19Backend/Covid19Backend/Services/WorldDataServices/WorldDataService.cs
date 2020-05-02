using Covid19Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.WorldDataServices
{
    public class WorldDataService: IWorldDataService
    {
        private readonly IStats _stats;
        public WorldDataService(IStats stats)
        {
            _stats = stats; 
        }

        public WorldDataCases GetCasesbyNationForADate(string dateTime,string country)
        {
            WorldDataCases worldDataCases = new WorldDataCases();
            foreach(WorldData data in _stats.Data)
            {
                if (data.Country.Equals(country) && IsSameDate(dateTime,data.Date))
                {
                    worldDataCases.ConfirmedCases += data.ConfirmedCases;
                    worldDataCases.Deaths += data.Death;
                    worldDataCases.Recovered += data.Recovered;
                }
            }

            return worldDataCases;
        }


        private bool IsSameDate(string date1,DateTime date2)
        {
            string[] dateStrs = date1.Split("-");
            string day = date2.Day.ToString();
            string month = date2.Month.ToString();
            string year = date2.Year.ToString();
            if (dateStrs[0].Equals(date2.Day.ToString()) && dateStrs[1].Equals(date2.Month.ToString()) && dateStrs[2].Equals(date2.Year.ToString()))
                return true;
            return false;
        }
    }
}
