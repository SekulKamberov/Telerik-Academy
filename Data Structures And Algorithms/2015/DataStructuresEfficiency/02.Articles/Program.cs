namespace _02.Articles
{
    using System;
    using System.Collections.Generic;
    using RandomGenerator;
    using Wintellect.PowerCollections;

    public class Program
    {
        private const int ArticlesCount = 1000000;
        private const int BarcodeLength = 10;
        private const int MinMaxRangeDifference = 10;

        public static void Main(string[] args)
        {
            var articles = GenerateArticles(ArticlesCount);
            Search(articles);
        }

        private static OrderedMultiDictionary<int, Article> GenerateArticles(int count)
        {
            var barcodes = new HashSet<string>();

            Console.Write("Generating barcodes...");
            while (barcodes.Count < count)
            {
                var barcode = RandomGenerator.GetRandomString(BarcodeLength);
                barcodes.Add(barcode);
                if (barcodes.Count % (count / 10) == 0)
                {
                    Console.Write('.');
                }
            }

            Console.Write("\n\nGenerating articles...");
            var articles = new OrderedMultiDictionary<int, Article>(true);
            foreach (var barcode in barcodes)
            {
                var vendor = RandomGenerator.GetRandomString(5);
                var title = RandomGenerator.GetRandomString(7);
                var price = RandomGenerator.GeneratRandomNumber(0, count);
                var article = new Article(barcode, vendor, title, price);
                articles.Add(price, article);
                if (articles.Count % (count / 10) == 0)
                {
                    Console.Write('.');
                }
            }

            Console.WriteLine();
            return articles;
        }

        private static void Search(OrderedMultiDictionary<int, Article> articles)
        {
            while (true)
            {
                var minRange = RandomGenerator.GeneratRandomNumber(0, ArticlesCount);
                var maxRange = minRange + MinMaxRangeDifference;
                Console.WriteLine("========== Price Range[{0}, {1}]", minRange, maxRange);
                Console.WriteLine("Barcode / Vendor / Title / Price");
                articles
                    .Range(minRange, true, maxRange, true)
                    .ForEach(x =>
                    {
                        foreach (var article in x.Value)
                        {
                            Console.WriteLine(article);
                        }
                    });

                Console.WriteLine("\nPress Enter for another search.");
                Console.ReadLine();
            }
        }
    }
}
