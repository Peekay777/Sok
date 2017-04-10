using SoK.Races.Utils;
using System.Collections.Generic;

namespace SoK.Races
{
    public class Race
    {
        private RaceInfo _raceInfo;
        private double _interval;
        private double _alapsed;
        private List<Runner> _runners;
        private RaceResult _results;

        public Race(RaceInfo raceInfo, double interval)
        {
            _raceInfo = raceInfo;
            _interval = interval;
            _results = new RaceResult(_raceInfo.Id, interval);
            _runners = new List<Runner>();

            foreach (Horse horse in _raceInfo.Runners)
            {
                _runners.Add(new Runner(horse.Id, horse));
            }
        }

        public RaceResult RunRace()
        {
            int runersCompleted = 0;
            _alapsed = 0;

            do
            {
                _alapsed += _interval;
                _results.NewStage();
                runersCompleted = PerformIntervalForRunners(runersCompleted);
            } while (runersCompleted < _runners.Count);

            _results.Runners = _runners;

            return _results;
        }

        private int PerformIntervalForRunners(int runersCompleted)
        {
            foreach (Runner runner in _runners)
            {
                double drag = Formula.Drag(runner.HorseAttributes.dragCoefficient, runner.Velocity);
                double acc = Formula.Acceleration(runner.HorseAttributes.Power, drag, runner.HorseAttributes.Mass);

                runner.Velocity += Formula.Velocity(acc, _interval);
                runner.Displacement += Formula.Displacement(runner.Velocity, _interval, acc);

                _results.Add(runner.Id, runner.Displacement);

                if (runner.Displacement >= _raceInfo.CourseLength && runner.IsRunning)
                {
                    runner.IsRunning = false;
                    runner.FinishingDisplacement = runner.Displacement;
                    runner.FinishingTime = _alapsed;
                    runersCompleted++;
                }
            }

            return runersCompleted;
        }
    }
}
