using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads two integer arrays from the console and compares them element by element.

class CompareArrays
{
    static void Main()
    {
        Console.WriteLine("Comparing two arrays..");
        Console.Write("Enter size of the first array: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter size of the second array: ");
        int m = int.Parse(Console.ReadLine());
        int[] firstArray = new int[n];
        int[] secondArray = new int[m];
        bool isEqual = true;
        if (n == m)
        {
            Console.WriteLine("Enter {0} numbers for the first array: ", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("First Array[{0}] = ", i);
                firstArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter {0} numbers for the second array: ", m);
            for (int i = 0; i < m; i++)
            {
                Console.Write("Second Array[{0}] = ", i);
                secondArray[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    isEqual = false;
                    break;
                }
            }

        }
        else
        {
            isEqual = false;
        }
        Console.WriteLine("Equal = {0}", isEqual);
    }
}
