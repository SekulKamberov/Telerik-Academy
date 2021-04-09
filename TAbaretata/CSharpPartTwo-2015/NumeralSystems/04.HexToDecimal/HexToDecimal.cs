using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to convert hexadecimal numbers to their decimal representation.

class HexToDecimal
{
    static string hexNum;

    static int Pow(int sqr)
    {
        return (1 << (sqr * 4));
    }

    static void ConvertHexToDec()
    {
        int result = 0;
        int count = hexNum.Length - 1;
        int digit = 0;

        for (int i = 0; i < hexNum.Length; i++)
        {
            switch (hexNum[i])
            {
                case 'A':
                case 'a': digit = 10; break;
                case 'B':
                case 'b': digit = 11; break;
                case 'C':
                case 'c': digit = 12; break;
                case 'D':
                case 'd': digit = 13; break;
                case 'E':
                case 'e': digit = 14; break;
                case 'F':
                case 'f': digit = 15; break;
                default: digit = int.Parse(Convert.ToString(hexNum[i])); break;
            }
            result += digit * Pow(count);
            count--;
        }
        //Print
        Console.WriteLine(result);
    }

    static void Main()
    {
        Console.Write("Convert hex to decimal: ");
        hexNum = Console.ReadLine();
        ConvertHexToDec();
    }
}