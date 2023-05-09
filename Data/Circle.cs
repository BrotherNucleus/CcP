using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class Circle : ICircle
    {
        private float Xval;
        private float Yval;
        private float Speedval;
        private float Radiusval;
        private Random rand = new Random();
        public float XDir = 0;
        public float YDir = 0;
        public bool isCollision=false;
        public float cordinates =1;
        public event PropertyChangedEventHandler PropertyChanged;

        public void DoesPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Circle(float radius, Color clr, float x, float y, float speed)
        {
            Radiusval = radius;
            color = clr;
            Xval = x;
            Yval = y;
            Speedval = speed;
            while (XDir == 0 || YDir == 0)
            {
                XDir = rand.Next(-2, 2);
                YDir = rand.Next(-2, 2);
            }
        }
        public float Radius
        {
            get => this.Radiusval;
            set
            {
                this.Radius = value;
                DoesPropertyChanged(nameof(Radius));
            }
        }

        public Color color { get; set; }

        public float X
        {
            get => this.Xval;
            set
            {

                this.Xval = value;
                DoesPropertyChanged(nameof(X));
            }
        }

        public float Y
        {
            get => this.Yval;
            set
            {
                this.Yval = value;
                DoesPropertyChanged(nameof(Y));
            }
        }

        public float Speed
        {
            get => this.Speedval;

            set
            {
                this.Speedval = value;
                //DoesPropertyChanged(nameof(Speed));
            }
        }
        public bool IsCollision
        {
            get => this.isCollision;

            set
            {
                this.isCollision = value;
                DoesPropertyChanged(nameof(IsCollision));
            }
        }
        public float Cordinates
        {
            get => this.cordinates;

            set
            {
                this.cordinates = value;
                DoesPropertyChanged(nameof(Cordinates));
            }
        }
    }
}

