namespace _07.CountNumbersOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            CountNumberOccurences(numbers);
        }

        private static void CountNumberOccurences(List<int> numbers)
        {
            var length = 1001;
            int[] occurencess = new int[length];
            bool[] numbersContained = new bool[length];
            for (int i = 0; i < length; i++)
            {
                int currentNumber = numbers[i];
                numbersContained[currentNumber] = true;
                occurencess[currentNumber] += 1;
            }

            for (int i = 0; i < length; i++)
            {
                if (numbersContained[i])
                {
                    Console.WriteLine("{0} → {1} times", i, occurencess[i]);
                }
            }
        }
    }
}
