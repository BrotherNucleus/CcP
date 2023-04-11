using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace TPWTests
{
    [TestClass]
    public class LogicApiTests
    {
        [TestMethod]

        public void SceneConstructorTest()
        {
            int testCircleNumber = 3;
            int testWidth = 16, testHeight = 16;
            int testRadius = 3;
            LogicAPI logicAPI = new LogicAPI(testWidth, testHeight, testCircleNumber, testRadius);

            Assert.AreEqual(testCircleNumber, logicAPI.Circles.Count);
            Assert.AreEqual(testRadius, logicAPI.Circles[0].Radius);
        }

        [TestMethod]

        public void SceneCreateCricleTest()
        {
            int testCircleNumber = 1;
            int testWidth = 16, testHeight = 16;
            int testRadius = 3;
            LogicAPI logicAPI = new LogicAPI(testWidth, testHeight, testCircleNumber, testRadius);

            Circle circle = logicAPI.createCircle(testRadius, testWidth, testHeight);

            Assert.IsTrue(circle != null);
            Assert.IsTrue(circle.X > testRadius);
            Assert.IsTrue(circle.X < testWidth - testRadius);
            Assert.IsTrue(circle.Y > testRadius);
            Assert.IsTrue(circle.Y < testHeight - testRadius);
            Assert.AreEqual(Color.AliceBlue, circle.color);
            Assert.AreEqual(testRadius, circle.Radius);
        }

        [TestMethod]

        public void SceneCreateCircleListTest()
        {
            int testCircleNumber = 1;
            int testWidth = 32, testHeight = 32;
            int testRadius = 3;
            LogicAPI logicAPI = new LogicAPI(testWidth, testHeight, testCircleNumber, testRadius);

            int newtestCircleNumber = 5;

            logicAPI.createCircleList(newtestCircleNumber, testRadius, testWidth, testHeight);

            Assert.AreEqual(newtestCircleNumber, logicAPI.Circles.Count);
        }
    }
}
