using System;
/*
    Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
        If an invalid number or non-number text is entered, the method should throw an exception.
    Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/

class EnterNumber
{
    static void RunTenTimes(int start, int end)
    {
        for (int i = 0; i < 10; i++)
        {
            ReadNumber(start, end);
        }
    }

    static void ReadNumber(int start, int end)
    {
        string input = Console.ReadLine();
        try
        {
            int number = int.Parse(input);
            if (number > start && number < end)
            {
                Console.WriteLine("{0} is in range.", number);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Wrong input! \r\n{0}", ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Wrong input! \r\n{0}", ex.Message);
        }
    }

    static void Main()
    {
        Console.WriteLine("10 runs: ");
        RunTenTimes(0, 100);
    }
}
