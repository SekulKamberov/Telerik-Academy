namespace _02.FindProductsInRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RandomGenerator;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfProducts = 500000;
            var numberOfSearches = 10000;
            var minPrice = 0;
            var maxPrice = 100000;
            var products = new Product[numberOfProducts];
            var productsToDisplay = 20;
            var orderedBag = new OrderedBag<Product>();
            Console.WriteLine("Generating list of products...");
            for (int j = 0; j < numberOfProducts; j++)
            {
                products[j] = new Product()
                {
                    Name = RandomGenerator.GetRandomString(5),
                    Price = RandomGenerator.GeneratRandomNumber(minPrice, maxPrice)
                };
                orderedBag.Add(products[j]);
                if (j % 50000 == 0)
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();

            for (int i = 0; i < numberOfSearches; i++)
            {
                var rangeMinPrice = RandomGenerator.GeneratRandomNumber(minPrice, maxPrice);
                var rangeMaxPrice = RandomGenerator.GeneratRandomNumber(rangeMinPrice, maxPrice);
                Console.WriteLine("Price range [{0}, {1}]", rangeMinPrice, rangeMaxPrice);
                Console.WriteLine("=====Search ({0}) Result=====", i + 1);
                var productsInRange = orderedBag
                    .Range(new Product() { Price = rangeMinPrice }, true, new Product() { Price = rangeMaxPrice }, true)
                    .Take(productsToDisplay);

                // Console.WriteLine(orderedBag.Range(new Product() { Price = rangeMinPrice }, true, new Product() { Price = rangeMaxPrice }, true));
                foreach (var product in productsInRange)
                {
                    Console.WriteLine(product);
                }

                Console.WriteLine("\nPress Enter for another search.");
                Console.ReadLine();
            }
        }
    }
}
