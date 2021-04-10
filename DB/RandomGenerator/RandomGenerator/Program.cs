namespace RandomGenerator
{
    using System.Collections.Generic;

    using ATMStore;

    class Program
    {
        static void Main(string[] args)
        {
            var random = RandomDataGenerator.Instance;
            var db = new ATMEntities();

            var listOfGenerators = new List<IDataGenerator>
            {
                new CardNumberDataGenerator(random, db, 100),
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
