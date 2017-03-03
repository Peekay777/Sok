using System;
using Xunit;
using SoK.Races;
using System.Collections.Generic;

namespace SoK.Test
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            List<Horse> runners = new List<Horse> {
                new Horse { Id=1, Name="Tom", Power = 16000, Mass = 514, dragCoefficient = 0.8 },
                new Horse { Id=2, Name="Dick", Power = 15000, Mass = 500, dragCoefficient = 0.8 }
            };

            RaceResult raceResult = new RaceResult(1, 0.02);
            raceResult.Runners = new List<Runner>();
            for (int i = 0; i < runners.Count; i++)
            {
                raceResult.Runners.Add(new Runner(i, runners[i]));
            }

            raceResult.Runners[0].FinishingDisplacement = 0.5;
            raceResult.Runners[0].FinishingTime = 1.0;
            raceResult.Runners[1].FinishingDisplacement = 1.0;
            raceResult.Runners[1].FinishingTime = 1.0;

            List<int> res =  raceResult.GetPositions();

            Assert.Equal(res[0], 0);
            Assert.Equal(res[1], 1);


            raceResult.Runners[0].FinishingDisplacement = 1.0;
            raceResult.Runners[0].FinishingTime = 0.5;
            raceResult.Runners[1].FinishingDisplacement = 1.0;
            raceResult.Runners[1].FinishingTime = 1.0;

            List<int> res2 = raceResult.GetPositions();

            Assert.Equal(res2[0], 0);
            Assert.Equal(res2[1], 1);

        }
    }
}
