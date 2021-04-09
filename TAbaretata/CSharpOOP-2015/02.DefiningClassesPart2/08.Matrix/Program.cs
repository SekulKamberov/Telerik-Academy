/*
 * Tasks from 8 to 10
 */

namespace _08.Matrix
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> matrixOne = new Matrix<int>(3,3);
            Matrix<int> matrixTwo = new Matrix<int>(3,3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrixOne[i, j] = i + 1;
                    matrixTwo[i, j] = j + 1;
                }
            }

            Console.WriteLine("First matrix: \r\n{0}",matrixOne);
            Console.WriteLine("Second matrix: \r\n{0}", matrixTwo);

            Matrix<int> concatMatrix = matrixOne + matrixTwo;
            Console.WriteLine("Concatenated matrix: \r\n{0}", concatMatrix);

            Matrix<int> subtractMatrix = matrixOne - matrixTwo;
            Console.WriteLine("Subtracted matrix: \r\n{0}", subtractMatrix);

            Matrix<int> multiMatrix = matrixOne * matrixTwo;
            Console.WriteLine("Multiplied matrix: \r\n{0}", multiMatrix);

            var hasZero = matrixOne ? false : true;
            Console.WriteLine("First Matrix has zeroes: {0}", hasZero);
        }
    }
}
