using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Logic;

namespace TPWTests
{

    [TestClass]
    public class CircleTests
    {
        [TestMethod]

        public void CircleConstructorTest()
        {
            int testRadius = 1;
            int testX = 0;
            int testY = 0;
            Color testColor = Color.Tomato;

            Circle circle = new Circle(testRadius, testColor, testX, testY);

            Assert.AreEqual(testRadius, circle.Radius);
            Assert.AreEqual(testColor, circle.color);
            Assert.AreEqual(testX, circle.X);
            Assert.AreEqual(testY, circle.Y);
        }

        [TestMethod]

        public void CircleRadiusTest()
        {
            int testRadius = 1;
            int changedRadius = 3;
            int testX = 0;
            int testY = 0;
            Color testColor = Color.Tomato;

            Circle circle = new Circle(testRadius, testColor, testX, testY);

            Assert.AreEqual(testRadius, circle.Radius);

            circle.Radius = changedRadius;

            Assert.AreEqual(changedRadius, circle.Radius);
        }

        [TestMethod]

        public void CircleColorTest()
        {
            int testRadius = 1;
            int testX = 0;
            int testY = 0;
            Color testColor = Color.Tomato;
            Color changedColor = Color.SteelBlue;

            Circle circle = new Circle(testRadius, testColor, testX, testY);

            Assert.AreEqual(testColor, circle.color);

            circle.color = changedColor;

            Assert.AreEqual(changedColor, circle.color);
        }

        [TestMethod]

        public void CircleXandYTest()
        {
            int testRadius = 1;
            int testX = 0;
            int testY = 0;
            Color testColor = Color.Tomato;
            int changedX = 12;
            int changedY = 32;

            Circle circle = new Circle(testRadius, testColor, testX, testY);

            Assert.AreEqual(testX, circle.X);
            Assert.AreEqual(testY, circle.Y);

            circle.X = changedX;
            circle.Y = changedY;

            Assert.AreEqual(changedX, circle.X);
            Assert.AreEqual(changedY, circle.Y);
        }
    }
}
