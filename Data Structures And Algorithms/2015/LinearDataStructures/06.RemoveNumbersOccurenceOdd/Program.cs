namespace _06.RemoveNumbersOccurenceOdd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            RemoveNumbersThatOccureOddTimes(ref numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void RemoveNumbersThatOccureOddTimes(ref List<int> numbers)
        {
            List<int> oddOccuredNumbers = new List<int>();
            List<int> evenOccuredNumbers = new List<int>(numbers.Count);
            int length = numbers.Count;
            for (int i = 0; i < length; i++)
            {
                int currentNumber = numbers[i];
                int occuredTimes = numbers.Where(n => n == currentNumber).Count();
                bool isOddTimes = occuredTimes % 2 != 0;
                bool isInListOfOddNumbers = oddOccuredNumbers.Contains(currentNumber);
                if (isOddTimes && 
                    isInListOfOddNumbers == false)
                {
                    oddOccuredNumbers.Add(currentNumber);
                }

                if (isOddTimes == false)
                {
                    evenOccuredNumbers.Add(currentNumber);
                }
            }

            numbers = evenOccuredNumbers;
        }
    }
}
