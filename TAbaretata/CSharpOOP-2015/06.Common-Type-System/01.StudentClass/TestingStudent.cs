/*
 * Problem 1: Define a class Student, which contains data about a student – first, middle and last name, SSN, 
    permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties,
    universities and faculties.
   Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
 * Problem 2: Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's 
    fields into a new object of type Student.
 * Problem 3: Implement the IComparable<Student> interface to compare students by names (as first criteria, in 
    lexicographic order) and by social security number (as second criteria, in increasing order).
 */

namespace _01.StudentClass
{
    using System;

    public class TestingStudent
    {
        public static void Main()
        {
            var student = new Student(
                "Pesho",
                "Peshev",
                "Petkov",
                "029338419",
                "23 Elm Street",
                "0885100300",
                "pesho@abv.bg",
                "Software engineering",
                Speciality.Mathematics,
                University.TechUni,
                Faculty.SF);

            Console.WriteLine(student.ToString());

            var otherStudent = student.Clone();

            Console.WriteLine(otherStudent);
        }
    }
}
