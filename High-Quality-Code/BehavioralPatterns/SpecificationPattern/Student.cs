namespace SpecificationPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        public Student(string name, FacultyName faculty, IList<double> grades)
        {
            this.Name = name;
            this.Faculty = faculty;
            this.Grades = grades;
        }

        public string Name { get; set; }

        public FacultyName Faculty { get; set; }

        public IList<double> Grades { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Faculty: " + this.Faculty.ToString());
            sb.AppendLine("Grades: " + string.Join(", ", this.Grades));
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
