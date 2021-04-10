namespace UniversitySystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using UniversitySystem.Data;
    using UniversitySystem.Data.Migrations;
    using UniversitySystem.Data.Repository;
    using UniversitySystem.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversitySystemDbContext, Configuration>());
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UniversitySystemDbContext>());
            // Database.SetInitializer(new DropCreateDatabaseAlways<UniversitySystemDbContext>());
            var id = new Random().Next(10, 99);
            using (var data = new UniversitySystemDbContext())
            {
                var student = new Student()
                {
                    Name = "Pesho" + id,
                    Number = "1501" + id,
                };

                data.Students.Add(student);

                var course = new Course()
                {
                    Name = "Javascript" + id,
                    Description = "Mission Imposible!!!",
                };

                course.Students.Add(student);
                data.SaveChanges();
            }

            // var repos = new EFRepository<Student>();
            // repos.Add(new Student()
            // {
            // Name = "To6o" + id,
            // Number = "1503" + id,
            // });
            // repos.SaveChanges();
        }
    }
}
