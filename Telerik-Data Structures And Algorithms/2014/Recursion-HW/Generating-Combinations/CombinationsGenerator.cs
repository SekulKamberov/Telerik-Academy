using System;

/*
 * 02. Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. Example:
	n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
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
        int n = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        int[] vector = new int[k];

        Gen01(k - 1, vector, n);
    }
}
