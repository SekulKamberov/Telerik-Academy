namespace _04.PersonClass
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private int? age;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, byte age)
            : this(name)
        {
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int? Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0 || value > 130)
                {
                    throw new ArgumentException("Age is not in range or is null");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Name: " + this.Name);

            if (this.Age == null)
            {
                sb.AppendLine("Age: Not specified");
            }
            else
            {
                sb.AppendLine("Age: " + this.Age);
            }

            return sb.ToString();
        }
    }
}
