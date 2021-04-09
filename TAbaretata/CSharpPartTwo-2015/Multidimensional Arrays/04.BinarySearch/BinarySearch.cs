using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//Write a program, that reads from the console an array of N integers and an integer K,
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

class BinarySearch
{
    static void Main()
    {
        Console.Write("Enter length of the array: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter max value: ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int maxValue = 0;
        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        for (int i = 0; i < n; i++)
        {

            if (arr[i] < k)
            {
                maxValue = arr[i];
            }
        }
        Array.BinarySearch(arr, maxValue);
        if (arr[0] > k)
        {
            Console.WriteLine("No number is lesser than the given max value.");
        }
        else
        {
            Console.WriteLine("Max number lesser than the given max value is: {0}", maxValue);
        }
    }
}