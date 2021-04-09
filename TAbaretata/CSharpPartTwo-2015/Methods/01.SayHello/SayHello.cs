using System;

//Write a method that asks the user for his name and prints “Hello, <name>”
//Write a program to test this method.


class SayHello
{
    static void PrintName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}", name);
    }
    static void Main()
    {
        PrintName();
    }
}
