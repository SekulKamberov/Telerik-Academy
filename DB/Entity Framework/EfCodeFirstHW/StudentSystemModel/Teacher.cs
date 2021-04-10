namespace StudentSystemModel
{
    using System.Collections.Generic;

    public class Teacher
    {
       private ICollection<TeacherCourse> teachersCourses;
        public Teacher()
        {
            this.TeachersCourses = new HashSet<TeacherCourse>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TeacherCourse> TeachersCourses 
        { 
            get
            {
                return this.teachersCourses;
            }
            set
            {
                this.teachersCourses = value;
            }
        }
    }
}
