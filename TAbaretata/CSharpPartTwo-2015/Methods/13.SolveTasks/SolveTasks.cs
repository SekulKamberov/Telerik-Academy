using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Write a program that can solve these tasks:
        Reverses the digits of a number
        Calculates the average of a sequence of integers
        Solves a linear equation a * x + b = 0
    Create appropriate methods.
    Provide a simple text-based menu for the user to choose which task to solve.
    Validate the input data:
        The decimal number should be non-negative
        The sequence should not be empty
        a should not be equal to 0 */

class SolveTasks
{
    static int ReverseNumber(int number, int remain = 0)
    {
        int reversed = 0;
        while (number > 0)
        {
            remain = number % 10;
            reversed = (reversed * 10) + remain;
            number = number / 10;
        }
        return reversed;
    }

    static decimal SolveEquation(decimal a, decimal b)
    {
        decimal result = -b / a;
        return result;
    }

    static decimal CalculateAverage(decimal[] sequance)
    {
        decimal sum = 0;
        foreach (decimal item in sequance)
        {
            sum += item;
        }
        return sum / sequance.Length;
    }

    static void ExitProgram()
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }

    static void PrintInput()
    {
        Console.WriteLine(new string('-', 15));
        Console.WriteLine("Choose one of the 3 options.");
        Console.WriteLine("1. Reverse the digits of a non negative number.    ");
        Console.WriteLine("2. Calculate the average of a sequence of integers.");
        Console.WriteLine("3. Solve a linear equation a * x + b = 0 .         ");
        Console.WriteLine("Please enter a number [1 to 3] or END to exit: ");
        Console.WriteLine(new string('-', 15));
    }

    static void ReadInput()
    {
        string task = Console.ReadLine();

        if (task == "END")
        {
            ExitProgram();
        }
        else if (task == "1")
        {
            Console.Write("Please enter a non-negative number: ");
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("Your input is invalid!");
            }
            else
            {
                int reversed = ReverseNumber(number);
                Console.WriteLine("Reversed number is: {0}", reversed);
            }
        }
        else if (task == "2")
        {
            Console.Write("Enter the length of the sequance: ");
            int seqLength = int.Parse(Console.ReadLine());
            if (seqLength < 0)
            {
                Console.WriteLine("Wrong input!");
            }
            else
            {
                decimal[] sequance = new decimal[seqLength];
                Console.Write("Enter elements of the sequance:");
                for (int i = 0; i < seqLength; i++)
                {
                    sequance[i] = int.Parse(Console.ReadLine());
                }
                decimal average = CalculateAverage(sequance);
                Console.WriteLine("The average result of this sequance is: {0}", average);
            }
        }
        else if (task == "3")
        {
            Console.WriteLine("Solving equation \'a*x + b\' : ");
            Console.Write("Enter \'a\': ");
            decimal a = int.Parse(Console.ReadLine());
            Console.Write("Enter \'b\': ");
            decimal b = int.Parse(Console.ReadLine());
            if (a == 0 && b != 0)
            {
                Console.WriteLine("Wrong input! \'a\' should not be 0!");
            }
            else if (a == 0 && b == 0)
            {
                Console.WriteLine("Every \'x\' is solution to the problem!");
            }
            else
            {
                decimal result = SolveEquation(a, b);
                Console.WriteLine("The root of \'x\' = {0}", result);
            }
        }
        else
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static void Main()
    {
        while (true)
        {
            PrintInput();
            ReadInput();
        }
    }
}
