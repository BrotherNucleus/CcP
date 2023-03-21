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
        public Circle(int radius, Color color)
        {
            this.radius = radius;
            this.color = color;
        }
        public int radius { get; set; }

        public Color color { get; set; }
    }
}
