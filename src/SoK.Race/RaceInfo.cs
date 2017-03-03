using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoK.Races
{
    public class RaceInfo
    {
        public int Id { get; set; }
        public int CourseLength { get; set; }
        public List<Horse> Runners { get; set; }
    }
}
