namespace StudentSystem.ConsoleClient
{
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystemModel;
    using System;
    using System.Data.Entity;

    public class StudentSystemConsoleClient
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<StudentSystemDbContext>());
            var db = new StudentSystemDbContext();

            var student = new Student
            {
                Age = 23,
                Name = "Svetlin Nakov",
                StudentNumber = "020204"
            };

            var anotherStudent = new Student
            {
                Age = 34,
                Name = "Keno Nakov",
                StudentNumber = "034204"
            };

            db.Students.Add(student);
            db.Students.Add(anotherStudent);
            db.SaveChanges();

            var course = new Course
            {
                Name = "Java",
                Description = "Java for dumies",
                Materials = "Some Books"
            };

            var course2 = new Course
            {
                Name = "JavaScript",
                Description = "Dumies book",
                Materials = "Some Books"
            };

            db.Courses.Add(course);
            db.Courses.Add(course2);
            db.SaveChanges();

            var hw = new Homework
            {
                Content = "Entity Framework",
                TimeSent = new DateTime(2014, 08, 31),
                StudentId = 1,
                CourseId = 2
            };

            var hw2 = new Homework
            {
                Content = "Entity Framework Code First",
                TimeSent = new DateTime(2014, 08, 30),
                StudentId = 2,
                CourseId = 1
            };

            db.Homeworks.Add(hw);
            db.Homeworks.Add(hw2);
            db.SaveChanges();

            var sc = new CourseStudent
            {
                StudentId = 1,
                CourseId = 2
            };

            var sc2 = new CourseStudent
            {
                StudentId = 1,
                CourseId = 1
            };

            var sc3 = new CourseStudent
            {
                StudentId = 2,
                CourseId = 2
            };

            db.CoursesStudents.Add(sc);
            db.CoursesStudents.Add(sc2);
            db.CoursesStudents.Add(sc3);

            anotherStudent.CoursesStudents.Add(new CourseStudent 
            {
                CourseId = 1
            });

            db.SaveChanges();

            var savedStudent = db.Students.First();

            Console.WriteLine("ID:" + savedStudent.Id + " Name: " + savedStudent.Name + " StudentNumber: " + savedStudent.StudentNumber  );
        }
    }
}
