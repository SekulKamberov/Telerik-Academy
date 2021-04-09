namespace _03.Animals
{
    using System;
    using System.Linq;

    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private bool isMale;

        public Animal(string name, int age, bool isMale)
        {
            this.Name = name;
            this.Age = age;
            this.isMale = isMale;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public bool IsMale
        {
            get { return this.isMale; }
            set { this.isMale = value; }
        }

        public static double AverageAge(Animal[] arr)
        {
            return arr.Average(x => x.Age);
        }

        public string Hunt()
        {
            return string.Format("{0} is hunting", this.Name);
        }

        public abstract void MakeSound();
    }
}
