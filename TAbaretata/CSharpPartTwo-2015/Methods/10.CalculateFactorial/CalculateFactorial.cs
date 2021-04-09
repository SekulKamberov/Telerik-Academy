using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to calculate n! for each n in the range [1..100].

class CalculateFactorial
{
    static void PrintNumber(byte[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }

    static byte[] Add(byte[] a, byte[] b)
    {
        if (a.Length > b.Length)
        {
            return Add(b, a);
        }
        byte[] result = new byte[b.Length + 1];

        int carry = 0;
        int i = 0;
        for (; i < a.Length; i++)
        {
            result[i] = (byte)(a[i] + b[i] + carry);
            carry = result[i] / 10;
            result[i] %= 10;
        }
        for (; i < b.Length && carry != 0; i++)
        {
            result[i] = (byte)(b[i] + carry);
            carry = result[i] / 10;
            result[i] %= 10;
        }
        for (; i < b.Length; i++)
        {
            result[i] = b[i];
        }
        if (carry != 0)
        {
            result[i] = 1;
        }
        else
        {
            Array.Resize(ref result, result.Length - 1);
        }
        return result;
    }

    static byte[] Multiply(byte[] x, int y)
    {
        byte[] result = { 0 };
        for (int i = 0; i < y; i++)
        {
            result = Add(result, x);
        }
        return result;
    }

    static void Main()
    {
        byte[] factorial = { 1 };
        for (int i = 1; i <= 100; i++)
        {
            PrintNumber(factorial = Multiply(factorial, i));
        }
    }
}
