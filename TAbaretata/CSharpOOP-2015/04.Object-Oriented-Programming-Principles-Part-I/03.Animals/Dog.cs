namespace _03.Animals
{
    using System;

    public class Dog : Animal
    {
        private string breed;

        public Dog(string name, int age, bool isMale, string breed)
            : base(name, age, isMale)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return this.breed; }
            private set { this.breed = value; }
        }

        public string Fetch()
        {
            return string.Format("{0} is fetching a bone", this.Name);
        }

        public override void MakeSound()
        {
            Console.WriteLine("Rawr rawr");
        }
    }
}
