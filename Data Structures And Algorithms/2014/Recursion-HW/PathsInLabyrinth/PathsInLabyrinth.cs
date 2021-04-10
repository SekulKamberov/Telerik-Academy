using System;

/*
 * 03. Modify the previous program to skip duplicates:
 * n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
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
        if (vector.Length == 1 || vector[0] == vector[1])
        {
            return;
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
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        int[] vector = new int[k];

        Gen01(k - 1, vector, n);
    }
}
