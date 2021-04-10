namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystemModel;
    using System.Data.Entity;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Data.Repository;
    public class StudentSystemConsoleClient
    {
        static void Main(string[] args)
        {
            // this can be set in StudentSystemDbContext.cs
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            // OR
            //Database.SetInitializer(new DropCreateDatabaseAlways<StudentSystemDbContext>());

            //var db = new StudentSystemDbContext();

            //var studentsDB = new GenericRepository<Student>(db);

            var data = new StudentSystemData();

            foreach (var student in data.Students.All())
            {
                Console.WriteLine(student.FirstName);
            }

            data.Students.Add(new Student
            {
                FirstName = "Goshko",
                LastName = "Peshkov"
            });

            data.Students.SaveChanges();

            //db.Database.Initialize(true);

            //var student = new Student
            //{
            //    FirstName = "Boyan",
            //    LastName = "Ivanov",
            //    Age = 32,
            //    ContactInfo = new StudentContactInfo 
            //    {
            //        Email = "abv@abv.bg"
            //    },
            //    StudentStatus = StudentStatus.Online
            //};

            //student.Courses.Add(new Course
            //{
            //    Name = "Entity Framework",
            //    Description = "Entity Framework for Dumies"
            //});

            //db.Students.Add(student);
            //db.SaveChanges();

            //var savedStudent = db.Students.First();
            //Console.WriteLine(savedStudent.FirstName + " " + savedStudent.LastName + " Age: " + savedStudent.Age + " Status: " + savedStudent.StudentStatus);

        }
    }
}
