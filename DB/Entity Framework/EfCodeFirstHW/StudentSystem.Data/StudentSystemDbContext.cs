namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystemModel;

    public class StudentSystemDbContext : DbContext
    {
        // "StudentSystemCodeFirst" is the name of the database
        public StudentSystemDbContext()
            : base("StudentSystemCodeFirst")
        {

        }
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<CourseStudent> CoursesStudents { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Teacher> Teachers { get; set; }

        public IDbSet<TeacherCourse> TeachersCourses { get; set; }
    }
}
