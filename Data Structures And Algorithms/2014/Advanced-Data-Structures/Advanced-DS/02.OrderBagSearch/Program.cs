namespace _02.OrderBagSearch
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;
    public class ProductSearch
    {
        private static void Main()
        {
            
            Console.WriteLine("Generating products...");
            OrderedMultiDictionary<double, string> orderedMultiDictionary = new OrderedMultiDictionary<double, string>(false);
            string name;
            double price;
            for (int i = 0; i < 50000; i++)
            {
                name = DataGerator.GenerateWord();
                price = DataGerator.GeneratePrice();
                orderedMultiDictionary.Add(price, name);
            }

            double minPrice;
            double maxPrice;
            for (int i = 0; i < 10000; i++)
            {
                minPrice = DataGerator.GeneratePrice();
                maxPrice = DataGerator.GeneratePrice();
                if (minPrice > maxPrice)
                {
                    double exchangeHelper = minPrice;
                    minPrice = maxPrice;
                    maxPrice = exchangeHelper;
                }

                Console.WriteLine("===== Price range [{0}, {1}] ===== ", minPrice, maxPrice);

                var collection = orderedMultiDictionary.Range(minPrice, true, maxPrice, true).Take(20);
                var counter = 1;
                foreach (var item in collection)
                {
                    Console.WriteLine("Product: {0} ID: {1} Price: {2}", counter, item.Value, item.Key);
                    counter++;
                }

                Console.WriteLine("=============== END ===============");
            }
        }
    }
}