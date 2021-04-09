using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds in given array of integers a sequence of given sum S (if present).

class FindSequanceByGivenSum
{
    static void Main()
    {
        Console.WriteLine("Finding sequance in array by given sum.");
        Console.Write("Enter size of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.Write("Enter Sum: ");
        int sum = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
        int currSum = 0;
        int startIndex = 0;

        for (int i = 0; i < n - 1; i++)
        {
            currSum += arr[i];
            startIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                currSum += arr[j];
                if (currSum == sum)
                {
                    for (int k = startIndex; k <= j; k++)
                    {
                        Console.WriteLine("{0} ", arr[k]);
                    }
                    break;
                }
            }
            currSum = 0;
        }
    }
}
