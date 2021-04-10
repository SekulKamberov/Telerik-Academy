namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;

    public class RemovingNegativeNumbers
    {
        // 05. Write a program that removes from given sequence all negative numbers.

        public static List<int> RemoveNegativeNumbers(List<int> numbers)
        {
            int length = numbers.Count;
            for (int i = 0; i < length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    length--;
                }
            }

            return numbers;
        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {1, 5, 7, -64, 23, -8, 832, -4};
            Console.WriteLine("All numbers: " + string.Join(", ", numbers));
            Console.WriteLine("Possitive numbers: " + string.Join(", ", RemoveNegativeNumbers(numbers)));
        }
    }
}
