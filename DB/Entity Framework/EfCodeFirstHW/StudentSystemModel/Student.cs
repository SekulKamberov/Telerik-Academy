namespace StudentSystemModel
{
    using System.Collections.Generic;

    public class Student
    {
        private ICollection<Homework> homeworks;
        private ICollection<CourseStudent> coursesStudents;

        public Student()
        {
            this.Homeworks = new HashSet<Homework>();
            this.CoursesStudents = new HashSet<CourseStudent>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string StudentNumber { get; set; }

        public virtual ICollection<Homework> Homeworks 
        { 
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }

        public virtual ICollection<CourseStudent> CoursesStudents
        {
            get
            {
                return this.coursesStudents;
            }
            set
            {
                this.coursesStudents = value;
            }
        }
    }
}
