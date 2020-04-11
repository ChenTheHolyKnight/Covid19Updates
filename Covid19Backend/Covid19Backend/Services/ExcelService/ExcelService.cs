using Covid19Backend.Models;
using Covid19Backend.Services.Common;
using Covid19Backend.Services.ExcelService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.ExcelService
{
    public class ExcelService :IExcelService
    {
        private readonly IStats _stats;
        private readonly IExcelHelper _excel;
        private readonly IDirectoryHelper _directory;

        public ExcelService(IStats stats,IExcelHelper excel,IDirectoryHelper directory)
        {
            _stats = stats;
            _excel = excel;
            _directory = directory;
        }

        public void GenerateStats()
        {
            List<string> fileNames = _directory.GetFileNamesInDirectory("./Data/csse_covid_19_data/csse_covid_19_daily_reports");
           List<WorldData> data= _excel.ReadExcel("./Data/csse_covid_19_data/csse_covid_19_daily_reports/01-22-2020.csv");
        }
    }
}
