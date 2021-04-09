using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is workings correctly.

class AppearanceCount
{
    static int[] arr = { 2, 4, 6, 3, 2, 3, 4, 1, 6, 7, 8, 5, 1, 2, 5, 3, 2, 1 };
    static int counter = 0;
    static int numCheck = 0;

    static void CountNumbers(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == numCheck)
            {
                counter++;
            }
        }
    }

    static void Main()
    {
        Console.Write("Which number to check: ");
        numCheck = int.Parse(Console.ReadLine());
        CountNumbers(arr);
        Console.WriteLine("Number {0} appear {1} times in the array.", numCheck, counter);
    }
}
