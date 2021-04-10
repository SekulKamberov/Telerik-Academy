namespace _01.School
{
    public class Student : Person
    {
        private static int counter;
        private int id;

        public Student(string name) 
            : base(name)
        {
            this.Id = counter;
            counter++;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
            }
        }
    }
}
