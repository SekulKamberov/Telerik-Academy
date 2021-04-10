using System;

/*
 *  04. Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. Example:
	n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},					{2, 3, 1}, {3, 1, 2},{3, 2, 1}
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
        for (int j = 0; j < vector.Length; j++)
        {
            for (int i = j + 1; i < vector.Length; i++)
            {
                if (vector[j] == vector[i])
                {
                    return;
                }
            }
        }

        foreach (int i in vector)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        int[] vector = new int[n];
        

        Gen01(n - 1, vector, n);
    }
}
