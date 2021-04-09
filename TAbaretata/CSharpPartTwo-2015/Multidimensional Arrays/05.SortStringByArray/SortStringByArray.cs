using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//You are given an array of strings. Write a method that sorts the array by the length of
//its elements (the number of characters composing them).

class SortStringByArray
{
    static void Main()
    {
        Console.Write("Enter length of the array: ");
        int n = int.Parse(Console.ReadLine());
        string[] arr = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = Console.ReadLine();
        }
        Array.Sort(arr, (x, y) => x.Length.CompareTo(y.Length));
        foreach (string str in arr)
        {
            Console.WriteLine(str);
        }
        Console.WriteLine();
    }
}
