using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.

class SieveOfEratosthenes
{
    static void Main(string[] args)
    {
        bool[] nums = new bool[10000000];
        for (int i = 2; i < Math.Sqrt(nums.Length); i++)
        {
            if (nums[i] == false)
            {
                for (int j = i * i; j < nums.Length; j = j + i)
                {
                    nums[j] = true;
                }
            }
        }
        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i] == false)
            {
                Console.WriteLine("{0} ", i);
            }
        }
        Console.WriteLine();
    }
}