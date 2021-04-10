namespace School
{
    using System;

    public class Student
    {
        private static int counter = 100000;
        private string name;
        private int uniqueNumber;

        public Student(string name)
        {
            this.Name = name;
            counter++;
            this.UniqueNumber = counter;
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            set
            {
                this.uniqueNumber = value;
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
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("Name cannot be empty!");
                }

                this.name = value; 
            }
        }
    }
}
