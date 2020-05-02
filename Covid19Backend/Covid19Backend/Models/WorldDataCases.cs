using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Models
{
    public class WorldDataCases
    {
        public int ConfirmedCases { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
