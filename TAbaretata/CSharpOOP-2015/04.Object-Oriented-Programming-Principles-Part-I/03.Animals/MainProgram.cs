/*
 * Problem 3: Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
    Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
    Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only 
    female and tomcats can be only male. Each animal produces a specific sound.
        Create arrays of different kinds of animals and calculate the average age of each kind of animal using 
    a static method (you may use LINQ).
 */

namespace _03.Animals
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            Dog[] dogs = new Dog[]
            {
                new Dog("Jaro", 7, true, "Golden Retriever"),
                new Dog("Sharo", 3, true, "German Sheperd"),
                new Dog("Doge", 5, true, "Labrador Retriever"),
                new Dog("Estel", 10, false, "Pincher")
            };

            Frog[] frogs = new Frog[]
            {
                new Frog("Kikirica", 13, false),
                new Frog("Jaba", 15, false),
                new Frog("Froggy", 5, true),
                new Frog("Nikoleta Lozanova", 10, false)
            };

            Cat[] cats = new Cat[] 
            {
                new Cat("Street Excellent", 3, false),
                new Cat("Home Excellent", 5, false),
                new Cat("Persiiko", 1, true),
                new Cat("Garfield", 7, true)
            };

            Kitten[] kittens = new Kitten[]
            {
                new Kitten("Malcho", 1),
                new Kitten("Palcho", 2),
                new Kitten("Shalco", 1)
            
            };

            Tomcat[] tomcats = new Tomcat[]
            {
                new Tomcat("Kotio", 5),
                new Tomcat("Gosho", 4),
                new Tomcat("Pesho", 8)
            };

            double dogsAverageAge = Animal.AverageAge(dogs);
            double frogsAverageAge = Animal.AverageAge(frogs);
            double catsAverageAge = Animal.AverageAge(cats);
            double kittensAverageAge = Animal.AverageAge(kittens);
            double tomcatsAverageAge = Animal.AverageAge(tomcats);

            Console.WriteLine("Average age of the dogs: {0:F2}", dogsAverageAge);
            Console.WriteLine("Average age of the frogs: {0:F2}", frogsAverageAge);
            Console.WriteLine("Average age of the cats: {0:F2}", catsAverageAge);
            Console.WriteLine("Average age of the kittens: {0:F2}", kittensAverageAge);
            Console.WriteLine("Average age of the tomcats: {0:F2}", tomcatsAverageAge);

            Console.WriteLine(new string('-', 10));

            Console.WriteLine("Actions: ");
            Console.WriteLine(tomcats[0].Hunt());
            Console.WriteLine((cats[1].BeGracious()));
            Console.WriteLine(dogs[2].Fetch());
            Console.WriteLine(frogs[1].JumpAround());

            Console.WriteLine(new string('-', 10));

            Console.WriteLine("Sounds: ");
            cats[0].MakeSound();
            dogs[1].MakeSound();
            frogs[2].MakeSound();
        }
    }
}
