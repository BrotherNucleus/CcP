using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using TPWClassLib;

namespace TPWTests
{

    [TestClass]
    public class CircleTests
    {
        [TestMethod]

        public void CircleConstructorTest()
        {
            int testRadius = 1;
            Color testColor = Color.Tomato;

            Circle circle = new Circle(testRadius, testColor);

            Assert.AreEqual(testRadius, circle.radius);
            Assert.AreEqual(testColor, circle.color);
        }

        [TestMethod]

        public void CircleRadiusTest()
        {
            int testRadius = 1;
            int changedRadius = 3;
            Color testColor = Color.Tomato;

            Circle circle = new Circle(testRadius, testColor);

            Assert.AreEqual(testRadius, circle.radius);

            circle.radius = changedRadius;

            Assert.AreNotEqual(testRadius, circle.radius);
            Assert.AreEqual(changedRadius, circle.radius);
        }

        [TestMethod]

        public void CircleColorTest()
        {
            int testRadius = 1;
            Color testColor = Color.Tomato;
            Color changedColor = Color.SteelBlue;

            Circle circle = new Circle(testRadius, testColor);

            Assert.AreEqual(testColor, circle.color);

            circle.color = changedColor;

            Assert.AreNotEqual(testColor, circle.color);
            Assert.AreEqual(changedColor, circle.color);
        }
    }
}
