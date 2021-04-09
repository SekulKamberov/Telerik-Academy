using System;

//Write a method that returns the last digit of given integer as an English word.

class EnglishDigit
{
    static string[] lastDigit = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    static int GetLastDigit(int n)
    {
        return n % 10;
    }

    static string PrintLastDigit(int n)
    {
        return lastDigit[n];
    }

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(PrintLastDigit(GetLastDigit(number)));
    }
}
