using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Models
{
    public interface IStats
    {
        public List<WorldData> Data { get; set; }
    }
}
