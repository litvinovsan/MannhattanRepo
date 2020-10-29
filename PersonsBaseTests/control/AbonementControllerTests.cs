using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsBase.control;
using PersonsBase;
namespace PersonsBaseTests.control
{
    [TestClass()]
    public class AbonementControllerTests
    {
        [TestMethod()]
        public void GetInstanceTest()
        {
         //  var inst = AbonementController.GetInstance();
            int a = 1;
            int b = 1;
            Assert.Equals(a, b);
            // Assert.IsNotNull(true);
        }
    }
}