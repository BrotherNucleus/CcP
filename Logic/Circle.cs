using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Circle: ICircle
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void DoesPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
