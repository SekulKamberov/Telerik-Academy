/*
 * Problem 3: Write a method that from a given array of students finds all students whose first name is before
        its last name alphabetically.Use LINQ query operators.
 * Problem 4: Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
 * Problem 5: Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name
        and last name in descending order.Rewrite the same with LINQ.
 */

namespace _03.SortingStudentsNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        //problem 3
        public static void SortByFirstName(IList<Student> studentsGroup)
        {
            //var sorted = studentGroup.Where(st => st.FirstName.CompareTo(st.LastName) < 0);       Using Lambda expression
            var sorted =
                from st in studentsGroup
                where st.FirstName.CompareTo(st.LastName) < 0
                orderby st.FirstName
                select st;

            Console.WriteLine("Students sorted by first name before last name alpabetically:");

            Print(sorted);
        }

        //problem 4
        public static void SortByAge(IList<Student> studentsGroup)
        {

            //var sorted = studentGroup.Where(st => st.Age >= 18 && st.Age <= 24);     Using Lambda expression
            var sorted =
                from st in studentsGroup
                where st.Age >= 18 && st.Age <= 24
                orderby st.Age
                select st;

            Console.WriteLine("Students ordered by age between 18 and 24:");

            Print(sorted);
        }

        //problem 5
        public static void SortNamesByDescending(IList<Student> studentsGroup)
        {
            //Using Lambda expression
            //var descendingSort = studentsGroup.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);

            //Using LINQ Query
            var descendingSort =
                from st in studentsGroup
                orderby st.FirstName descending, st.LastName descending
                select st;

            Console.WriteLine("Descending order of students' names:");

            Print(descendingSort);
        }

        public static void Print(IEnumerable<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            Console.WriteLine();
        }

        public static void Main()
        {
            try
            {
                Student[] group10 = new Student[]
                {
                    new Student("Pavel","Ivanov", 22),
                    new Student("Miro","Kirov", 23),
                    new Student("Aleks","Zelev", 30),
                    new Student("Dwayne","Johnson", 21),
                };

                SortByFirstName(group10);

                SortByAge(group10);

                SortNamesByDescending(group10);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
