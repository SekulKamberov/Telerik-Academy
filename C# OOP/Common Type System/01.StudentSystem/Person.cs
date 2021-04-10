namespace _01.StudentSystem
{
    using System;

    public class Person
    {
        private const string AgeIsNullMessage = "NOT specified.";

        private string name;
        private int? age;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, int? age)
            : this(name)
        {
            this.Age = age;
        }

        public int? Age
        {
            get 
            {
                return this.age; 
            }

            set 
            {
                bool isNotNull = value != null;
                bool isOutOfRange = value < 0 && 120 < value;

                if (isNotNull && isOutOfRange)
                {
                    throw new ArgumentOutOfRangeException("Age is out of range.");
                }

                this.age = value; 
            }
        }
        
        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name is null or empty.");
                }

                this.name = value; 
            }
        }

        public override string ToString()
        {
            string ageMessage = string.Empty;

            if (this.Age == null)
            {
                ageMessage = AgeIsNullMessage;
            }
            else
            {
                ageMessage = this.Age.ToString();
            }

            return string.Format("Name: {0}\nAge: {1}", this.Name, ageMessage);
        }
    }
}
