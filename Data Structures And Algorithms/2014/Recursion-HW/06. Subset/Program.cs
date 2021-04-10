using System;

/*
 *  06. Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n 
 *  for given integer number n. Example:
	n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},					{2, 3, 1}, {3, 1, 2},{3, 2, 1}
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
        for (int j = 0; j < vector.Length; j++)
        {
            for (int i = j + 1; i < vector.Length; i++)
            {
                if (vector[j].Equals(vector[i]))
                {
                    return;
                }
            }
        }

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
            Console.WriteLine("Insert number[{0}]: ", i);
            vec[i] = Console.ReadLine();
        }

        Gen01(k - 1, vector, n, vec);
    }
}
