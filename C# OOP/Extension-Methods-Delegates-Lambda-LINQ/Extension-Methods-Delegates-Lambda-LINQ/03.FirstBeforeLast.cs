namespace Extension_Methods_Delegates_Lambda_LINQ
{
    using System;
    using System.Linq;

    // Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
    // Use LINQ query operators.
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }

    public class StudentsNamesDemo
    {
        public static void StudentsWithFirstNameBeforeLast(Student[] students)
        {
            var resultStudents = from student in students
                                 where student.FirstName.CompareTo(student.LastName) < 0
                                 select student;

            foreach (var student in resultStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
