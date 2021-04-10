namespace PeoplesRepo.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Test_CreatePerson()
        {
            // arrange
            var firstName = "Ivan";
            var lastName = "Bobev";
            var age = 12;
            
            // act
            var person = new Person(firstName, lastName, age);

            // asssert
            Assert.AreEqual(firstName, person.FirstName);
            Assert.AreEqual(lastName, person.LastName);
            Assert.AreEqual(age, person.Age);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CreatePersonWithShortFirstNameWillThrow()
        {
            // arrange
            var firstName = "Iv";
            var lastName = "Bobev";
            var age = 12;

            // act
            var person = new Person(firstName, lastName, age);

            // assert
        }
    }
}
