namespace _04.LongestSubsequenceEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 2, 3, 3, 3, 5, 5, 5, 5, 5, 4, 4, 4, 4, 1 };
            Console.WriteLine(string.Join(", ", FindLogestSubsequenceOfEqualNumbers(numbers)));
            Console.WriteLine("Works correctly: " + string.Join(", ", FindLogestSubsequenceOfEqualNumbers(numbers)).Equals("5, 5, 5, 5, 5"));
        }

        public static List<int> FindLogestSubsequenceOfEqualNumbers(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                throw new ArgumentException("List is empty.");
            }

            int maxCounter = 1;
            int number = numbers[0];
            int tempCounter = 1;
            int tempNumber = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber == tempNumber)
                {
                    tempCounter++;
                    if (maxCounter < tempCounter)
                    {
                        maxCounter = tempCounter;
                        number = tempNumber;
                    }
                }
                else
                {
                    tempNumber = currentNumber;
                    tempCounter = 1;
                }
            }

            var longestSubsequence = new List<int>(maxCounter);
            for (int i = 0; i < maxCounter; i++)
            {
                longestSubsequence.Add(number);
            }

            return longestSubsequence;
        }
    }
}
