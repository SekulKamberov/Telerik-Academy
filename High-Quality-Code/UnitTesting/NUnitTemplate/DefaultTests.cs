namespace NUnitTemplate
{
    // Install NUnit and NUnit Test Adapter
    using System;
    using CalculatorLibrary;
    using NUnit.Framework;

    public class DefaultTests
    {
        [SetUp]
        [Ignore("Nothing to set up")]
        public void InitBeforeEachTest()
        {
            // TODO: to be implemented, remove ignore attribute
        }

        [TearDown]
        [Ignore("Nothing to tear down")]
        public void DisposeAfterEachTest()
        {
            // TODO: to be implemented, remove ignore attribute
        }

        [OneTimeSetUp]
        [Ignore("Nothing to set up")]
        public void Init()
        {
            // TODO: to be implemented
        }

        [OneTimeTearDown]
        [Ignore("Nothing to tear down")]
        public void Dispose()
        {
            // TODO: to be implemented
        }

        [Test]
        public void Calculator_Sum_ShouldSumCorrect()
        {
            // ARRANGE
            int a = 1;
            int b = 5;
            int expectedResult = 6;

            // ACT
            var result = Calculator.Sum(a, b);

            // ASSERT
            Assert.AreEqual(expectedResult, result, "Calculator should sum correct!");
        }

        [TestCase(1, 3, 4)]
        [TestCase(-1, -3, -4)]
        [TestCase(1, -3, -2)]
        [TestCase(0, 0, 0)]
        public void Calculator_Sum_ShouldSumCorrectly(int firstNumber, int secondNumber, int expectedResult)
        {
            // ARRANGE

            // ACT
            var actualResult = Calculator.Sum(firstNumber, secondNumber);

            // ASSERT
            Assert.AreEqual(expectedResult, actualResult, "Calculator should sum correct!");
        }

        [Test]
        public void Bank_AddNullAccount_ShouldThrowException()
        {
            // ARRANGE
            string input = "not a number";

            // ACT

            // ASSERT
            Assert.Throws<FormatException>(() => int.Parse(input));
        }
    }
}
