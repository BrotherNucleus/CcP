using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Logic
{
    public class Circle: ICircle
    {
        private int Xval;
        private int Yval;
        private int Speedval;
        private int Radiusval = 5;

        public event PropertyChangedEventHandler PropertyChanged;

        public void DoesPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Circle(int radius, Color clr, int x, int y, int speed)
        {
            Radiusval = radius;
            color = clr;
            Xval = x;
            Yval = y;
            Speedval = speed;
        }
        public int Radius
        {
            get => this.Radiusval;
            set
            {
                this.Radius = value;
                //DoesPropertyChanged(nameof(Radiusval));
            }
        }

        public Color color { get; set; }

        public int X
        {
            get => this.Xval;
            set
            {
                
                this.Xval = value;
                DoesPropertyChanged(nameof(X));
            }
        }

        public int Y
        {
            get => this.Yval;
            set
            {
                this.Yval = value;
                DoesPropertyChanged(nameof(Y));
            }
        }

        public int Speed 
        { get=> this.Speedval;

            set 
            {
                this.Speedval = value;
                DoesPropertyChanged(nameof(Speed));
            } 
        }

        public void MoveBall()
        {
            while (true)
            {
                X = X + Speed;
                Y = Y + Speed;
                Thread.Sleep(1);
            }
            
        }
    }
}
