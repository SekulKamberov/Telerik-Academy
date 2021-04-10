namespace PeoplesRepo
{
    using System;

    public class Person
    {
        private const int FirstNameMinLength = 3;
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value.Length < FirstNameMinLength)
                {
                    throw new ArgumentOutOfRangeException("First name is too short!");
                }

                this.firstName = value;
            }
        }

        public string LastName 
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }
    }
}
