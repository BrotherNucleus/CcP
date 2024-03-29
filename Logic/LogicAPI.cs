﻿using Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
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

        public ConcurrentDictionary<ICircle, ICircle> collided = new ConcurrentDictionary<ICircle, ICircle>();
        public class LogicLayer : LogicAPI
        {
            private DataAPI dataAPI;

            private SemaphoreSlim semaphore = new SemaphoreSlim(1);
            Logger logger;
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
                    Vector2 newOriginVel = newVel(origin, potentialCollider);
                    Vector2 newColliderVel = newVel(potentialCollider, origin);
                    origin.Vel = newOriginVel;
                    potentialCollider.Vel = newColliderVel;
                    collided.Remove(origin, out _);
                    collided.Remove(potentialCollider, out _);
                    collided.TryAdd(origin, potentialCollider);
                    collided.TryAdd(potentialCollider, origin);
                    semaphore.Release();
                }
                
            }
            
            private Vector2 newVel(Circle c1, Circle c2)
            {
                var c1Vel = c1.Vel;
                var c2Vel = c2.Vel;
                var posDiff = c1.Pos - c2.Pos;
                return c1.Vel - 2.0f * c2.Mass / (c1.Mass + c2.Mass)
                       * (Vector2.Dot(c1Vel - c2Vel, posDiff) * posDiff) /
                       (float)Math.Pow(posDiff.Length(), 2);
            }
            public override void Start()
            {
                addThreadsToCircles();
                foreach (Thread thread in threadList)
                {
                    thread.Start();
                }
                logger = new Logger(GetCircles());
            }
            public Circle DetectCollision(Circle circle)
            {
                foreach (CircleLogic colidedCircle in this.circlesLogic)
                {
                    if(collided.TryGetValue(circle, out var circleOne) && collided.TryGetValue(colidedCircle.myCircle, out var circleTwo) && circle ==  circleOne && colidedCircle.myCircle == circleTwo)
                    {
                        continue;
                    }
                    if (colidedCircle.myCircle == circle)
                    {
                        continue;
                    }
                    float dist = (float)Math.Sqrt((circle.Pos.X - colidedCircle.myCircle.Pos.X ) * (circle.Pos.X  - colidedCircle.myCircle.Pos.X ) 
                        + (circle.Pos.Y - colidedCircle.myCircle.Pos.Y ) * (circle.Pos.Y - colidedCircle.myCircle.Pos.Y));
                    if (dist <= circle.Radius + colidedCircle.myCircle.Radius + 1 && dist > circle.Radius + colidedCircle.myCircle.Radius - 5)
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
