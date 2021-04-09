using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that compares two char arrays lexicographically (letter by letter).

class CompareCharArrays
{
    static void Main(string[] args)
    {
        Console.WriteLine("Comparing two char arrays..");
        Console.Write("Enter size of the first array: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter size of the second array: ");
        int m = int.Parse(Console.ReadLine());
        char[] arr1 = new char[n];
        char[] arr2 = new char[m];
        bool isEqual = true;
        if (n == m)
        {
            Console.WriteLine("Enter {0} chars for the first array: ", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("First Array[{0}] = ", i);
                arr1[i] = char.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter {0} chars for the second array: ", n);
            for (int i = 0; i < m; i++)
            {
                Console.Write("Second Array[{0}] = ", i);
                arr2[i] = char.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    isEqual = false;
                }
            }
        }
        else
        {
            isEqual = false;
        }
        Console.WriteLine("Equal = {0} ", isEqual);
    }
}
