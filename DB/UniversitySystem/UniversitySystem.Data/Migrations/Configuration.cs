namespace UniversitySystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UniversitySystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<UniversitySystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UniversitySystemDbContext context)
        {
            var firstStudent = new Student 
            { 
                Name = "Pesho", 
                Number = "150101" 
            };

            var secondStudent = new Student
            {
                Name = "Gosho",
                Number = "150102"
            };

            context.Students.AddOrUpdate(s => s.Name, firstStudent, secondStudent);
            context.SaveChanges();
            firstStudent.MentorId = secondStudent.Id;
            context.SaveChanges();

            var firstCourse = new Course()
            {
                Name = "Databases",
                Description = "Entity Framework",
                Materials = "BOOKS"
            };
            firstCourse.Students.Add(firstStudent);

            var secondCourse = new Course()
            {
                Name = "SQL",
                Description = "T-SQL",
                Materials = "MORE BOOKS",
            };
            secondCourse.Students.Add(firstStudent);
            secondStudent.Courses.Add(secondCourse);

            context.Courses.AddOrUpdate<Course>(
                c => c.Name, 
                firstCourse,
                secondCourse);

            context.SaveChanges();

            var homework1 = new Homework()
            {
                Content = "Homework 1",
                StudentId = firstStudent.Id,
                CourseId = firstCourse.Id
            };
            var homework2 = new Homework()
            {
                Content = "Homework 2",
                StudentId = firstStudent.Id,
                CourseId = secondCourse.Id
            };
            context.Homeworks.AddOrUpdate<Homework>(h => h.Content, homework1, homework2);
        }
    }
}
