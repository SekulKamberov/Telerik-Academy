using System;

//Write a program to convert binary numbers to their decimal representation.

class BinaryToDecimal
{
    static int number;

    static void ConvertToBinary()
    {
        double sum = 0;
        int strNumber = number.ToString().Length;
        for (int i = 0; i < strNumber; i++)
        {
            int lastDigit = number % 10;
            sum = sum + lastDigit * (Math.Pow(2, i));
            number = number / 10;
        }
        Console.WriteLine("The decimal representation of your number is: {0}", sum);
    }

    static void Main()
    {
        Console.Write("Enter binary number to convert: ");
        number = int.Parse(Console.ReadLine());
        ConvertToBinary();
    }
}
