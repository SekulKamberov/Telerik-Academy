using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to convert decimal numbers to their binary representation.

class DecimalToBinary
{
    static List<int> inBinary = new List<int>();
    static int number;

    static void ConvertToBinary()
    {
        while (number > 0)
        {
            inBinary.Add(number % 2);
            number = number / 2;
        }
        inBinary.Reverse();

        //Printing
        for (int i = 0; i < inBinary.Count; i++)
        {
            Console.Write("{0} ", inBinary[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Enter decimal number to convert in binary: ");
        number = int.Parse(Console.ReadLine());
        ConvertToBinary();
    }
}
