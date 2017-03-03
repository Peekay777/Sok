using System;
using System.Collections.Generic;

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

    public class TimeDisplacementComparer : IComparer<Runner>
    {
        public int Compare(Runner x, Runner y)
        {
            if (x.FinishingTime > y.FinishingTime)
            {
                return 1;
            }
            else if (x.FinishingTime < y.FinishingTime)
            {
                return -1;
            }
            else    // finishing times are equal
            {
                if (x.FinishingDisplacement > y.FinishingDisplacement)
                {
                    return 1;
                }
                else if (x.FinishingDisplacement < y.FinishingDisplacement)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
