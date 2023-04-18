using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using System.Drawing;

namespace Model.Tests
{
    [TestClass]
    public class CircleModelTests
    {

        [TestMethod]
        public void CircleModelTest()
        {
            int testRadius = 1;
            int testX = 5;
            int testY = 10;
            int testSpeed = 2;
            Color testColor = Color.Tomato;
            Circle testCircle = new Circle(testRadius, testColor, testX, testY, testSpeed);

            CircleModel circleModel = new CircleModel(testCircle);

            Assert.AreEqual(testRadius, circleModel.Radius);
            Assert.AreEqual(testX, circleModel.X);
            Assert.AreEqual(testY, circleModel.Y);
        }
    }
}