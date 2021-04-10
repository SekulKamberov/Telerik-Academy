using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            char[] separator = new char[] {' '};
            string[] numbersString = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[len];
            for (int i = 0; i < len; i++)
            {
                numbers[i] = int.Parse(numbersString[i]);
            }
            int consecutiveNumbers = int.Parse(Console.ReadLine());


        }
    }
}
