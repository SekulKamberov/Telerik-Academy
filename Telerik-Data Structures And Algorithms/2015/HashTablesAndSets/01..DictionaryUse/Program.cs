namespace _01.DictionaryUse
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new double[] { 2.3, 3.1, 4.2, 4.2, 5, 6.0, 3.1, 4.2 };
            var dictionary = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary[number] = 0;
                }

                dictionary[number] += 1;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
