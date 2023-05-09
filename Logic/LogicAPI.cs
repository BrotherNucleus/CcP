using Data;
using System;
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
        /*public LogicAPI(int width, int height, int circleNumber, int radius) 
        {
            createCircleList(circleNumber, radius, width, height);
        }*/

        private List<ICircleLogic> circlesLogic = new List<ICircleLogic>();
        public abstract void createCircleList(int circleNumber, int radius, int width, int height);
        public abstract void Start();
        public abstract List<ICircleLogic> GetCircles();
        public class LogicLayer : LogicAPI
        {
            private DataAPI dataAPI;
            public override List <ICircleLogic> GetCircles()
            {
                return this.circlesLogic;
            }

            public LogicLayer(DataAPI dataAPI)
            {
                this.dataAPI = dataAPI;
            }

            

            public override void createCircleList(int circleNumber, int radius, int width, int height)
            {
                circlesLogic = new List<ICircleLogic>();
                dataAPI.createCircleList(circleNumber, radius, width, height);

                foreach (Circle circle in dataAPI.GetCircles())
                {
                    circlesLogic.Add(new CircleLogic(circle));
                }
            }
            public void ChangeCords(object sender, PropertyChangedEventArgs e)
            {
                CircleLogic circle = (CircleLogic)sender;
                if (e.PropertyName== "Cordinates")
                {

                }
            }
            public void ChangeSpeed(CircleLogic circle)
            {

            }
            public override void Start()
            {
                dataAPI.Start();
            }
            public CircleLogic DetectCollision(CircleLogic circle)
            {
                foreach (CircleLogic colidedCircle in this.circlesLogic)
                {
                    if (colidedCircle == circle)
                    {
                        continue;
                    }
                    float dist = (float)Math.Sqrt((circle.X - colidedCircle.X) * (circle.X - colidedCircle.X) + (circle.Y - colidedCircle.Y) * (circle.Y - colidedCircle.Y));
                    if (dist <= circle.Radius + colidedCircle.Radius - 1)
                    {
                        return colidedCircle;
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
