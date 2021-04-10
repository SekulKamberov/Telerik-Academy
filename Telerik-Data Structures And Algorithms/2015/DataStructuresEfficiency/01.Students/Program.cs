namespace _01.Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @"..\..\students.txt";
            var students = ReadFile(path);
            var sortedStudents = SortStudents(students);
            PrintSortedStudents(sortedStudents);
        }

        private static ICollection<Student> ReadFile(string filePath)
        {
            char[] separators = new char[] { ' ', '|' };
            var students = new List<Student>();

            using (var streamReader = new StreamReader(filePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var studentInfo = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    if (studentInfo.Length == 3)
                    {
                        var firstName = studentInfo[0];
                        var lastName = studentInfo[1];
                        var courseName = studentInfo[2];
                        var student = new Student(firstName, lastName, courseName);
                        students.Add(student);
                    }
                }
            }

            return students;
        }

        // For Duplicates use List<FirstName> instead of SortedSet<FirstName>
        private static SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> SortStudents(ICollection<Student> students)
        {
            var sortedStudents = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();

            foreach (var student in students)
            {
                var course = student.CourseName;
                if (!sortedStudents.ContainsKey(course))
                {
                    sortedStudents.Add(course, new SortedDictionary<string, SortedSet<string>>());
                }

                var studentLastName = student.LastName;
                if (!sortedStudents[course].ContainsKey(studentLastName))
                {
                    sortedStudents[course].Add(studentLastName, new SortedSet<string>());
                }

                var studentFirstName = student.FirstName;
                sortedStudents[course][studentLastName].Add(studentFirstName);
            }

            return sortedStudents;
        }

        private static void PrintSortedStudents(SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> sortedStudents)
        {
            foreach (var course in sortedStudents)
            {
                Console.WriteLine("========== {0} ========== ", course.Key);
                foreach (var student in course.Value)
                {
                    var lastName = student.Key;
                    foreach (var firstName in student.Value)
                    {
                        Console.WriteLine("{0}\t{1}", firstName, lastName);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
