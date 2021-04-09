using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Problem 14: Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
Use variable number of arguments.
    Problem 15: Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
Use generic method (read in Internet about generic methods in C#).
*/

class CalculateMinMaxSumAvgProduct
{
    static T Min<T>(params T[] sequance)
    {
        if (sequance.Length > 0)
        {
            if (sequance.Length == 2)
            {
                dynamic x = sequance[0];
                dynamic y = sequance[1];
                return x < y ? x : y;
            }
            else
            {
                dynamic result = sequance[0];
                for (int i = 1; i < sequance.Length; ++i)
                {
                    result = Min(result, sequance[i]);
                }
                return result;
            }
        }
        else
        {
            return default(T);
        }
    }

    static T Max<T>(params T[] sequance)
    {
        if (sequance.Length > 0)
        {
            if (sequance.Length == 2)
            {
                dynamic x = sequance[0];
                dynamic y = sequance[1];
                return x > y ? x : y;
            }
            else
            {
                dynamic result = sequance[0];
                for (int i = 1; i < sequance.Length; ++i)
                {
                    result = Max<T>(result, sequance[i]);
                }
                return result;
            }
        }
        else
        {
            return default(T);
        }
    }

    static T Average<T>(params T[] sequance)
    {
        if (sequance.Length > 0)
        {
            dynamic counter = 0;
            dynamic sum = 0;
            dynamic sumAvg = 0;
            foreach (var item in sequance)
            {
                sum += item;
                counter++;
            }
            sumAvg = sum / counter;
            return sumAvg;
        }
        else
        {
            return default(T);
        }
    }

    static T Sum<T>(params T[] sequance)
    {
        dynamic sum = 0;
        foreach (var item in sequance)
        {
            sum += item;
        }
        return sum;
    }

    static T Product<T>(params T[] sequance)
    {
        if (sequance.Length > 0)
        {
            dynamic sum = 1;
            foreach (var item in sequance)
            {
                sum *= item;
            }
            return sum;
        }
        else
        {
            return default(T);
        }
    }

    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.WriteLine("Min: {0}", Min(2, 5, 7));
        Console.WriteLine("Max: {0}", Max(2, 5, 7));
        Console.WriteLine("Average: {0}", Average(2.0, 5, 7));
        Console.WriteLine("Sum: {0}", Sum(2, 5, 7));
        Console.WriteLine("Product: {0}", Product(2, 5, 7));
    }
}