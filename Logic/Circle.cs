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
        private int Radiusval;
        private Random rand = new Random();
        private int XDir = 0;
        private int YDir = 0;

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
            while(XDir == 0 || YDir == 0)
            {
                XDir = rand.Next(-2, 2);
                YDir = rand.Next(-2, 2);
            }
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
                //DoesPropertyChanged(nameof(Speed));
            } 
        }

        public void MoveBall()
        {
            while (true)
            {
                if(X > 700 - Radius - 4 || X < 4) { XDir *= -1; }
                if (Y > 700 - Radius - 4 || Y < 4) { YDir *= -1; }
                X = X + XDir*Speed;
                Y = Y + YDir*Speed;
                Thread.Sleep(10);
            }
            
        }
    }
}
