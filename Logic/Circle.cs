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
        public Circle(int radius, Color clr, int x, int y, int speed)
        {
            Radius = radius;
            color = clr;
            X = x;
            Y = y;
            Speed = speed;
        }
        public int Radius { get; set; }

        public Color color { get; set; }

        public int X { get=> this.X;
            set{
                this.X = value;
                DoesPropertyChanged(nameof(X));
               } 
        }

        public int Y { get =>this.Y;
            set
            {
                this.Y = value;
                DoesPropertyChanged(nameof(Y));
            }
        }

        public int Speed { get; set; }

        public void MoveBall()
        {
            
                X += Speed;
                Y += Speed;

            
        }
    }
}
