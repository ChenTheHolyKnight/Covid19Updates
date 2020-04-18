using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Models
{
    public class DailyStats
    {
        public int TotalCases { get; set; }
        public int TotalNewCases { get; set; }

        public int ConfirmedCases { get; set; }
        public int ConfirmedNewCases { get; set; }

        public int ProbableCases { get; set; }
        public int ProbableNew { get; set; }

        public int RecoveredCases { get; set; }
        public int RecoveredNew { get; set; }

        public int TotalDeath { get; set; }
        public int NewDeathCases { get; set; }

        public string ReportDate { get; set; }

    }
}
