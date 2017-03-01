using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoK.Races
{
    public class Runner
    {
        public int Id { get; set; }
        public Horse HorseAttributes { get; set; }
        public double Velocity { get; set; }
        public double Displacement { get; set; }

        public bool IsRunning { get; set; }
        public double FinishingDisplacement { get; set; }
        public double FinishingTime { get; set; }

        public Runner(int id, Horse horse)
        {
            Id = id;
            HorseAttributes = horse;
            Velocity = 0;
            Displacement = 0;
            IsRunning = true;
            FinishingDisplacement = 0;
            FinishingTime = 0;
        }
    }
}
