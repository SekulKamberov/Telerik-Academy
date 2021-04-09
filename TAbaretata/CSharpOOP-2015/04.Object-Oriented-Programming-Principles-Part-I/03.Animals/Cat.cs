namespace _03.Animals
{
    using System;

    public class Cat : Animal
    {
        public Cat(string name, int age, bool isMale)
            : base(name, age, isMale)
        { 
        
        }

        public string BeGracious()
        {
            return string.Format("{0} is being gracious", this.Name);
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow Meow");
        }
    }
}
