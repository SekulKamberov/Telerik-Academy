namespace _07.NumberOccurances
{
    using System;
    using System.Collections.Generic;

    public class NumberOccurances
    {
        // 07. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
        //  Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
        //  2  2 times
        //  3  4 times
        //  4  3 times

        public static void FindNumberOccurences(int [] numbers)
        {
            Dictionary<String, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                string currentNumber = numbers[i].ToString();
                if (!dictionary.ContainsKey(currentNumber))
                {
                    dictionary[currentNumber] = 0;
                }
                dictionary[currentNumber] += 1;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} > {1} times", item.Key, item.Value);
            }
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[] { 100, 200, 300, 1, 2, 6, 3, 6, 3, 3, 7, 7, 7, 8, 8, 7, 7, 7, 43, 877, 544, 6, 4, 4, 7, 6, 8, 2, 4, 8, 4, 8, 6, 6, 5, 5, 5, 5, 8, 8, 8, 5, 1000, 878, 100};
            FindNumberOccurences(numbers);
        }
    }
}
