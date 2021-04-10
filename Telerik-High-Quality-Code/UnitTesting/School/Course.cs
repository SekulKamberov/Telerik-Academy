namespace School
{
    using System.Collections.Generic;

    public class Course
    {
        private IList<Student> students;

        public Course()
        {
            this.Students = new List<Student>();
        }

        public IList<Student> Students
        {
            get 
            { 
                return this.students; 
            }

            set 
            {
                this.students = value; 
            }
        }

        public bool Add(Student student)
        {
            if (this.Students.Count == 30)
            {
                return false;
            }

            bool studentIsInTheCourse = this.CheckStudentInTheCourse(student);

            if (studentIsInTheCourse)
            {
                return false;
            }
            else
            {
                this.Students.Add(student);

                return true;
            }
        }

        private bool CheckStudentInTheCourse(Student student)
        {
            foreach (var currentStudent in this.Students)
            {
                if (currentStudent.UniqueNumber == student.UniqueNumber)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
