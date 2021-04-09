namespace School
{
    using System;

    public class Student : Person
    {
        private int classNumber;

        public Student(string firstName, string lastName, int classNumber)
            :base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get { return this.classNumber; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Number cannot be less than or equal to 0");
                }

                this.classNumber = value;
            }
        }
    }
}
