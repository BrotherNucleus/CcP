using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWClassLib;

namespace TPWTests
{
    [TestClass]
    public class SceneTests
    {
        [TestMethod]

        public void SceneConstructorTest()
        {
            int testCircleNumber = 3;
            int testWidth = 16, testHeight = 16;
            int testRadius = 3;
            Scene scene = new Scene(testWidth, testHeight, testCircleNumber, testRadius);

            Assert.AreEqual(testCircleNumber, scene.Circles.Count);
            Assert.AreEqual(testWidth, scene.width);
            Assert.AreEqual(testHeight, scene.height);
            Assert.AreEqual(testRadius, scene.Circles[0].Radius);
        }

        [TestMethod]

        public void SceneCreateCricleTest()
        {
            int testCircleNumber = 1;
            int testWidth = 16, testHeight = 16;
            int testRadius = 3;
            Scene scene = new Scene(testWidth, testHeight, testCircleNumber, testRadius);

            Circle circle = scene.createCircle(testRadius);

            Assert.IsTrue(circle != null);
            Assert.IsTrue(circle.X > testRadius);
            Assert.IsTrue(circle.X < scene.width - testRadius);
            Assert.IsTrue(circle.Y > testRadius);
            Assert.IsTrue(circle.Y < scene.height - testRadius);
            Assert.AreEqual(Color.AliceBlue, circle.color);
            Assert.AreEqual(testRadius, circle.Radius);
        }

        [TestMethod]

        public void SceneCreateCircleListTest()
        {
            int testCircleNumber = 1;
            int testWidth = 32, testHeight = 32;
            int testRadius = 3;
            Scene scene = new Scene(testWidth, testHeight, testCircleNumber, testRadius);

            int newtestCircleNumber = 5;

            scene.createCircleList(newtestCircleNumber, testRadius);

            Assert.AreEqual(newtestCircleNumber, scene.Circles.Count);
        }
    }
}
