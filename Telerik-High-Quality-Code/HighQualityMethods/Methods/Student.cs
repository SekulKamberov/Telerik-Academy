namespace Methods
{
    using System;

    internal class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public DateTime BornOn { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.BornOn > other.BornOn;
        }
    }
}
