using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.

class MaxElementInGivenRange
{
    static void Swap(int i, int j)
    {
        int temp = i;
        i = j;
        j = temp;
    }

    static int MaxElement(int[] arr, int start, int length)
    {
        int maxElement = int.MinValue;
        int maxIndex = 0;
        maxElement = arr[start];
        for (int i = start; i <= length; i++)
        {
            if (arr[i] >= maxElement)
            {
                maxElement = arr[i];
                maxIndex = i;
            }
        }
        Swap(maxIndex, start);
        return maxElement;
    }

    static int[] SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
        return arr;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arr = { 2, 3, 7, 4, 10, 21, 14, 5, 8 };
        int startElement = 0;
        int portionLength = 3;

        //Max element from the unsorted array
        int maxElement = MaxElement(arr, startElement, portionLength);
        Console.WriteLine(maxElement);

        //Calling and printing the sorted array
        SelectionSort(arr);
        PrintArray(arr);
    }
}
