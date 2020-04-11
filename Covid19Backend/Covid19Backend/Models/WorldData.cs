using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Models
{
    public class WorldData
    {
        public string Country { get; set; }

        public DateTime Date { get; set; }
        
        public int ConfirmedCases { get; set; }

        public int Death { get; set; }
        public int Recovered { get; set; }
    }
}
