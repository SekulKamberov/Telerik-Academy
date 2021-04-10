using System;
using System.Collections.Generic;

namespace Combinatorics
{
    /*
     Problem 2 : Collered Rabbits
     */
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Asked rabbits: ");
            int count = int.Parse(Console.ReadLine());
            int[] replies = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write("Rabbit {0} reply: " , i + 1);
                replies[i] = int.Parse(Console.ReadLine());
            }
            int answer = getMinimum(replies);
            Console.WriteLine(answer);
        }

        private static int getMinimum(int[] replies)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < replies.Length; i++)
            {
                if(!(dict.ContainsKey(replies[i])))
                {
                    dict.Add(replies[i], 0);
                }
                dict[replies[i]] += 1;
            }

            var rabits = 0;
            foreach (var answer in dict)
            {
                var key = answer.Key;
                var value = answer.Value;

                var rabbitsWithSameCollor = key + 1;

                var rabbitsOfSameCollor = value / rabbitsWithSameCollor;

                rabits += rabbitsOfSameCollor * rabbitsWithSameCollor;

                var missingRabbits = value % rabbitsWithSameCollor;

                if(missingRabbits != 0)
                {
                    rabits += rabbitsWithSameCollor;
                }
            }

            return rabits;

            //int[] cache = new int[1000002];
            //for (int i = 0; i < replies.Length; i++)
            //{
            //    cache[replies[i] + 1]++;
            //}
            //int minCount = 0;
            //for (int i = 0; i < cache.Length; i++)
            //{
            //    if (cache[i] == 0) continue;
            //    if (cache[i] <= i) minCount += i;
            //    else minCount += (int)Math.Ceiling((double)cache[i] / i) * i;
            //}
            //return minCount;
        }
    }
}
