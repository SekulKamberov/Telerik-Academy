using System;

//Write a program that reads a year from the console and checks whether it is a leap one.Use System.DateTime.

class LeapYear
{
    static void Main()
    {
        try
        {
            Console.Write("Enter year to check if it is leap: ");
            int inputYear = int.Parse(Console.ReadLine());
            Console.WriteLine("This year is leap? => {0}", DateTime.IsLeapYear(inputYear));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
