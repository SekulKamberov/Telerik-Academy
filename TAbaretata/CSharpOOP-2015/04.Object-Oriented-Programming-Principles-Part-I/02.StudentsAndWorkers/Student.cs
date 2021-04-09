namespace _02.StudentsAndWorkers
{
    using System;

    public class Student : Human
    {
        private int grade;

        public Student(string fname, string lname, int grade)
            : base(fname, lname)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get { return this.grade; }
            private set
            {
                if (value <= 0 || value >= 13)
                {
                    throw new ArgumentException("Grade must be in the range [1..12]");
                }

                this.grade = value;
            }
        }
    }
}
