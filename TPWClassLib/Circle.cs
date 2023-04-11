using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWClassLib
{
    public class Circle
    {
        public Circle(int radius, Color clr, int x, int y)
        {
            Radius = radius;
            color = clr;
            X = x;
            Y = y;
        }
        public int Radius { get; set; }

        public Color color { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
