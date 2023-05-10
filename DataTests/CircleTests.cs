using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Data.Tests
{
    [TestClass()]
    public class CircleTests
    {

        [TestMethod()]
        public void CircleTest()
        {
            float testX = 10;
            float testY = 10;
            float radius = 3;
            float speed = 2.3f;
            Color color = Color.White;
            float mass = 10;

            Circle circle = new Circle(radius, color, testX, testY, speed, mass);
            Assert.AreEqual(radius, circle.Radius);
            Assert.AreEqual(testX, circle.X);
            Assert.AreEqual(testY, circle.Y);
            Assert.AreEqual(mass, circle.Mass);
            Assert.AreEqual(testX, circle.Pos.X);
            Assert.AreEqual(testY, circle.Pos.Y);
            Assert.AreEqual(speed, circle.Speed);
            Assert.AreEqual(color, circle.color);
        }
    }
}