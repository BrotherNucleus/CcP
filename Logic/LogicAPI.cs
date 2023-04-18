using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Logic
{
    public abstract class LogicAPI 
    { 
        /*public LogicAPI(int width, int height, int circleNumber, int radius) 
        {
            createCircleList(circleNumber, radius, width, height);
        }*/

        private List<ICircle> Circles = new List<ICircle>();
        private List<Thread> threadList = new List<Thread>();
        public abstract void createCircleList(int circleNumber, int radius, int width, int height);
        public abstract void Start();
        public abstract List<ICircle> GetCircles();
        public class LogicLayer : LogicAPI
        {
            private DataAPI dataAPI;
            public override List <ICircle> GetCircles()
            {
                return this.Circles;
            }

            public LogicLayer(DataAPI dataAPI)
            {
                this.dataAPI = dataAPI;
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
                    speed = random.Next(1,5);
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
                return new Circle(radius, Color.AliceBlue, x, y, speed);
            }

            public override void createCircleList(int circleNumber, int radius, int width, int height)
            {
                //Circles.Clear();
                for (int i = 0; i < circleNumber; i++)
                {
                    Circle circle = createCircle(radius, width, height);
                    this.Circles.Add(circle);
                }

                foreach (Circle circle in Circles)
                {
                    this.threadList.Add(new Thread(new ThreadStart(circle.MoveBall)));
                }
            }
            public override void Start()
            {
                foreach(Thread thread in threadList)
                {
                    thread.Start();
                }
            }
        }
        public static LogicAPI CreateAPI(DataAPI data = default) 
        {
            return new LogicLayer(data ?? DataAPI.CreateAPI());
        }

    }
}
