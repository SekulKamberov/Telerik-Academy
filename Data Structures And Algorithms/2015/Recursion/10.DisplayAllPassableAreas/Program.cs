namespace _10.DisplayAllPassableAreas
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            var matrixSize = 10;
            char[,] bigMatrix = new char[matrixSize, matrixSize];
            int brickInitRation = 2;
            InitMatrix(bigMatrix, brickInitRation);
            PrintMatrix(bigMatrix);
            var lab = new Labirint(bigMatrix);
            lab.FindConnectedAreas();
        }

        private static void InitMatrix(char[,] matrix, int brickInitRatio = 3)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int number = random.Next(0, 10);
                    if (number % brickInitRatio == 0)
                    {
                        matrix[i, j] = 'x';
                    }
                    else
                    {
                        matrix[i, j] = '*';
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("{0} ", i.ToString().PadLeft(2, '0'));
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void CopyArray(char[,] original, char[,] copy)
        {
            for (int i = 0; i < original.GetLength(0); i++)
            {
                for (int j = 0; j < original.GetLength(1); j++)
                {
                    copy[i, j] = original[i, j];
                }
            }
        }
    }
}
