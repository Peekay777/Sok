using System;
using System.Collections.Generic;
using SoK.Races.Utils;

namespace SoK.Races
{
    public class Race
    {
        private int _courseLength;
        private double _interval;
        private double _alapsed;
        private List<Runner> _runners = new List<Runner>();
        private RaceResults _results;

        public Race(int courseLength, double interval, List<Horse> runners)
        {
            _courseLength = courseLength;
            _interval = interval;

            for (int i = 0; i < runners.Count; i++)
            {
                _runners.Add(new Runner(i, runners[i]));
            }
        }

        public void StartRace()
        {
            int completed = 0;
            _alapsed = 0;

            do
            {
                _alapsed += _interval;
                completed = PerformIntervalForRunners(completed);
            } while (completed < _runners.Count);


            // find winner
        }

        private int PerformIntervalForRunners(int completed)
        {
            foreach (Runner runner in _runners)
            {
                double drag = Formula.Drag(runner.HorseAttributes.dragCoefficient, runner.Velocity);
                double acc = Formula.Acceleration(runner.HorseAttributes.Power, drag, runner.HorseAttributes.Mass);

                runner.Velocity += Formula.Velocity(acc, _interval);
                runner.Displacement += Formula.Displacement(runner.Velocity, _interval, acc);



                if (runner.Displacement >= _courseLength && runner.IsRunning)
                {
                    runner.IsRunning = false;
                    runner.FinishingDisplacement = runner.Displacement;
                    runner.FinishingTime = _alapsed;
                    completed++;
                }
            }

            return completed;
        }
    }
}
