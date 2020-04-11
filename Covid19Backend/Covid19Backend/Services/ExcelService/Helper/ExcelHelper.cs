using Covid19Backend.Models;
using Covid19Backend.Services.Common;
using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.ExcelService.Helper
{
    public class ExcelHelper: IExcelHelper
    {
        private readonly IDirectoryHelper _directory;

        public ExcelHelper(IDirectoryHelper directory)
        {
            _directory = directory;
        }
        public List<WorldData> ReadExcel(string filePath)
        {
            List<WorldData> dataList = new List<WorldData>();
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                var records = csv.GetRecords<dynamic>();
                foreach (var record in records)
                {
                   WorldData data = DynamicToModel(record, filePath);
                   dataList.Add(data);
                }
            }

            return dataList;

        }

        private WorldData DynamicToModel(ExpandoObject record,string filePath)
        {
            IDictionary<string, object> recordDict = record;

            string recoveredKey = (from o in recordDict where o.Key.ToLower().Contains("recovered") select o.Key).FirstOrDefault();
            string deathKey = (from o in recordDict where o.Key.ToLower().Contains("death") select o.Key).FirstOrDefault();
            string confirmedKey = (from o in recordDict where o.Key.ToLower().Contains("confirmed") select o.Key).FirstOrDefault();
            string countryKey = (from o in recordDict where o.Key.ToLower().Contains("country") select o.Key).FirstOrDefault();
            int num = 0;

            DateTime date;            
            date = DateTime.TryParseExact(_directory.ExtractDateFromFileName(filePath), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ? date : DateTime.MinValue;

            return new WorldData
            {
                Country = recordDict[countryKey].ToString(),
                Date = date,
                ConfirmedCases = int.TryParse(recordDict[confirmedKey].ToString(), out num) ? num : 0,
                Recovered = int.TryParse(recordDict[recoveredKey].ToString(),out num)?num:0,
                Death = int.TryParse(recordDict[deathKey].ToString(), out num) ? num : 0
            };
        }
    }
}
