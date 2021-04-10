namespace _03.Animals
{
    using System;

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.Male)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Tomcat sound!");
        }
    }
}
