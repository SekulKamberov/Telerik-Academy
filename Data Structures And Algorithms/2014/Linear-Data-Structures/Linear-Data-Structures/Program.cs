namespace Linear_Data_Structures
{
    using System;
    using System.Collections.Generic;
    class SequenceOfPositiveIntegerNumbers
    {
        // 01. Write a program that reads from the console a sequence of positive integer numbers. 
        // The sequence ends when empty line is entered. 
        // Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int parsedInput;
            bool isInteger;
            while (true)
            {
                Console.Write("Insert number: ");
                string input = Console.ReadLine();
                if (input == string.Empty)
                {
                    break;
                }
                else
                {
                    isInteger = int.TryParse(input, out parsedInput);
                    if (isInteger)
                    {
                        numbers.Add(parsedInput);
                    }
                    else
                    {
                        Console.WriteLine("Not integer. Try again.");
                    }
                }

            }

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine("SUM = " + sum);
            Console.WriteLine("AVG = " + (double)sum/numbers.Count);
        }
    }
}
