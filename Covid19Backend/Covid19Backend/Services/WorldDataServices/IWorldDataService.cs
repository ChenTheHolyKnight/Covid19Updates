using Covid19Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.WorldDataServices
{
    public interface IWorldDataService
    {
        WorldDataCases GetCasesbyNationForADate(string dateTime, string country);
    }
}
