namespace _08.MajorAnt
{
    using System;
    using System.Collections.Generic;

    // 08. * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
    // Write a program to find the majorant of given array (if exists). 
    // Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  3

    // I DONT UNDERSTAND WHAT TO DO IN THIS ONE!

    public class FindMajorAnt
    {
        public static void FindMajorAntIfExist(int[] numbers)
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

            int length = (numbers.Length / 2) + 1;
            foreach (var item in dictionary)
            {
                if (item.Value >= length)
                {
                    Console.WriteLine("Majorant  > {0}", item.Key);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 7, 7, 8, 8, 8, 8, 8, 2, 8, 3, 8, 4, 8};
            FindMajorAntIfExist(numbers);
        }
    }
}
