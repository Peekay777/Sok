using System;
using System.Collections.Generic;
using SoK.Races;

namespace SoK.Console
{
    public class Program
    {
        private const int CourseLength = 1207;
        private const double Interval = 0.02;

        private static List<Horse> Runners = new List<Horse> {
                new Horse { Id=1, Name="Tom", Power = 16000, Mass = 514, dragCoefficient = 0.8 },
                new Horse { Id=2, Name="Dick", Power = 15000, Mass = 500, dragCoefficient = 0.8 }
            };

        public static void Main(string[] args)
        {
            RaceInfo raceInfo = new RaceInfo {
                Id = 0,
                CourseLength = CourseLength,
                Runners = Runners
            };

            Race race = new Race(raceInfo, Interval);
            RaceResult result = race.RunRace();

            List<int> positions = result.GetPositions();

            for (int i = 0; i < positions.Count; i++)
            {
                System.Console.WriteLine("Position {0} is {1}", i + 1, Runners.Find(h => h.Id == positions[i]).Id);
            }

            System.Console.ReadLine();
        }
    }
}
