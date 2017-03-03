using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoK.Races
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public int Mass { get; set; }
        public double dragCoefficient { get; set; }
    }
}
