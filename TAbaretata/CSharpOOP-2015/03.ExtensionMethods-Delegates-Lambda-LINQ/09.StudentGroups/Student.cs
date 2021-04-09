namespace _09.StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string fN;
        private string phoneNumber;
        private string email;
        private List<int> marks;
        private int groupNumber;

        public Student()
        {
        }

        public Student(string firstName, string lastName, string fN,
            string phoneNumber, string email, List<int> marks, int groupNumber)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fN;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Students name cannot be empty or null");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Students name cannot be empty or null");
                }

                this.lastName = value;
            }
        }

        public string FN
        {
            get { return this.fN; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Students faculty number cannot be empty or null");
                }

                this.fN = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Students phone number cannot be empty or null");
                }

                this.phoneNumber = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Students email cannot be empty or null");
                }

                this.email = value;
            }
        }

        public List<int> Marks
        {
            get { return this.marks; }
            private set { this.marks = value; }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Students group number cannot be null or empty");
                }

                this.groupNumber = value;
            }
        }

        public Group Group { get; private set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
