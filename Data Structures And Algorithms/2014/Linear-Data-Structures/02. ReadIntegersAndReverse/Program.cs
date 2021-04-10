namespace _02.ReadIntegersAndReverse
{
    using System;
    using System.Collections.Generic;
    public class ReadIntegersAndReverse
    {
        // 02. Write a program that reads N integers from the console and reverses them using a stack. 
        // Use the Stack<int> class.
        public static int ReadIntegerFromConsole(int numberMinimum = int.MinValue)
        {
            int numberInserted;
            string input;
            bool isInteger;
            while (true)
            {
                input = Console.ReadLine();
                isInteger = int.TryParse(input, out numberInserted);
                if (isInteger && numberInserted >= numberMinimum)
                {
                    break;
                }
                Console.WriteLine("Try again.");
            }
            return numberInserted;
        }

        static void Main(string[] args)
        {
            int N = ReadIntegerFromConsole(1);

            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < N; i++)
            {
                int number = ReadIntegerFromConsole();
                numbers.Push(number);
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
