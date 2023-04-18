using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Logic;
using System.Data;

namespace Model
{
    internal class CircleModel : ICircleModel
    {
        private int xVal;
        private int yVal;
        private int radiusVal;
        private readonly ICircle circle;

        public event PropertyChangedEventHandler PropertyChanged;

        public void DoesPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Radius
        {
            get { return radiusVal; }
            set
            {
                radiusVal = value;
                //DoesPropertyChanged("Radius");
            }
        }
        public int X
        {
            get { return xVal; }
            set
            {
                xVal = value;
                DoesPropertyChanged("X");
            }
        }
        public int Y
        {
            get { return yVal; }
            set
            {
                yVal = value;
                DoesPropertyChanged("Y");
            }
        }

        public CircleModel(ICircle circle) 
        {
            this.circle = circle;
            this.circle.PropertyChanged += OnPropertyChanged;
            X = circle.X;
            Y = circle.Y;
            Radius = circle.Radius;
        }
        public void Update()
        {
            X = circle.X;
            Y = circle.Y;
        }

        private void OnPropertyChanged( object sender, PropertyChangedEventArgs e)
        {
            ICircle c = (ICircle)sender;

            X = c.X;
            Y = c.Y;
        }
    }
}
