using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using Data;

namespace Logic
{
    public class CircleLogic: ICircleLogic
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void DoesPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private readonly Circle myCircle;
        public CircleLogic(Circle circle)
        {
            myCircle = circle;
            circle.PropertyChanged += CordsChange;
        }
        public void CordsChange (object sender, PropertyChangedEventArgs e)
        {
            DoesPropertyChanged("Cordinates");
        }
        public int Radius
        {
            get => myCircle.Radius;
            set
            {
                this.Radius = value;
                //DoesPropertyChanged(nameof(Radiusval));
            }
        }

        public Color color { get; set; }

        public int X
        {
            get => myCircle.X;
            set
            {
                
                myCircle.X = value;
                DoesPropertyChanged(nameof(X));
            }
        }

        public int Y
        {
            get => myCircle.Y;
            set
            {
                myCircle.Y = value;
                DoesPropertyChanged(nameof(Y));
            }
        }

        public int Speed 
        { get=> myCircle.Speed;

            set 
            {
                myCircle.Speed = value;
                //DoesPropertyChanged(nameof(Speed));
            } 
        }

    }
}
