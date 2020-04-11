using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Models
{
    public class Stats:IStats
    {
        public Stats()
        {
            Data = new List<WorldData>();
        }
        public List<WorldData> Data{ get; set; }
    }
}
