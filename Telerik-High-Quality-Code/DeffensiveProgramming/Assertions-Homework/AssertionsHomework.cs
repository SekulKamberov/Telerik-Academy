using System;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        bool arrayIsNull = arr == null;
        Debug.Assert(!arrayIsNull, "Array is null!");
        bool arrayIsEmpty = arr.Length == 0;
        Debug.Assert(!arrayIsEmpty, "Array is empty!");
        bool arrayHasMoreThanOneElement = arr.Length == 1;
        Debug.Assert(!arrayHasMoreThanOneElement, "Array has 1 element only!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        bool arrayIsNull = arr == null;
        Debug.Assert(arrayIsNull == false, "Array is null!");
        bool arrayIsEmpty = arr.Length == 0;
        Debug.Assert(arrayIsEmpty == false, "Array is empty!");
        bool valueIsNull = value == null;
        Debug.Assert(valueIsNull == false, "Value is null!");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        // int[] a = null;
        // SelectionSort(a); // Test sorting null
        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        bool isStartIndexLessThanEndIndex = startIndex <= endIndex;
        Debug.Assert(isStartIndexLessThanEndIndex, "Incorrect start index!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }
    
    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        bool arrayIsNull = arr == null;
        Debug.Assert(arrayIsNull == false, "Array is null!");
        bool arrayIsEmpty = arr.Length == 0;
        Debug.Assert(arrayIsEmpty == false, "Array is empty!");
        bool valueIsNull = value == null;
        Debug.Assert(valueIsNull == false, "Value is null!");
        bool isStartIndexLessThanEndIndex = startIndex <= endIndex;
        Debug.Assert(isStartIndexLessThanEndIndex, "Incorrect start index!");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }
}
