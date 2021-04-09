using System;
/*
    Write a program that reads an integer number and calculates and prints its square root.
        If the number is invalid or negative, print Invalid number.
        In all cases finally print Good bye.
    Use try-catch-finally block.
*/

class SquareRoot
{
    static void Main()
    {
        try
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Sqrt(input));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid number! {0}", ex.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }
    }
}
