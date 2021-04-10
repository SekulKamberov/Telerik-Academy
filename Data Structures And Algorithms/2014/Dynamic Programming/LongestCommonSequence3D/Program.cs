using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSequence3D
{
    class Program
    {

        static void Main(string[] args)
        {
            string X = "opesho";
            string Y = "gosho";
            string Z = "tosho";

            FindLongestCommonSequence(X, Y, Z);
        }

        private static void FindLongestCommonSequence(string X, string Y, string Z)
        {
            int x = X.Length;
            int y = Y.Length;
            int z = Z.Length;
            int[,,] lcsArray = new int[x + 1, y + 1, z + 1];

            //for (int i = 0; i < lcsArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < lcsArray.GetLength(1); j++)
            //    {
            //        for (int n = 0; n < lcsArray.GetLength(2); n++)
            //        {
            //            Console.Write(lcsArray[i, j, n] + " ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            for (int i = 1; i < lcsArray.GetLength(0); i++)
            {
                for (int j = 1; j < lcsArray.GetLength(1); j++)
                {
                    for (int n = 1; n < lcsArray.GetLength(2); n++)
                    {
                        if (X[i - 1] == Y[j - 1] && X[i - 1] == Z[n - 1])
                        {
                            lcsArray[i, j, n] = lcsArray[(i - 1), (j - 1), (n-1)] + 1;
                        }
                        else
                        {
                            int MAX = lcsArray[i, j - 1, n];
                            if (MAX < lcsArray[i - 1, j, n])
                            {
                                MAX = lcsArray[i - 1, j, n];
                            }
                            if (MAX < lcsArray[i, j, n - 1])
                            {
                                MAX = lcsArray[i, j, n - 1];
                            }

                            lcsArray[i, j, n] = MAX;
                        }
                    }
                }
            }
            Console.WriteLine("Longest subsequence's length: " + lcsArray[x, y, z]);
        }
    }
}
