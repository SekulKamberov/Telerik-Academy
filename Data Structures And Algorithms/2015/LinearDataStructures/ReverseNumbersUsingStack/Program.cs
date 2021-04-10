namespace ReverseNumbersUsingStack
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int capacity;
            while (true)
            {
                Console.WriteLine("Capacity: ");
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out capacity);
                if (isNumber && capacity > 0)
                {
                    break;
                }
            }

            Stack<int> numbers = new Stack<int>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                while (true)
                {
                    Console.WriteLine("Number: ");
                    string input = Console.ReadLine();
                    int number;
                    bool isNumber = int.TryParse(input, out number);
                    if (isNumber)
                    {
                        numbers.Push(number);
                        break;
                    }

                    Console.WriteLine("Incorect number!");
                }
            }

            for (int i = 0; i < capacity; i++)
            {
                Console.Write(numbers.Pop() + ", ");
            }
        }
    }
}
