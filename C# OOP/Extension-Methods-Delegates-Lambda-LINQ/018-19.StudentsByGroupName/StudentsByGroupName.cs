namespace StudentProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroupName
    {
        private static List<Student> students;

        public static void Main()
        {
            students = new List<Student>()
            {
                new Student("Grigor", "Petrov", "316106", "02876455", "grigor@abv.bg", new List<int> { 3, 4 }, 2, new Group(15, "Physics")),
                new Student("Petar", "Marinov", "316206", "02899123", "petar@gmail.com", new List<int> { 6, 5, 6, 6 }, 2, new Group(3, "Mathematics")),
                new Student("Dobri", "Gospodinov", "324806", "73654789", "dobri@abv.bg", new List<int> { 6, 5, 6 }, 4, new Group(9, "Medicine")),
                new Student("Anna", "Dimova", "395103", "52999999", "anna@gmail.com", new List<int> { 6, 6 }, 2, new Group(11, "Mathematics")),
                new Student("Penka", "Stoicheva", "318206", "0899111111", "penka@abv.bg", new List<int> { 2, 2, 3, 3 }, 5, new Group(22, "Mathematics")),
                new Student("Anna", "Dimova", "395103", "52999999", "anna@gmail.com", new List<int> { 2, 2, 3, 3, 4 }, 1, new Group(11, "Chemistry"))
            };

            // 18. Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
            var selectStudents =
                from student in students
                group student by student.Group.DepartmentName into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var group in selectStudents)
            {
                Console.WriteLine("=====" + group.Key + "=====");
                foreach (var student in group)
                {
                    Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
                }
            }

            Console.WriteLine();
            
            // 19. Rewrite the previous using extension methods.
            Console.WriteLine("Order using extension methods: ");

            var groupedStudents = students.GroupBy(student => student.Group.DepartmentName);

            foreach (var group in groupedStudents)
            {
                Console.WriteLine("=====" + group.Key + "=====");
                foreach (var student in group)
                {
                    Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
                }
            }
        }
    }
}
