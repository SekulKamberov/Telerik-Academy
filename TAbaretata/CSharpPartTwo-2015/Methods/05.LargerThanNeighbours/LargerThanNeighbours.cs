using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerThanNeighbors
{
    class Program
    {
        static bool biggerThanNeighbors;
        static int checkNumber;

        static bool CheckNeighbors(int[] arr, int i)
        {
            if (i == 0)
            {
                biggerThanNeighbors = arr[i] > arr[i + 1];

            }
            else if (i == arr.Length - 1)
            {
                biggerThanNeighbors = arr[i] > arr[i - 1];

            }
            else
            {
                biggerThanNeighbors = arr[i] > arr[i + 1] && arr[i] > arr[i - 1];
            }
            return biggerThanNeighbors;
        }

        static void Main()
        {
            int[] arr = { 2, 3, 1, 4, 7, 5, 10 };
            Console.Write("Enter index to check: ");
            checkNumber = int.Parse(Console.ReadLine());
            if (checkNumber < 0 || checkNumber >= arr.Length)
            {
                Console.WriteLine("Index out of range!");
            }
            else
            {
                Console.WriteLine("Bigger than its neighbours --> {0}", CheckNeighbors(arr, checkNumber));
            }
        }
    }
}
