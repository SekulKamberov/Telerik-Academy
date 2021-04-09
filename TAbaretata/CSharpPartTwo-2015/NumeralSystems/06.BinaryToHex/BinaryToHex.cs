using System;
using System.Text;

//Write a program to convert binary numbers to hexadecimal numbers (directly).

class BinaryToHex
{
    static string BinToHex(string bin)
    {
        int strLength = bin.Length;
        StringBuilder binStr = new StringBuilder();

        for (int i = 0; i < strLength; i = i + 4)
        {
            switch (bin.Substring(i, 4))
            {
                case "1010": binStr.Append('A'); break;
                case "1011": binStr.Append('B'); break;
                case "1100": binStr.Append('C'); break;
                case "1101": binStr.Append('D'); break;
                case "1110": binStr.Append('E'); break;
                case "1111": binStr.Append('F'); break;
                case "0000": binStr.Append('0'); break;
                case "0001": binStr.Append('1'); break;
                case "0010": binStr.Append('2'); break;
                case "0011": binStr.Append('3'); break;
                case "0100": binStr.Append('4'); break;
                case "0101": binStr.Append('5'); break;
                case "0110": binStr.Append('6'); break;
                case "0111": binStr.Append('7'); break;
                case "1000": binStr.Append('8'); break;
                case "1001": binStr.Append('9'); break;
            }
        }
        return binStr.ToString();
    }

    static void Main()
    {
        Console.Write("Enter binary number to convert: ");
        string bin = Console.ReadLine();
        string toHex = BinToHex(bin.PadLeft(4,'0'));
        Console.WriteLine("Converted to hex: {0}", toHex);
    }
}
