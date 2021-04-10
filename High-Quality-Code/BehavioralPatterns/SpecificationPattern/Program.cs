namespace SpecificationPattern
{
    using System;
    using System.Collections.Generic;

    using SpecificationPattern.Specifications;
    using SpecificationPattern.Specifications.Base;

    public class Program
    {
        public static void Main(string[] args)
        {
            var firstStudent = new Student("Pesho", FacultyName.RocketScience, new List<double>() { 6, 6, 5 });
            var secondStudent = new Student("Penko", FacultyName.Mathemathics, new List<double>() { 6, 6, 5 });
            var thirdStudent = new Student("Petko", FacultyName.Economy, new List<double>() { 6, 2, 5 });
            var fourtStudent = new Student("Pesho", FacultyName.Biology, new List<double>() { 6, 5, 5 });
            var fifthStudent = new Student("Penko", FacultyName.RocketScience, new List<double>() { 6, 6, 5 });
            var sixtStudent = new Student("Petko", FacultyName.Mathemathics, new List<double>() { 6, 6, 5 });
            var seventStudent = new Student("Pesho", FacultyName.Mathemathics, new List<double>() { 6, 2, 5 });
            var eigthStudent = new Student("Penko", FacultyName.RocketScience, new List<double>() { 6, 6, 5 });
            var ninthStudent = new Student("Petko", FacultyName.Biology, new List<double>() { 6, 6, 5 });
            var tenthStudent = new Student("Pesho", FacultyName.RocketScience, new List<double>() { 2, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 });

            var students = new List<Student>() { firstStudent, secondStudent, thirdStudent, fourtStudent, fifthStudent, sixtStudent, seventStudent, eigthStudent, ninthStudent, tenthStudent };

            var excellent = new ExcellentStudentSpecification();
            var rocketFaculty = new StudentFacultySpecification(FacultyName.RocketScience);
            var biologyFaculty = new StudentFacultySpecification(FacultyName.Biology);
            var nameStartWithPet = new StudentNameStartsWithSpecification("Pet");
            var nameStartWithPen = new StudentNameStartsWithSpecification("Pen");

            var specification = excellent
                .And(rocketFaculty.Not().And(biologyFaculty.Not()))
                .And(nameStartWithPen.Or(nameStartWithPet));

            foreach (var student in students)
            {
                if (specification.IsSatisfiedBy(student))
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
