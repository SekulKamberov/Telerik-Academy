namespace Extension_Methods_Delegates_Lambda_LINQ
{
    using System;
    using System.Linq;

    public class FindStrudentsByAge
    {
        // 04. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        public static void FindStudentsByAgeRange(Student[] students, int startAge, int endAge)
        {
            var revisedList =
                from student in students
                where (startAge <= student.Age && student.Age <= endAge)
                select student;

            foreach (var student in revisedList)
            {
                Console.WriteLine(student.FirstName + " " + student.Age);
            }
        }
    }
}
