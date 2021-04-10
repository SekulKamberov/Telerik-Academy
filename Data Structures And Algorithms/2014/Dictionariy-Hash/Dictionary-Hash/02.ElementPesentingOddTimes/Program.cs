using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ElementPesentingOddTimes
{
    class Program
    {
        // 02. Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
        // Example: {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}

        static void Main(string[] args)
        {
            string [] elements = new string [] {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            IDictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var element in elements)
            {
                string key = element;
                if (!(dictionary.ContainsKey(key)))
                {
                    dictionary[key] = 0;
                }
                dictionary[key] += 1;
            }

            Console.WriteLine("---Dictionary---");
            foreach (var pair in dictionary)
            {
                if(pair.Value % 2 != 0)
                {
                    Console.WriteLine("Odd: " + pair.Key);
                }
                else
                {
                    Console.WriteLine("Even: " + pair.Key);
                }
            }

            // HashSet example

            HashSet<string> oddStringsCounted = new HashSet<string>();
            foreach (var word in elements)
            {
                if(oddStringsCounted.Contains(word))
                {
                    oddStringsCounted.Remove(word);
                }
                else
                {
                    oddStringsCounted.Add(word);
                }
            }

            Console.WriteLine("---HashSet Odd---");
            foreach (var oddWord in oddStringsCounted)
            {
                Console.WriteLine(oddWord);
            }
            Console.WriteLine("----HashSet Even----");
            HashSet<string> even = new HashSet<string>();
            foreach (var word in elements)
            {
                if (!oddStringsCounted.Contains(word))
                {
                    even.Add(word);
                }
            }
            foreach (var word in even)
            {
                Console.WriteLine(word);
            }
         }
    }
}
