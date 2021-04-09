using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].

class PermutationsOfSet
{
    static int n = int.Parse(Console.ReadLine());

    static void Permutations(int[] array,bool[] used, int index)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    array[index] = i;
                    used[i] = true;
                    Permutations(array, used, index + 1);
                    used[i] = false;
                }
                
            }
        }
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write((array[i] + 1) + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] array = new int[n];
        bool[] used = new bool[n];
        Permutations(array, used, 0);
    }
}