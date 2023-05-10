using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Data;
using Model;

namespace Logic.Tests
{
    [TestClass]
    public class LogicAPITests
    {
        [TestMethod]
        public void createCircleListTest()
        {
            LogicAPI testLogic = LogicAPI.CreateAPI();
            int testCircleNum = 5;
            int testRadius = 20;
            int testWidth = 700;
            int testHeight = 700;

            testLogic.createCircleList(testCircleNum, testRadius, testWidth, testHeight);

            Assert.IsNotNull(testLogic.GetCircles());
            Assert.AreEqual(testCircleNum, testLogic.GetCircles().Count());
        }

        [TestMethod]
        public void CreateAPITest()
        {
            LogicAPI logicTest = LogicAPI.CreateAPI();
            Assert.IsNotNull(logicTest);

        }
    }
}