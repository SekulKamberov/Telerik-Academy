namespace _03.Animals
{
    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private Gender sex;

        public Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public Gender Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public abstract void MakeSound();
    }
}
