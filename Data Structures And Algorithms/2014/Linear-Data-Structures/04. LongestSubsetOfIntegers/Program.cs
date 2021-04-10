namespace _04.LongestSubsetOfIntegers
{
    using System;
    using System.Collections.Generic;

    public class LongestSubset
    {
        // 04. Write a method that finds the longest subsequence of equal numbers in given List<int> 
        // and returns the result as new List<int>. Write a program to test whether the method works correctly.
        public static List<int> FindLongestSubsetOfNumbers(List<int> numbers)
        {
            if(numbers.Count == 0)
            {
                return null;
            }
            List<int> longestSubset = new List<int>();
            int count = 1;
            int currentNumber = numbers[0];
            
            int maxSubsetCount = 1;
            int numberInMaxSubsetCount = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if(currentNumber == numbers[i])
                {
                    count++;
                }
                else
                {
                    if(maxSubsetCount < count)
                    {
                        maxSubsetCount = count;
                        numberInMaxSubsetCount = numbers[i - 1];
                    }

                    currentNumber = numbers[i];
                    count = 1;
                }
            }

            for (int i = 0; i < maxSubsetCount; i++)
            {
                longestSubset.Add(numberInMaxSubsetCount);
            }
            return longestSubset;
        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {1, 2, 2, 6, 6, 6, 6, 6, 6, 4, 4, 4, 4, 3, 3, 3, 5, 5, 5, 5, 5 };
            List<int> longestSubset = FindLongestSubsetOfNumbers(numbers);
            string longestSubsetToString = string.Join(", ", longestSubset);
            Console.WriteLine(longestSubsetToString);

            //test
            string numbersToString = string.Join(", ", numbers);
            if (numbersToString.IndexOf(longestSubsetToString) >= 0)
            {
                Console.WriteLine("Test passes.");
            }
            else
            {
                Console.WriteLine("Test dont pass.");
            }


        }
    }
}
