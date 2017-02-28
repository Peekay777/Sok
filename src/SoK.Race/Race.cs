using System;
using System.Collections.Generic;

namespace SoK.Races
{
    public class Race
    {
        private int _courseLength;
        private double _interval;
        private double _alapsed;
        private List<Runner> _runners = new List<Runner>();

        public Race(int courseLength, double interval, List<Horse> runners)
        {
            _courseLength = courseLength;
            _interval = interval;

            foreach (Horse horse in runners)
            {
                _runners.Add(new Runner(horse));
            }
        }

        public void LaunchRace()
        {
            int completed = 0;
            _alapsed = 0;

            do
            {
                _alapsed += _interval;
                foreach (Runner runner in _runners)
                {
                    double drag = runner.HorseAttributes.dragCoefficient * Math.Pow(runner.Veleocity, 2);   // R = kv^2
                    double acc = (runner.HorseAttributes.Power - drag) / runner.HorseAttributes.Mass;   // a = (F -R)/m

                    runner.Veleocity += acc * _interval;    // v = u + at
                    runner.Displacement += (runner.Veleocity * _interval) + (acc * Math.Pow(_interval, 2) / 2); // s = ut + (at^2/2)

                    
                    if (runner.Displacement >= _courseLength && runner.IsRunning)
                    {
                        runner.IsRunning = false;
                        runner.FinishingDisplacement = runner.Displacement;
                        runner.FinishingTime = _alapsed;
                        completed++;
                    }
                }
            } while (completed < _runners.Count);


            // find winner
        }
    }
}
