namespace _06.RemoveNumbersOccuredOddTimes
{
    using System;
    using System.Collections.Generic;

    public class RemoveNumbersOccuredOddTimes
    {
        // 06. Write a program that removes from given sequence all numbers that occur odd number of times. Example:
        // {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}
        public static void RemoveNumbersOccuredOddTimesInList(List<int> numbers)
        {
            Dictionary<String, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < numbers.Count; i++)
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
                if (item.Value % 2 != 0)
                {
                    int numberToRemove = Convert.ToInt32(item.Key);
                    int count = item.Value;
                    RemoveNumbersFromList(numbers, numberToRemove, count);
                }
            }
        }

        private static void RemoveNumbersFromList(List<int> numbers, int number, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Remove(number);
            }
        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 6, 2, 2, 7, 7, 7, 7, 6, 4, 4, 4, 6, 4, 5, 5, 7, 7, 5, 6, 5, 5, 3, 7, 6, 3, 6, 3};
            Console.WriteLine(string.Join(", ", numbers));

            RemoveNumbersOccuredOddTimesInList(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
