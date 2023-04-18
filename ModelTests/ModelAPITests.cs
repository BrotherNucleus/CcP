using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    [TestClass()]
    public class ModelAPITests
    {
        [TestMethod()]
        public void CreateAPITest()
        {
            ModelAPI testModel = ModelAPI.CreateAPI();
            Assert.IsNotNull(testModel);
        }

        [TestMethod()]
        public void VisualiseTest()
        {
            ModelAPI testModel = ModelAPI.CreateAPI();
            int testCircleNum = 5;
            int testRadius = 20;
            int testWidth = 700;
            int testHeight = 700;

            testModel.Visualise(testRadius, testCircleNum, testWidth, testHeight);

            Assert.AreEqual(testCircleNum, testModel.CircleModels.Count());
        }
    }
}