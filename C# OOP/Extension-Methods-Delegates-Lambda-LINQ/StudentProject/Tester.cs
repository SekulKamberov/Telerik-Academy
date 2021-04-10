namespace StudentProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Tester
    {
        private static List<Student> students;

        public static void Print(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }

        // 09.Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
        public static void FindStudentsFromGroup(int groupNumber = 0)
        {
            var studentsFromSecondGroupWithLinq =
                from student in students
                where student.GroupNumber == groupNumber
                orderby student.FirstName
                select student;

            Console.WriteLine("---09---");
            Print(studentsFromSecondGroupWithLinq);
        }

        // 10.Implement the previous using the same query expressed with extension methods.
        public static void FindStudentsFromSecondGroupWithLambda(int groupNumber = 0)
        {
            var studentsFromSecondGroupWithLambda = students.Where(x => x.GroupNumber == groupNumber).OrderBy(x => x.FirstName);

            Console.WriteLine("---10---");
            Print(studentsFromSecondGroupWithLambda);
        }

        // 11.Extract all students that have email in abv.bg. Use string methods and LINQ.
        public static void FindStudentsWithEmailIn(string emailIn = "abv.bg")
        {
            var studentWithEmailInAbv =
                from student in students
                where student.Email.EndsWith(emailIn)
                select student;

            // solution with lambda expression
            // var studentsWithEmailInAbvLambda = students.Where(st => st.Email.EndsWith(emailIn));
            // Print(studentsWithEmailInAbvLambda);
            Console.WriteLine("---11---");
            Print(studentWithEmailInAbv);
        }

        // 12.Extract all students with phones in Sofia. Use LINQ.
        public static void FindStudentsWithSofiaPhoneNumber(string areaCode = "02")
        {
            var studentsWithSofiaPhoneNumbers =
                from student in students
                where student.Tel.StartsWith(areaCode)
                select student;

            // studentsWithSofiaPhoneNumbersLambda = students.Where(st => st.Tel.StartsWith("02"));
            // Print(studentsWithSofiaPhoneNumbersLambda);
            Console.WriteLine("---12---");
            Print(studentsWithSofiaPhoneNumbers);
        }

        // 13.Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
        public static void FindStudentsWithAtLeastOneExcellentMark()
        {
            var studentsWithExcellentMark =
                from student in students
                where student.ContainMark(6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() };

            // solution with lambda expression
            // var studentsWithExcellentMarkLambda = students.Where(st => st.ContainMark(6)).Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.GetMarks() });

            // foreach (var student in studentsWithExcellentMarkLambda)
            // {
            // Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            // }
            Console.WriteLine("---13---");
            foreach (var student in studentsWithExcellentMark)
            {
                Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            }

            Console.WriteLine();
        }

        // 14.Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
        public static void FindStudentsByMarkAndMarksCount(int mark = 2, int marksCount = 2)
        {
            var studentsWithMarks =
                from student in students
                where student.Marks.Count(x => x == mark) == marksCount
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() };

            // solution with lambda expressions
            // var studentsWithExactlyTwoMarks2Lambda = students.Where(st => st.Marks.Count(m => m == mark) == marksCount).Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.GetMarks() });
            // foreach (var student in studentsWithExactlyTwoMarks2Lambda)
            // {
            // Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            // }
            Console.WriteLine("---14---");
            foreach (var student in studentsWithMarks)
            {
                Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            }

            Console.WriteLine();
        }

        /// 15.Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        public static void FindStudentMarksEnrolledIn2006()
        {
            // var studentsEnrolledIn2006 =
            // from student in students
            // where student.FN.Substring(4, 2) == "06"
            // select new { FullName = student.FirstName + " " + student.LastName, FN = student.FN, Marks = student.GetMarks() };
            // Console.WriteLine("---15---");
            // foreach (var student in studentsEnrolledIn2006)
            // {
            //    Console.WriteLine("{0} - FN: {1} -> {2}", student.FullName, student.FN, student.Marks);
            // }
            // Console.WriteLine();
            var studentsEnrolledIn2006Lambda =
                students.Where(st => st.FN.Substring(4, 2).Equals("06"))
                    .Select(st => new { FullName = st.FirstName + " " + st.LastName, FN = st.FN, Marks = st.GetMarks() });

            Console.WriteLine("---15---");

            foreach (var student in studentsEnrolledIn2006Lambda)
            {
                Console.WriteLine("{0} - FN: {1} -> {2}", student.FullName, student.FN, student.Marks);
            }

            Console.WriteLine();
        }

        /// 16*. Create a class Group with properties GroupNumber and DepartmentName.
        /// Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.
        public static void FindStudentsInMathematicsDepartment()
        {
            Group[] groups = new Group[]
            {
                new Group(15, "Mathematics"),
                new Group(11, "Medicine"),
                new Group(3, "Physics"),
                new Group(1, "Chemistry")
            };

            var result =
                from groupp in groups
                join student in students on groupp.DepartmentName equals student.Group.DepartmentName
                where groupp.DepartmentName == "Mathematics"
                select new { Department = student.Group.DepartmentName, Name = student.FirstName + " " + student.LastName };

            Console.WriteLine("---16---");
            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " -> " + item.Department);
            }
        }

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

            FindStudentsFromGroup(2);

            students.FindStudentsFromGroupExtension(2);

            FindStudentsFromSecondGroupWithLambda(2);

            FindStudentsWithEmailIn("abv.bg");

            FindStudentsWithSofiaPhoneNumber();

            FindStudentsWithAtLeastOneExcellentMark();

            FindStudentsByMarkAndMarksCount();

            students.ExtractStudentWithMarkAndMarkCountExtension(2, 2);

            FindStudentMarksEnrolledIn2006();

            FindStudentsInMathematicsDepartment();
        }
    }

    public static class Extensions
    {
        public static void FindStudentsFromGroupExtension(this IEnumerable<Student> students, int groupNumber = 0)
        {
            var studentsFromSecondGroupWithLambda = students.Where(x => x.GroupNumber == groupNumber).OrderBy(x => x.FirstName);

            Console.WriteLine("---10---");
            Tester.Print(studentsFromSecondGroupWithLambda);
        }

        public static void ExtractStudentWithMarkAndMarkCountExtension(this IEnumerable<Student> students, int mark = 0, int marksCount = 0)
        {
            var studentsWithMarks =
                from student in students
                where student.Marks.Count(x => x == mark) == marksCount
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() };

            Console.WriteLine("---14---");
            foreach (var student in studentsWithMarks)
            {
                Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            }

            Console.WriteLine();
        }
    }
}