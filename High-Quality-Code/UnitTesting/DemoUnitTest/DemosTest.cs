namespace DemoUnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DemosTest
    {
        private static string name;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            name = "name";
        }

        [ClassCleanup]
        public static void CleanUp()
        {
        }

        [TestMethod]
        public void TestSetup()
        {
            Assert.IsTrue("name" == name);
        }

        [TestMethod]
        public void Test_Demo_Equal()
        {
            Assert.AreEqual(5, 5);
        }

        [TestMethod]
        [Ignore]
        public void TestMethod1()
        {
            Assert.AreEqual(5, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        [Timeout(5000)]
        public void Test_Demo()
        {
            var zero = 0;
            var result = 1 / zero;
        }
    }
}
