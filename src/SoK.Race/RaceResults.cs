using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoK.Races
{
    public class RaceResults
    {
        public Dictionary<double, Data> Results { get; set; }

        public RaceResults()
        {
            Results = new Dictionary<double, Data>();
        }
    }

    public class Data
    {

        public double Displacement { get; set; }
    }
}
