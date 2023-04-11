using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicAPI 
    { 
        public LogicAPI(int width, int height, int circleNumber, int radius) 
        {
            createCircleList(circleNumber, radius, width, height);
        }

        public List<Circle> Circles { get; } = new List<Circle>();
        public Circle createCircle(int radius, int width, int height)
        {
            Random random = new Random();
            bool valid = true;
            int x = radius, y = radius;
            do
            {
                valid = true;
                x = random.Next(radius, width - radius);
                y = random.Next(radius, height - radius);
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
            return new Circle(radius, Color.AliceBlue, x, y);
        }

        public void createCircleList(int circleNumber, int radius, int width, int height)
        {
            Circles.Clear();
            for (int i = 0; i < circleNumber; i++)
            {
                Circle circle = createCircle(radius, width, height);
                this.Circles.Add(circle);
            }
        }

    }
}
