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
    public class CircleModel : ICircleModel
    {
        private float xVal;
        private float yVal;
        private float radiusVal;
        private readonly ICircleLogic circle;

        public event PropertyChangedEventHandler PropertyChanged;

        public void DoesPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public float Radius
        {
            get { return radiusVal*2; }
            set
            {
                radiusVal = value;
                //DoesPropertyChanged("Radius");
            }
        }
        public float X
        {
            get { return xVal; }
            set
            {
                xVal = value;
                DoesPropertyChanged("X");
            }
        }
        public float Y
        {
            get { return yVal; }
            set
            {
                yVal = value;
                DoesPropertyChanged("Y");
            }
        }

        public CircleModel(ICircleLogic circle) 
        {
            this.circle = circle;
            this.circle.PropertyChanged += OnPropertyChanged;
            X = circle.Pos.X;
            Y = circle.Pos.Y;
            Radius = circle.Radius;
        }
        public void Update()
        {
            X = circle.Pos.X;
            Y = circle.Pos.Y;
        }

        private void OnPropertyChanged( object sender, PropertyChangedEventArgs e)
        {
            ICircleLogic c = (ICircleLogic)sender;

            X = c.Pos.X;
            Y = c.Pos.Y;
        }
    }
}
