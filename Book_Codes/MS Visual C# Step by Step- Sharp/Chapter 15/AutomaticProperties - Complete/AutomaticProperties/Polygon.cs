using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticProperties
{
    class Polygon
    {
        public int NumSides { get; set; }
        public double SideLength { get; set; }

        public Polygon()
        {
            this.NumSides = 4;
            this.SideLength = 10.0;
        }
    }
}
