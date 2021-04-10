namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Student firstStudent = new Student("Ivan");
            Student secondStudent = new Student("Dragan");
            Console.WriteLine(firstStudent.Id);
            Console.WriteLine(secondStudent.Id);
            Discipline discipline = new Discipline("OOP", 12, 12);
            IList<Discipline> disciplines = new List<Discipline>();
            disciplines.Add(discipline);
            Teacher firstTeacher = new Teacher("Petko");
            Teacher secondTeacher = new Teacher("Drago", disciplines);
            Console.WriteLine(secondTeacher.Name);
            Clas clas = new Clas();
            clas.Students = new List<Student>() { firstStudent, secondStudent };
            clas.Teachers = new List<Teacher>() { firstTeacher, secondTeacher };
            firstStudent.Comment("NERD");
            secondTeacher.Comment("THE NERD");
            discipline.Comment("THE DISCIPLINE");
            School school = new School(new List<Clas>() { clas });
        }
    }
}
