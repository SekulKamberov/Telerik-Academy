/*
 Problem 2: Define abstract class Human with first name and last name. Define new class Student which is derived
    from Human and has new field – grade. Define class Worker derived from Human with new property WeekSalary and
    WorkHoursPerDay and method MoneyPerHour() that returns money earned by hour by the worker. Define the proper 
    constructors and properties for this hierarchy.
  Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
    Initialize a list of 10 workers and sort them by money per hour in descending order.
    Merge the lists and sort them by first name and last name.*/

namespace _02.StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MainProgram
    {
        public static void Main()
        {
            var students = new List<Student>()
            {
                new Student("Miro", "Penev", 11),
                new Student("Giro", "Velev", 2),
                new Student("Dimo", "Dimov", 12),
                new Student("Misho", "Peshev", 10),
                new Student("Tisho", "Tihov", 2),
                new Student("Grisho", "Dimitrov", 7),
                new Student("Dwayne", "Atanasov", 4),
                new Student("Dwight", "Wight", 5),
                new Student("Klechko", "Klechkov", 9),
                new Student("Kubrat", "Pulev", 6)
            };

            var workers = new List<Worker>()
            {
                new Worker("Dimitar", "Berbatov", 40.0m, 8),
                new Worker("Dimitar", "Barbukov", 150.0m, 4),
                new Worker("Jeremy", "Clarcksen", 100.0m, 2),
                new Worker("James", "May", 30.0m, 4),
                new Worker("Cristiano", "Ronaldo", 300.0m, 10),
                new Worker("Hasan", "Azis", 80.0m, 3),
                new Worker("Gosho", "Peshov", 50.0m, 9),
                new Worker("Pesho", "Goshov", 60.0m, 5),
                new Worker("Gero", "Gerov", 20.0m, 2),
                new Worker("Yasen", "Neqsnikov", 40.0m, 4)
            };

            var sortedByGrade = students.OrderBy(x => x.Grade);

            //Console.WriteLine("Students ordered by ascending grades");
            //foreach (var stud in sortedByGrade)
            //{
            //    Console.WriteLine("{0,-7} {1,-8} {2}", stud.FirstName, stud.LastName,stud.Grade);
            //}
            //Console.WriteLine();

            var sortBySalary = workers.OrderByDescending(x => x.MoneyPerHour());

            //Console.WriteLine("Workers ordered by descending money per hour");
            //foreach (var worker in sortBySalary)
            //{
            //    Console.WriteLine("{0,-9} {1,-10} {2:C}", worker.FirstName, worker.LastName,worker.MoneyPerHour());
		        
            //}
            //Console.WriteLine();

            var concatGroups = sortedByGrade
                .Concat<Human>(sortBySalary)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            //Console.WriteLine("Both groups concatenated and sorted by names");
            //foreach (var person in concatGroups)
            //{
            //    Console.WriteLine("{0,-9} {1, -10}", person.FirstName, person.LastName);
            //}
        }
    }
}
