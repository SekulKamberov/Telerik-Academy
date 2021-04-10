namespace _03.Animals
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Animal animal = new Animal("", 34, Gender.Male);
            Dog dog = new Dog("DOG", 16, Gender.Male);
            Cat cat = new Cat("CAT", 11, Gender.Female);
            Frog frog = new Frog("FROG", 4, Gender.Female);
            Tomcat tomcat = new Tomcat("TOMCAT", 1);
            Kitten kitten = new Kitten("KITTEN", 2);
            IList<Animal> animals = new List<Animal>() { dog, cat, frog, tomcat, kitten };
            IList<Animal> sortedAnimals = animals.SortAnimals();

            foreach (var animal in sortedAnimals)
            {
                Console.Write("{0} {1} {2} {3} ", animal.GetType().Name, animal.Name, animal.Age, animal.Sex);
                animal.MakeSound();
            }

            Console.WriteLine("Average age: " + animals.AverageAge());
        }
    }
}
