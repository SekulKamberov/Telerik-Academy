namespace _02.StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Random ran = new Random();
            var students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student("FirstName" + ran.Next(1, 10), "LastName" + ran.Next(1, 10), ran.Next(2, 7)));
            }

            students = students.OrderBy(student => student.Grade).ToList();

            foreach (var student in students)
            {
                Console.WriteLine("{0} {1} Grade: {2}", student.FirstName, student.LastName, student.Grade);
            }

            var workers = new List<Worker>();

            for (int i = 0; i < 10; i++)
            {
                workers.Add(new Worker("FirstName" + ran.Next(1, 10), "LastName" + ran.Next(1, 10), ran.Next(10, 20), ran.Next(2, 10)));
            }

            workers = workers.OrderByDescending(worker => worker.MoneyPerHour()).ToList();
            Console.WriteLine();

            foreach (var worker in workers)
            {
                Console.WriteLine("{0} {1} MoneyPerHour: {2}", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }

            var humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);
            humans = humans.OrderBy(human => human.FirstName).ThenBy(human => human.LastName).ToList();
            Console.WriteLine();

            foreach (var human in humans)
            {
                Console.WriteLine("{0} {1} {2}", human.FirstName, human.LastName, human.GetType().Name);
            }
        }
    }
}
