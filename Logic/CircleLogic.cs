using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        public Circle myCircle;
        public CircleLogic(Circle circle)
        {
            myCircle = circle;
            circle.PropertyChanged += CordsChange;
        }
        public void CordsChange (object sender, PropertyChangedEventArgs e)
        {
            DoesPropertyChanged("Cordinates");
        }
        public float Radius
        {
            get => myCircle.Radius;
            set
            {
                this.Radius = value;
                DoesPropertyChanged(nameof(Radius));
            }
        }
        public bool IsCollision
        {
            get => myCircle.isCollision;
            set
            {
                myCircle.isCollision = value;
                DoesPropertyChanged(nameof(IsCollision));
            }
        }

        public Vector2 Pos
        {
            get => myCircle.Pos;
            set
            {
                myCircle.Pos = value;
                DoesPropertyChanged(nameof(Pos));
            }
        }

        public Vector2 Vel
        {
            get => myCircle.Vel;
            set
            {
                myCircle.Vel = value;
                DoesPropertyChanged(nameof(Vel));
            }
        }

        public Color color { get; set; }

        public float Xdir
        {
            get => myCircle.XDir;
            set
            {

                myCircle.XDir = value;
                DoesPropertyChanged(nameof(Xdir));
            }
        }

        public float Ydir
        {
            get => myCircle.YDir;
            set
            {

                myCircle.YDir = value;
                DoesPropertyChanged(nameof(Ydir));
            }
        }

        public float X
        {
            get => myCircle.X;
            set
            {
                
                myCircle.X = value;
                DoesPropertyChanged(nameof(X));
            }
        }

        public float Y
        {
            get => myCircle.Y;
            set
            {
                myCircle.Y = value;
                DoesPropertyChanged(nameof(Y));
            }
        }

        public float Speed 
        { get=> myCircle.Speed;

            set 
            {
                myCircle.Speed = value;
                //DoesPropertyChanged(nameof(Speed));
            } 
        }

        public float Cordinates
        {
            get => myCircle.Cordinates;

            set
            {
                myCircle.Cordinates = value;
                DoesPropertyChanged(nameof(Cordinates));
            }
        }

        public void MoveCircle()
        {
            
            while (!myCircle.isCollision)
            {
                if (Pos.X > 700 - Radius*2 - 4) 
                {
                    Vector2 nvel = new Vector2(Vel.X, Vel.Y);
                    nvel.X = -Math.Abs(Vel.X);
                    Vel = nvel;
                }
                else if (Pos.X < 4)
                {
                    Vector2 nvel = new Vector2(Vel.X, Vel.Y);
                    nvel.X = Math.Abs(Vel.X);
                    Vel = nvel;
                }
                if (Pos.Y > 700 - Radius*2 - 4) 
                {
                    Vector2 nvel = new Vector2(Vel.X, Vel.Y);
                    nvel.Y = -Math.Abs(Vel.Y);
                    Vel = nvel;
                }
                else if(Pos.Y < 4)
                {
                    Vector2 nvel = new Vector2(Vel.X, Vel.Y);
                    nvel.Y = Math.Abs(Vel.Y);
                    Vel = nvel;
                }
                Pos += Vel;
                Cordinates *= -1; 
                //DoesPropertyChanged("Cordinates");
                Thread.Sleep(10);
            }

        }

    }
}
