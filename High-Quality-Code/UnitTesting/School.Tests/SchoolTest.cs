namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_StudentName_CantBeNull()
        {
            string name = null;
            Student student = new Student(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_StudentName_CantBeEmpty()
        {
            string name = string.Empty;
            Student student = new Student(name);
        }

        [TestMethod]
        public void Test_StudentShouldHaveName()
        {
            string name = "Gogo";
            Student student = new Student(name);

            Assert.AreEqual(name, student.Name, "Student should have name.");
        }

        [TestMethod]
        public void Test_StudentShouldHaveNumber_Between_10000_And_99999()
        {
            // arrange
            var firststudentName = "Pepo";
            var secondStudentName = "Gogo";

            // act
            Student firstStudent = new Student(firststudentName);
            Student secondStudent = new Student(secondStudentName);

            // assert
            Assert.AreNotEqual(firstStudent.UniqueNumber, secondStudent.UniqueNumber, "Students should have unique numbers.");
        }

        [TestMethod]
        public void Test_CourseShould_NotAdd_SameStudent()
        {
            Student student = new Student("Gogo");
            Course course = new Course();
            course.Add(student);
            bool isAdded = course.Add(student);

            Assert.IsTrue(isAdded == false, "Course should not add same student!");
        }

        [TestMethod]
        public void Test_CourseShouldNotHave_MoreThan30Students()
        {
            Course course = new Course();
            for (int i = 0; i < 31; i++)
            {
                Student student = new Student("Gogo" + i);
                course.Add(student);
            }

            int studentsCount = course.Students.Count;

            Assert.IsTrue(30 == studentsCount, "Course should not add more than 30 students.");
        }
    }
}
