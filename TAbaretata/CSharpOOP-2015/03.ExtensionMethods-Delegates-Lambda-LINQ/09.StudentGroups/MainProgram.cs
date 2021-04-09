/*
 * Problem 9: Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
    Create a List<Student> with sample students. Select only the students that are from group number 2.
    Use LINQ query. Order the students by FirstName.
 * Problem 10: Implement the previous using the same query expressed with extension methods.
 * Problem 11: Extract all students that have email in abv.bg.Use string methods and LINQ.
 * Problem 12: Extract all students with phones in Sofia.Use LINQ.
 * Problem 13: Select all students that have at least one mark Excellent (6) into a new anonymous class 
    that has properties – FullName and Marks.Use LINQ.
 * Problem 14: Write down a similar program that extracts the students with exactly two marks "2".Use extension methods.
 * Problem 15: Extract all Marks of the students that enrolled in 2006. 
    (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
 * Problem 16*: Create a class Group with properties GroupNumber and DepartmentName.
    Introduce a property Group in the Student class.Extract all students from "Mathematics" department.Use the Join operator.
 */

namespace _09.StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MainProgram
    {
        //problem 16*
        public static void SortByMathematicsDepartment(IEnumerable<Student> studentsGroup, IEnumerable<Group> groups)
        {
            var sorted =                              
                from st in studentsGroup
                join gr in groups on st.GroupNumber equals gr.GroupNumber
                where gr.GroupNumber == 10
                select st;

            Console.WriteLine("Students from Mathematics Department");

            PrintStudents(sorted);
        }

        //problem 15
        public static void SortBySigningIn2006(IEnumerable<Student> studentsGroup)
        {
            var sorted =
                from st in studentsGroup
                where st.FN.EndsWith("06")
                select st;

            Console.WriteLine("Marks of students enrolled in 2006");

            foreach (Student student in sorted)
            {
                Console.WriteLine(student.ToString() +
                    "[" + string.Join(", ", student.Marks) + "]");
            }
            Console.WriteLine();
        }

        //problem 14 method
        public static void SortByAtleastTwoMarks(IEnumerable<Student> studentsGroup)
        {
            var sorted = ExtensionMethods.ExtensionSortByAtleastTwoMarks(studentsGroup);

            Console.WriteLine("Students with atleast two marks");

            foreach (var student in sorted)
            {
                Console.WriteLine(student.ToString() +
                    "[" + string.Join(", ", student.Marks) + "]");
            }
            Console.WriteLine();
        }

        //problem 13
        public static void SortByExcelentMark(IEnumerable<Student> studentsGroup)
        {
            var sorted =
                from st in studentsGroup
                where st.Marks.Contains(6)
                select new { FullName = st.ToString(), Marks = st.Marks };

            Console.WriteLine("Students sorted by atleast one 6 mark");

            foreach (var student in sorted)
            {
                Console.WriteLine(student.FullName + "[" + string.Join(", ", student.Marks) + "]");
            }
            Console.WriteLine();
        }

        //problem 12
        public static void SortByPhoneInSofia(IEnumerable<Student> studentsGroup)
        {
            var sorted =
                from st in studentsGroup
                where st.PhoneNumber.StartsWith("02")
                select st;

            Console.WriteLine("Students with phone numbers in Sofia");

            PrintStudents(sorted);
        }

        //problem 11
        public static void SortByEmail(IEnumerable<Student> studentsGroup)
        {
            var sorted =
                from st in studentsGroup
                where st.Email.Contains("abv.bg")
                select st;

            Console.WriteLine("Students with email in ABV.BG");

            PrintStudents(sorted);
        }

        //problem 9 method
        public static void SortByGroup(IEnumerable<Student> studentsGroup)
        {
            //var sorted =                              
            //    from st in studentGroup
            //    where st.GroupNumber == 2
            //    orderby st.FirstName
            //    select st;

            var sorted = ExtensionMethods.ExtensionSortByGroup(studentsGroup);        //problem 10 implementation

            Console.WriteLine("Students from group 2 ordered by first name");

            PrintStudents(sorted);
        }

        public static void PrintStudents(IEnumerable<Student> studentsGroup)
        {
            foreach (Student student in studentsGroup)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine();
        }

        public static void Main()
        {
            List<Student> groupOfStudents = new List<Student>()
            {
                new Student("Ivan", "Penchev", "351006", "023948", "ivan.p@gmail.com", new List<int> { 3, 5 }, 2),
                new Student("Petar", "Minchev", "351005", "024147", "pesho@gmail.com", new List<int> { 2, 3, 3 }, 10),
                new Student("Ivan", "Kirov", "351005", "194950", "kirov@abv.bg", new List<int> { 4, 6 }, 2),
                new Student("Kiro", "Ivanov", "351101", "010383", "ivanov@abv.bg", new List<int> { 6, 6, 6 }, 10),
                new Student("Niko", "Zelev", "351006", "098956", "niko@gmail.com", new List<int> { 2 }, 2)
            };

            List<Group> groups = new List<Group>()
            {
                new Group(2, "Computer Science"),
                new Group(10, "Mathematics")
            };


            SortByGroup(groupOfStudents);               //problem 9 & 10

            SortByEmail(groupOfStudents);               //problem 11

            SortByPhoneInSofia(groupOfStudents);        //problem 12

            SortByExcelentMark(groupOfStudents);        //problem 13

            SortByAtleastTwoMarks(groupOfStudents);     //problem 14

            SortBySigningIn2006(groupOfStudents);       //problem 15

            SortByMathematicsDepartment(groupOfStudents, groups);   //problem 16*
        }
    }
}
