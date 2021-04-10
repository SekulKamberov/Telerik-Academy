namespace _14.CountMatrixDistances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            int n = 6;
            string[,] matrix = GenerateMatrix(n);

            var startRow = random.Next(0, n);
            var startCol = random.Next(0, n);
            matrix[startRow, startCol] = "*";
            
            PrintMatrix(matrix);
            Queue<Possition> cells = new Queue<Possition>();
            cells.Enqueue(new Possition(startRow, startCol));
            CalculateDistance(matrix, cells);
            PrintMatrix(matrix);
        }

        private static void CalculateDistance(string[,] matrix, Queue<Possition> cells)
        {
            while (cells.Count != 0)
            {
                var currentPossition = cells.Dequeue();
                var currentRow = currentPossition.Row;
                var currentCol = currentPossition.Col;
                var cellValue = matrix[currentRow, currentCol];
                if (cellValue != "x")
                {
                    int nextValue = cellValue != "*" ? (int.Parse(cellValue) + 1) : 1;

                    // L
                    var isLeftInside = currentCol - 1 >= 0;
                    if (isLeftInside && matrix[currentRow, currentCol - 1] == "0")
                    {
                        matrix[currentRow, currentCol - 1] = nextValue.ToString();
                        cells.Enqueue(new Possition(currentRow, currentCol - 1));
                    }

                    // R
                    var isRigthInside = currentCol + 1 < matrix.GetLength(1);
                    if (isRigthInside && matrix[currentRow, currentCol + 1] == "0")
                    {
                        matrix[currentRow, currentCol + 1] = nextValue.ToString();
                        cells.Enqueue(new Possition(currentRow, currentCol + 1));
                    }

                    // U
                    var isUpInside = currentRow - 1 >= 0;
                    if (isUpInside && matrix[currentRow - 1, currentCol] == "0")
                    {
                        matrix[currentRow - 1, currentCol] = nextValue.ToString();
                        cells.Enqueue(new Possition(currentRow - 1, currentCol));
                    }

                    // D
                    var isDownInside = currentRow + 1 < matrix.GetLength(0);
                    if (isDownInside && matrix[currentRow + 1, currentCol] == "0")
                    {
                        matrix[currentRow + 1, currentCol] = nextValue.ToString();
                        cells.Enqueue(new Possition(currentRow + 1, currentCol));
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        matrix[i, j] = "U";
                    }
                }
            }
        }

        private static string[,] GenerateMatrix(int size)
        {
            string[] letters = new[] { "x", "0", "0", "0" };
            string[,] matrix = new string[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = letters[random.Next(0, letters.Length)];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
