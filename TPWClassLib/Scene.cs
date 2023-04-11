using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWClassLib
{
    public class Scene
    {
        public Scene(int width, int height, int circleNumber, int radius) 
        {
            this.width = width;
            this.height = height;
            createCircleList(circleNumber, radius);
        }

        public int width { get; }

        public int height { get; }

        public int Enabled { get; set; }

        public List<Circle> Circles { get; } = new List<Circle>();

        public Circle createCircle(int radius)
        {
            Random random = new Random();
            bool valid = true;
            int x = radius, y = radius;
            do
            {
                valid = true;
                x = random.Next(radius, this.width - radius);
                y = random.Next(radius, this.height - radius);
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

        public void createCircleList(int circleNumber, int radius)
        {
            Circles.Clear();
            for (int i = 0; i < circleNumber; i++)
            {
                Circle circle = createCircle(radius);
                this.Circles.Add(circle);
            }
        }
    }
}
