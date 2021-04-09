using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds the most frequent number in an array.

class FrequantNumber
{
    static void Main()
    {
        Console.WriteLine("Calculating most frequant number in array.");
        Console.Write("Enter size of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
        int count = 1;
        int maxCount = 1;
        int countedNum = 0;
        Array.Sort(arr);
        for (int i = 0; i < n - 1; i++)
        {
            if (arr[i] == arr[i + 1])
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > maxCount)
            {
                maxCount = count;
                countedNum = arr[i];
            }
        }
        if (maxCount > 1)
        {
            Console.WriteLine("Most frequant number is {0} and it is counted {1} times.", countedNum, maxCount);
        }
        else
        {
            Console.WriteLine("No frequancy!");
        }

    }
}
