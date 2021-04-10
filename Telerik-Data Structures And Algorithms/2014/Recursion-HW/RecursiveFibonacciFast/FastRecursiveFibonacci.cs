using System;

class FastRecursiveFibonacci
{
    const int MAX_FIBОNACCI_SEQUENCE_MEMBER = 101;
    static decimal[] fib = new decimal[MAX_FIBОNACCI_SEQUENCE_MEMBER];

    static decimal Fibonacci(int n)
    {
        if (fib[n] == 0)
        {
            // The value of fib[n] is still not calculated -> calculate it now
            if ((n == 1) || (n == 2))
            {
                fib[n] = 1;
            }
            else
            {
                fib[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
        return fib[n];
    }

    static void Main()
    {
        int num = 100;
        decimal fib = Fibonacci(num);
        Console.WriteLine("Fib({0}) = {1}", num, fib);
    }
}
