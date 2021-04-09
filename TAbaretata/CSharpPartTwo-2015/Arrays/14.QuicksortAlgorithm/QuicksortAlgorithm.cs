using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that sorts an array of strings using the Quick sort algorithm.

class QuicksortAlgorithm
{
    static List<int> QuickSort(List<int> array)
    {
        if (array.Count <= 1)
        {
            return array;
        }
        int pivot = array[array.Count / 2];
        List<int> less = new List<int>();
        List<int> greater = new List<int>();

        for (int i = 0; i < array.Count; i++)
        {
            if (i != (array.Count / 2))
            {
                if (array[i] <= pivot)
                {
                    less.Add(array[i]);
                }
                else
                {
                    greater.Add(array[i]);
                }
            }
        }
        return ConcatenateArr(QuickSort(less), QuickSort(greater), pivot);
    }

    static List<int> ConcatenateArr(List<int> less, List<int> greater, int pivot)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < less.Count; i++)
        {
            result.Add(less[i]);
        }

        result.Add(pivot);

        for (int i = 0; i < greater.Count; i++)
        {
            result.Add(greater[i]);
        }
        return result;
    }

    static void Print(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        List<int> arr = new List<int>() { 2, 1, 6, 8, 5, 3, 9 };
        List<int> sortedArr = QuickSort(arr);
        Print(sortedArr);
    }
}
