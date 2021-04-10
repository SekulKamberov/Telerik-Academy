namespace _03.ReadIntegersAndSort
{
    using System;
    using System.Collections.Generic;

    class ReadIntegersAndSort
    {
        // 03. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them 
        // in an increasing order.

        public static List<int> ReadIntegersFromConsoleAndSort()
        {
            List<int> numbers = new List<int>();
            int numberInserted;
            string input;
            bool isInteger;
            while (true)
            {
                Console.WriteLine("Insert integer number: ");
                input = Console.ReadLine();
                if (input == string.Empty)
                {
                    break;
                }
                isInteger = int.TryParse(input, out numberInserted);
                if (!isInteger)
                {
                    Console.WriteLine("Try again.");
                }
                numbers.Add(numberInserted);
            }
            numbers.Sort();
            return numbers;
        }
        static void Main(string[] args)
        {
            List<int> numbers = ReadIntegersFromConsoleAndSort();
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
