namespace EF_Performance
{
    using EF_Performance.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            // STEP 5
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsDb, Configuration>());


            var db = new StudentsDb();

            //STEP 1

            //for (int i = 0; i < 100; i++)
            //{
            //    db.Students.Add(new Student
            //    {
            //        Name = "Pe6o" + i,
            //        City = new City()
            //        {
            //            Name = "Sofia" + i
            //        }
            //    });
            //}


            //// STEP 2
            // makes 100 select queries

            //foreach (var student in db.Students)
            //{
            //    Console.WriteLine("{0} ({1})", student.Name, student.City.Name);
            //}


            //// STEP 3
            //// makes 1 select query

            //foreach (var student in db.Students.Include("City"))
            //{
            //    Console.WriteLine("{0} ({1})", student.Name, student.City.Name);
            //}


            // STEP 4
            // makes 1 select query too, but better

            //var students = db.Students
            //    .Select(student => new
            //    {
            //        Name = student.Name,
            //        City = student.City.Name
            //    });

            //foreach (var student in students)
            //{
            //    Console.WriteLine("{0} ({1})", student.Name, student.City);
            //}


            ////// STEP 4 NEVER CALL ToList() to early
            
            ////var students2 = db.Students
            ////    .ToList()
            ////    .Select(student => new
            ////    {
            ////        Name = student.Name,
            ////        City = student.City.Name
            ////    });

            ////foreach (var student in students2)
            ////{
            ////    Console.WriteLine("{0} ({1})", student.Name, student.City);
            ////}

            // STEP 5 

            //for (int i = 0; i < 10000; i++)
            //{
            //    var student = new Student();
            //    student.Name ="Petar" +  i.ToString();
            //    student.City = new City
            //    {
            //        Name = "City" + i
            //    };
            //    student.Picture = new byte[1000];
            //    db.Students.Add(student);
            //    Console.WriteLine(i);

            //}

            //// STEP 7 DEMO

            //var stu = new Student { Name = "OK", City = new City { Name = "OK City" } };
            //var badStudent = new Student { Name = "123456789012345678901234567890123456789012345678901234567890", City = new City { Name = "alabala" } };

            //db.Students.Add(stu);
            //db.Students.Add(badStudent);


            ////// STEP 8 

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //var students2 = db.Students
            //                    .ToList();

            //foreach (var student in students2)
            //{
            //    Console.WriteLine(student.Name);
            //}
            //Console.WriteLine(sw.Elapsed);


            ////// STEP 9 

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //var students2 = db.Students
            //                    .Select(student => new { student.Name })
            //                    .ToList();

            //foreach (var student in students2)
            //{
            //    Console.WriteLine(student.Name);
            //}
            //Console.WriteLine(sw.Elapsed);

            db.SaveChanges();

            // STEP 10  DELETE
            db.Database.ExecuteSqlCommand("DELETE FROM [Students] WHERE [Name] Like '%8';");

            // STEP 11 USE Entity Framework Extention Library

        }
    }
}
