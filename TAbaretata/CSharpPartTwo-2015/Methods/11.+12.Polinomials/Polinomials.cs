using System;

/*Problem 11: Write a method that adds two polynomials.Represent them as arrays of their coefficients.
 Problem 12: Extend the previous program to support also subtraction and multiplication of polynomials. */

class Polinomials
{
    static void PrintPolinomial(int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(arr[i] + "*x^" + i + (i == 0 ? "\n" : " + "));
        }
    }

    static int[] Add(int[] a, int[] b)
    {
        if (a.Length > b.Length)
        {
            return Add(b, a);
        }
        PrintPolinomial(a);
        PrintPolinomial(b);
        int[] result = new int[b.Length];

        int i = 0;
        for (; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
        for (; i < b.Length; i++)
        {
            result[i] = b[i];
        }
        return result;
    }

    static int[] Subtract(int[] a, int[] b, bool reversed = false)
    {
        if (a.Length > b.Length)
        {
            return Subtract(b, a, reversed = true);
        }
        PrintPolinomial(a);
        PrintPolinomial(b);
        int[] result = new int[b.Length];
        int i = 0;
        for (; i < a.Length; i++)
        {
            result[i] = (reversed ? b[i] - a[i] : a[i] - b[i]);
        }
        for (; i < b.Length; i++)
        {
            result[i] = (!reversed ? b[i] : -b[i]);
        }
        PrintPolinomial(result);
        return result;
    }

    static int[] Multiply(int[] a, int[] b)
    {
        PrintPolinomial(a);
        PrintPolinomial(b);
        int[] result = new int[a.Length + b.Length - 1];
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                result[i + j] = a[i] * b[j];
            }
        }
        PrintPolinomial(result);
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Calculating two polinomials:");
        PrintPolinomial(Add(new int[] { 3, 4, 1 }, new int[] { 5, 1, 2, 6 }));
        Console.WriteLine();
        Console.WriteLine("Multiplying two polinomials:");
        Multiply(new int[] { 3, 4, 1 }, new int[] { 5, 1, 2, 6 });
        Console.WriteLine();
        Console.WriteLine("Subtracting two polinomials:");
        Subtract(new int[] { 3, 4, 1 }, new int[] { 5, 1, 2, 6 });
        Console.WriteLine();
    }
}
