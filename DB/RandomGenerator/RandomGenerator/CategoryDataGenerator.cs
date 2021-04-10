namespace RandomGenerator
{
    using ATMStore;

    using System;
    using System.Collections.Generic;

    internal class CardNumberDataGenerator : DataGenerator, IDataGenerator
    {
        public CardNumberDataGenerator(IRandomDataGenerator randomDataGenerator, ATMEntities atmEntities, int countGeneratedObjects) 
            : base(randomDataGenerator, atmEntities, countGeneratedObjects)
        {
        }

        public void Generate()
        {
            //Console.WriteLine("Adding Categories");
            //for (int i = 0; i < this.count; i++)
            //{
            //    var cardAccount = new CardAccount
            //    {
            //        CardNumber = this.random.GetRandomStringOfNumbers(10),
            //        CardPin = this.random.GetRandomStringOfNumbers(4),
            //        CardCash = this.random.GetRandomNumber(0, 1000)
            //    };

            //    this.db.CardAccounts.Add(cardAccount);
            //    if (i % 100 == 0)
            //    {
            //        Console.WriteLine("... 100 categories added...");
            //        db.SaveChanges();
            //    }
            //}
            //Console.WriteLine("Categories added");


            //GENERATE RANDOM CARD NUMBERS
            // ABSTRACT
            var cardNumbersToBeAdded = new HashSet<string>();

            while (cardNumbersToBeAdded.Count != this.Count)
            {
                cardNumbersToBeAdded.Add(this.Random.GetRandomStringOfNumbers(10));
                
            }

            int index = 0;
            Console.WriteLine("Adding....");
            foreach (var cardNumber in cardNumbersToBeAdded)
            {
                var cardAccount = new CardAccount
                {
                    CardNumber = cardNumber,
                    CardPin = this.Random.GetRandomStringOfNumbers(4),
                    CardCash = this.Random.GetRandomNumber(0, 1000)
                    //......... = ......
                };

                if (index % 100 == 0)
                {
                    Console.WriteLine(".");
                    Database.SaveChanges();
                }

                this.Database.CardAccounts.Add(cardAccount);

                index++;
            }

            Console.WriteLine("Added!");


        }
    }
}
