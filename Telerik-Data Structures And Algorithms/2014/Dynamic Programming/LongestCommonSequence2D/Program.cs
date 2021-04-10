using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSequence2D
{
    class Program
    {

        static void Main(string[] args)
        {
            string X = "pesho";
            string Y = "gosho";

            FindLongestCommonSequence(X, Y);
        }

        private static void FindLongestCommonSequence(string X, string Y)
        {
            int rows = X.Length;
            int cols = Y.Length;
            int[,] lcsArray = new int[rows + 1, cols + 1];

            //for (int i = 0; i < lcsArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < lcsArray.GetLength(1); j++)
            //    {
            //        Console.Write(lcsArray[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            for (int i = 1; i < lcsArray.GetLength(0); i++)
            {
                for (int j = 1; j < lcsArray.GetLength(1); j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        lcsArray[i, j] = lcsArray[(i-1), (j-1)] + 1;
                    }
                    else
                    {
                        int MAX = lcsArray[i, j - 1];
                        if (MAX < lcsArray[i - 1, j])
                        {
                            MAX = lcsArray[i - 1, j];
                        }

                        lcsArray[i, j] = MAX;
                    }
                }
            }
            //for (int i = 0; i < lcsArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < lcsArray.GetLength(1); j++)
            //    {
            //        Console.Write(lcsArray[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine("Longest subsequence's length: " + lcsArray[rows, cols]);
        }
    }
}
