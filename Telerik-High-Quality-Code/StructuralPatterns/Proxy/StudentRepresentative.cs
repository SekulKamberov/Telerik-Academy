namespace Proxy
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Commander Pattern
    /// </summary>
    public class StudentRepresentative : Student
    {
        private readonly ICollection<Student> studentsToRepresent;

        public StudentRepresentative(string name)
            : base(name)
        {
            this.studentsToRepresent = new List<Student>();
        }

        public void Add(Student student)
        {
            this.studentsToRepresent.Add(student);
        }

        public void Remove(Student student)
        {
            this.studentsToRepresent.Remove(student);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);

            foreach (var student in this.studentsToRepresent)
            {
                student.Display(depth + 4);
            }
        }
    }
}
