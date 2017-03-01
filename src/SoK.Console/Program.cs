using System;
using System.Collections.Generic;
using SoK.Races;

namespace SoK.Console
{
    public class Program
    {
        private const int CourseLength = 1207;
        private const double Interval = 0.02;

        public static void Main(string[] args)
        {
            List<Horse> runners = new List<Horse> {
                new Horse { Power = 16000, Mass = 514, dragCoefficient = 0.8 },
                new Horse { Power = 15000, Mass = 500, dragCoefficient = 0.8 }
            };
            Race race = new Race(CourseLength, Interval, runners);
            race.StartRace();
        }
    }
}
