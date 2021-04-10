namespace _03.Animals
{
    using System;

    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, Gender.Female)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Kitten sound!");
        }
    }
}
