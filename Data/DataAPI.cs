using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Data
{
    public abstract class DataAPI
    {
        public static DataAPI CreateAPI()
        {
            return new DataLayer();
        }
        public abstract void createCircleList(int circleNumber, int radius, int width, int height);
        private List<ICircle> Circles = new List<ICircle>();
        public abstract List<ICircle> GetCircles();

        public class DataLayer: DataAPI
        {
            public DataLayer() { }


            public override void createCircleList(int circleNumber, int radius, int width, int height)
            {
                //Circles.Clear();
                for (int i = 0; i < circleNumber; i++)
                {
                    Circle circle = createCircle(radius, width, height);
                    this.Circles.Add(circle);
                }
            }
            public Circle createCircle(int radius, int width, int height)
            {
                Random random = new Random();
                bool valid = true;
                int x = radius, y = radius;
                int speed;
                do
                {
                    valid = true;
                    x = random.Next(radius, width - radius);
                    y = random.Next(radius, height - radius);
                    speed = random.Next(30, 40);
                    foreach (Circle b in this.Circles)
                    {
                        double distance = Math.Sqrt(((b.X - x) * (b.X - x)) + ((b.Y - y) * (b.Y - y)));
                        if (distance <= b.Radius + radius)
                        {
                            valid = false;
                            break;
                        };
                    }
                    if (!valid)
                    {
                        continue;
                    };
                    valid = true;

                } while (!valid);
                return new Circle(radius, Color.AliceBlue, x, y, speed, 10);
            }
            public override List<ICircle> GetCircles()
            {
                return this.Circles;
            }
        }
        
    }
}
