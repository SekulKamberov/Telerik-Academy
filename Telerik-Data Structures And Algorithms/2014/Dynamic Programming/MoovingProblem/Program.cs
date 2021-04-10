using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoovingProblem
{
    class Program
    {
        private static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void calcNextCells(int[,] arr, int i, int j)
        {
            //rigth
            if (i < arr.GetLength(0) - 1)
            {
                bool notPassingCell = arr[i + 1, j] != -2;
                bool notExitCell = arr[i + 1, j] != -1;

                if (notPassingCell && notExitCell)
                {
                    if (i == 0 && j == 0)
                    {
                        arr[i + 1, j] = 1;
                    }
                    else if (arr[i + 1, j] < arr[i, j] + 1)
                    {
                        arr[i + 1, j] = arr[i, j] + 1;
                    }
                }
                else if (!notExitCell)
                {
                    Console.WriteLine("Possible road with steps: " + (arr[i, j] + 1));
                }
            }

            //down
            if (j < arr.GetLength(1) - 1)
            {
                bool downIsNotMinus2 = arr[i, j + 1] != -2;
                bool downIsNotExit = arr[i, j + 1] != -1;
                if (downIsNotMinus2 && downIsNotExit)
                {
                    if (i == 0 && j == 0)
                    {
                        arr[i, j + 1] = 1;
                    }
                    else if (arr[i, j + 1] < arr[i, j] + 1)
                    {
                        arr[i, j + 1] = arr[i, j] + 1;
                    }
                }
                else if (!downIsNotExit)
                {
                    Console.WriteLine("Possible road with steps: " + (arr[i, j] + 1));
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] arr = new int[5, 5];
            arr[4, 4] = -1;
            arr[1, 1] = -2;
            //arr[2, 2] = -2;
            //arr[0, 2] = -2;

            Print(arr);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == -1)
                    {
                        Console.WriteLine("EXIT");
                        break;
                    }

                    if(arr[i, j] == -2)
                    {
                        continue;
                    }

                    calcNextCells(arr, i, j);
                }
            }

            Print(arr);
        }
    }
}
