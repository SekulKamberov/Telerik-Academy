namespace Extension_Methods_Delegates_Lambda_LINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
    {
        // 05. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
        //  by first name and last name in descending order. Rewrite the same with LINQ.
        public static void PrintSortedStudentsUsingLambda(Student[] arr)
        {
            Console.WriteLine("Sorted by FirstName and Last Name Lambda : ");
            var sortedStudentsFirstNameLastNameDescendingLambda =
                arr.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            foreach (var student in sortedStudentsFirstNameLastNameDescendingLambda)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }

        public static void PrintSortedStudentsUsingLinq(Student[] arr)
        {
            Console.WriteLine("Sorted by FirstName and Last Name Linq : ");
            var sortedStudentsFirstNameLastNameDescendingLINQ =
                            from student in arr
                            orderby student.FirstName descending, student.LastName descending
                            select student;

            foreach (var student in sortedStudentsFirstNameLastNameDescendingLINQ)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
