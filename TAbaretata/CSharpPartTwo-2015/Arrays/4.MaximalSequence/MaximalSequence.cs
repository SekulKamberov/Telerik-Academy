using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds the maximal sequence of equal elements in an array.

class MaximalSequence
{
    static void Main()
    {
        Console.Write("Enter the size of the array: ");
        int n = int.Parse(Console.ReadLine());
        int bestSeq = 1;
        int currSeq = 1;
        int bestNum = 0;
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("arr[{0}] = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n - 1; i++)
        {
            if (arr[i] == arr[i + 1])
            {
                currSeq++;
            }
            else
            {
                currSeq = 1;
            }
            if (currSeq >= bestSeq)
            {
                bestSeq = currSeq;
                bestNum = arr[i];
            }
        }
        for (int i = 0; i < bestSeq; i++)
        {
            Console.Write("{0} ", bestNum);
        }
        Console.WriteLine();
    }
}
