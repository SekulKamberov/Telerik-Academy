using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CountDoubleValues
{
    class Program
    {
        // 01. Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
        // Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
        // -2.5  2 times
        // 3  4 times
        // 4  3 times
 
        static void Main(string[] args)
        {
            IDictionary<double, int> dictionary = new Dictionary<double, int>();
            double[] numbers = new double[]{ 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            for (int i = 0; i < numbers.Length; i++)
            {
                var key = numbers[i];
                if (!(dictionary.ContainsKey(key)))
                {
                    dictionary[key] = 0;
                }
                dictionary[key] += 1;
            }
            foreach (var pair in dictionary)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value + " times");
            }
        }
    }
}
