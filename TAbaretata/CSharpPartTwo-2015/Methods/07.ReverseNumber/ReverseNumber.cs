using System;
using System.Threading;
using System.Globalization;

//Write a method that reverses the digits of given decimal number.

class ReverseNumber
{
    static string ReverseDigits(string number)
    {
        char[] charNumbers = number.ToCharArray();
        Array.Reverse(charNumbers);
        return new string(charNumbers);
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter decimal to reverse: ");
        string number = Console.ReadLine();
        Console.WriteLine("Reversed: {0}", ReverseDigits(number));
    }
}