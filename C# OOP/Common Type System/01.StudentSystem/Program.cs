namespace _01.StudentSystem
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Student firstStudent = new Student("Ivan", "Ivanove", "Ivanova", "12345679", "0987654321", "abv@abv.bg", 1, "c", University.BostonUniversity, Faculty.Economy, Specialty.BussDriver);

            Student secondStudent = new Student("Ivan", "Ivanove", "Ivanova", "12345677", "0987654321", "abv@abv.bg", 1, "c", University.BostonUniversity, Faculty.Economy, Specialty.BussDriver);

            Student thirdStudent = new Student("Ivan", "Ivanove", "Ivanove", "12345678", "0987654321", "abv@abv.bg", 1, "c", University.BostonUniversity, Faculty.Economy, Specialty.BussDriver);

            Student forthStudent = new Student("Ivanu", "Ivanov", "Ivanov", "12345676", "0987654321", "abv@abv.bg", 1, "c", University.BostonUniversity, Faculty.Economy, Specialty.BussDriver);

            Student[] students = new Student[4] { secondStudent, thirdStudent, firstStudent, forthStudent };

            Array.Sort(students);

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            Person firstPerson = new Person("Svetlin Nakov", null);
            Console.WriteLine(firstPerson);
            Person secondPerson = new Person("Pesho Goshov", 22);
            Console.WriteLine(secondPerson);
        }
    }
}
