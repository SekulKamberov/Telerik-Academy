using System;

//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

class BinaryRepresentation
{
    static string inBinary(ushort s)
    {
        string bin = String.Empty;
        for (int i = 0; i < 16; i++)
        {
            bin = (s >> i & 1) + bin;
        }
        return bin;
    }

    static void Main()
    {
        //Catching exceptions if user's input is wrong
        try
        {
            ushort number = ushort.Parse(Console.ReadLine());
            Console.WriteLine(inBinary(number));
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
