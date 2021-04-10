namespace CalculatorTemplateTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DefaultTests
    {
        private static string name;
        private static int age;

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
        public void InitMethod_SetInitAge_ShouldSetAgeCorrectly()
        {
            // ARRANGE
            var randomAge = 30;

            // ACT
            var initAge = age;

            // ASSERT
            Assert.AreEqual(randomAge, initAge);
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
