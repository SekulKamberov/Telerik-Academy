using System;

/*
 * 05. Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
	Example: n=3, k=2, set = {hi, a, b} =>
	(hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
 */

class VectorsGenerator
{
    static void Gen01(int index, string[] vector, int n, string[] vec)
    {
        if (index == -1)
        {
            Print(vector);
        }
        else
        {
            foreach (string item in vec)
            {
                vector[index] = item;
                Gen01(index - 1, vector, n, vec);
            }

        }
    }

    static void Print(string[] vector)
    {
        foreach (string i in vector)
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

        string[] vector = new string[k];
        string[] vec = new string[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Insert substring[{0}]: ", i);
            vec[i] = Console.ReadLine();
        }

        Gen01(k - 1, vector, n, vec);
    }
}
