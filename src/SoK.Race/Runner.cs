using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoK.Races
{
    public class Runner
    {
        public Horse HorseAttributes { get; set; }
        public double Veleocity { get; set; }
        public double Displacement { get; set; }

        public bool IsRunning { get; set; }
        public double FinishingDisplacement { get; set; }
        public double FinishingTime { get; set; }

        public Runner(Horse horse)
        {
            HorseAttributes = horse;
            Veleocity = 0;
            Displacement = 0;
            IsRunning = true;
            FinishingDisplacement = 0;
            FinishingTime = 0;
        }
    }
}
