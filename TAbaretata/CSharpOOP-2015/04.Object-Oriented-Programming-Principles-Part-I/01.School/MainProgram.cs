/* Problem 1: We are given a school. In the school there are classes of students. Each class has a set of teachers. 
    Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text identifier.
    Teachers have name. Disciplines have name, number of lectures and number of exercises. Both teachers and students are people.
    Students, classes, teachers and disciplines could have optional comments (free text block).
      Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate their fields,
    define the class hierarchy and create a class diagram with Visual Studio.
 */

namespace School
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            Student dwayne = new Student("Pesho", "Peshov", 6);

            Console.WriteLine("Student name: {0}, Class number: {1}", dwayne.ToString(), dwayne.ClassNumber);

            Teacher firstTeacher = new Teacher(
                "Ivan", 
                "Petkov",
                new Discipline("Math", 15, 20),
                new Discipline("Art", 10, 12));

            Console.WriteLine(firstTeacher.ToString());

            Teacher secondTeacher = new Teacher(
                "The",
                "Rock",
                new Discipline("Sports", 30, 40));

            School newSchool = new School(
                new Class("12a", firstTeacher),
                new Class("12b", secondTeacher));
        }
    }
}
