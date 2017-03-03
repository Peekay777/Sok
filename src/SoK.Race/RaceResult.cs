using System.Collections.Generic;

namespace SoK.Races
{
    public class RaceResult
    {
        private int _raceId;
        private double _interval;
        List<List<Stage>> _results;

        public List<Runner> Runners { get; set; }

        public List<List<Stage>> Results
        {
            get
            {
                return _results;
            }
        }

        public RaceResult(int raceId, double interval)
        {
            _raceId = raceId; 
            _interval = interval;
            _results = new List<List<Stage>>();
        }

        public void Add(int id, double displacement)
        {
            _results[_results.Count - 1].Add(new Stage { Id = id, Displacement = displacement });
        }

        public void NewStage()
        {
            _results.Add(new List<Stage>());
        }

        public List<int> GetPositions()
        {
            List<int> pos = new List<int>(Runners.Count);

            Runners.Sort(new TimeDisplacementComparer());

            for (int i = 0; i < Runners.Count; i++)
            {
                pos.Add(Runners[i].Id);
            }

            return pos;
        }
    }

    public class Stage
    {
        public int Id { get; set; }
        public double Displacement { get; set; }
    }
}
