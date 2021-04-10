namespace _02.Articles
{
    using System;
    using Wintellect.PowerCollections;
    public class Program
    {
        /*
         * A large trade company has millions of articles, each described by barcode, vendor, title and price. 
         * Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y]. 
         * Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET.
         */ 
        static void Main(string[] args)
        {
            Random ran = new Random();
            OrderedMultiDictionary<double, Article> dictionary = new OrderedMultiDictionary<double, Article>(false);

            for (int i = 0; i < 100; i++)
            {
                Article article = new Article("Title" + i, i << 17, "Vendor" + (i << 3));
                var price = Math.Round(ran.NextDouble() * 100, 2);

                dictionary.Add(price, article);
            }

            foreach (var article in dictionary)
            {
                Console.WriteLine("Price: " + article.Key + " " + article.Value);
            }
        }
    }
}
