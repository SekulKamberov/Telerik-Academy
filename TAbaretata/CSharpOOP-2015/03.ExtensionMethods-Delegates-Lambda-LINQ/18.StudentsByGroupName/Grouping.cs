/*
 * Problem 18: Create a program that extracts all students grouped by GroupName and then prints them to the console.Use LINQ.
 */

namespace _18.StudentsByGroupName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Grouping
    {
        public static void Main()
        {
            var students = new List<Student>
            {
                new Student("Ivan","Math"),
                new Student("Petar", "Comupter Science"),
                new Student("Firo", "Math"),
                new Student("Miro", "Biology"),
                new Student("Kiro", "Sports")
            };

            //var grouped = students.OrderBy(x => x.Group);     //problem 18 expression

            var grouped = ExtensionMethodGrouping.ExtensionGrouping(students);      //problem 19 impelentation

            foreach (var st in grouped)
            {
                Console.WriteLine(st.ToString());
            }
        }
    }
}
