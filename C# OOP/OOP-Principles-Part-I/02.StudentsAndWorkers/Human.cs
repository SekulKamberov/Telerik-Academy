namespace _02.StudentsAndWorkers
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get 
            {
                return this.firstName; 
            }

            set 
            { 
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
    }
}
