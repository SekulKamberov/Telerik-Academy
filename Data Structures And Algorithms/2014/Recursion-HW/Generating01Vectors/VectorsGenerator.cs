using System;

/*
 * 01. Write a recursive program that simulates the execution of n nested loops from 1 to n. Examples:
                           1 1 1
                           1 1 2
                           1 1 3
         1 1               1 2 1
n=2  ->  1 2      n=3  ->  ...
         2 1               3 2 3
         2 2               3 3 1
                           3 3 2
                           3 3 3

 */

class VectorsGenerator
{
    static void Gen01(int index, int[] vector, int n)
    {
        if (index == -1)
        {
            Print(vector);
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                vector[index] = i;
                Gen01(index - 1, vector, n);
            }
        }
    }

    static void Print(int[] vector)
    {
        string vec = "";

        foreach (int i in vector)
        {
            vec = i + vec;
        }
        Console.WriteLine(vec);
    }

    static void Main()
    {
        Console.Write("n = ");
        int number = int.Parse(Console.ReadLine());
		
        int[] vector = new int[number];

        Gen01(number - 1, vector, number);
    }
}
