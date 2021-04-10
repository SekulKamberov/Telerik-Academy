namespace CalculatorXmlTemplate.Tests
{
    using System;
    using System.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CalculatorLibrary;

    // Set XML's file property / Copy to Output / Copy always
    [TestClass]
    public class DefaultTests
    {
        private static string name;
        private static int age;
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            name = "name";
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // TODO delete some folder maybe
        }

        [TestInitialize]
        public void TestInitialize()
        {
            age = 30;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            age = 20;
        }

        [TestMethod]
        [DeploymentItem(".\\data.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            ".\\data.xml",
            "row",
            DataAccessMethod.Sequential)]
        public void Calculator_SumNumbers_ShouldSumCorrectly()
        {
            // ARRANGE
            int a = int.Parse((string)this.TestContext.DataRow["a"]);
            int b = int.Parse((string)this.TestContext.DataRow["b"]);
            int expectedResult = int.Parse((string)this.TestContext.DataRow["res"]);

            // ACT
            var result = Calculator.Sum(a, b);

            // ASSERT
            Assert.AreEqual(expectedResult, result, "Calculator should sum correct!");
        }

        [TestMethod]
        [Ignore]
        public void Test_Method_Not_Executed()
        {
            // ARRANGE

            // ACT

            // ASSERT
            Assert.AreEqual(true, false);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        [Timeout(1000)]
        public void MethodName_ParseInvalidInput_ShouldThrowException()
        {
            // ARRANGE
            var input = "not a number";

            // ACT
            int age = int.Parse(input);
        }
    }
}
