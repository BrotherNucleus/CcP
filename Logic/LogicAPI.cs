using Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Logic
{
    public abstract class LogicAPI 
    { 
        /*public LogicAPI(float width, float height, float circleNumber, float radius) 
        {
            createCircleList(circleNumber, radius, width, height);
        }*/

        private List<ICircleLogic> circlesLogic = new List<ICircleLogic>();

        private List<Thread> threadList = new List<Thread>();
        public abstract void createCircleList(int circleNumber, int radius, int width, int height);
        public abstract void Start();
        public abstract List<ICircleLogic> GetCircles();
        public class LogicLayer : LogicAPI
        {
            private DataAPI dataAPI;

            private SemaphoreSlim semaphore = new SemaphoreSlim(1);

            private ConcurrentDictionary<ICircleLogic, ICircleLogic> colliding = new ConcurrentDictionary<ICircleLogic, ICircleLogic>();
            public override List <ICircleLogic> GetCircles()
            {
                return this.circlesLogic;
            }

            public LogicLayer(DataAPI dataAPI)
            {
                this.dataAPI = dataAPI;
            }

            public void addThreadsToCircles()
            {
                foreach (CircleLogic circle in circlesLogic)
                {
                    this.threadList.Add(new Thread(new ThreadStart(circle.MoveCircle)));
                }
            }
            

            public override void createCircleList(int circleNumber, int radius, int width, int height)
            {
                circlesLogic = new List<ICircleLogic>();
                dataAPI.createCircleList(circleNumber, radius, width, height);

                foreach (Circle circle in dataAPI.GetCircles())
                {
                    circlesLogic.Add(new CircleLogic(circle));
                    circle.PropertyChanged += ChangeCords;
                }
            }
            public void ChangeCords(object sender, PropertyChangedEventArgs e)
            {
                Circle circle = (Circle)sender;
                if (e.PropertyName == "Cordinates")
                {
                    Collision(circle);
                    circle.IsCollision = false;
                }
            }

            public void Collision(Circle origin)
            {
                //CircleLogic origin = (CircleLogic)sender;
                
                Circle potentialCollider = DetectCollision(origin);
                if (potentialCollider != null)
                {
                    semaphore.Wait();
                    origin.XDir *= -1;
                    origin.YDir *= -1;
                    potentialCollider.YDir *= -1;
                    potentialCollider.XDir *= -1;
                    semaphore.Release();
                    
                }
                
            }
            public void ChangeSpeed(CircleLogic circle)
            {

            }
            public override void Start()
            {
                addThreadsToCircles();
                foreach (Thread thread in threadList)
                {
                    thread.Start();
                }
            }
            public Circle DetectCollision(Circle circle)
            {
                foreach (CircleLogic colidedCircle in this.circlesLogic)
                {
                    if (colidedCircle.myCircle == circle)
                    {
                        continue;
                    }
                    float dist = (float)Math.Sqrt((circle.X - colidedCircle.X ) * (circle.X  - colidedCircle.X ) 
                        + (circle.Y - colidedCircle.Y ) * (circle.Y - colidedCircle.Y));
                    if (dist <= circle.Radius + colidedCircle.Radius - 1)
                    {
                        return colidedCircle.myCircle;
                    }
                }
                return null;

            }
        }
        public static LogicAPI CreateAPI(DataAPI data = default) 
        {
            return new LogicLayer(data ?? DataAPI.CreateAPI());
        }

    }
}
