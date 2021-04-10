namespace _08.ChechAnyPath
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            var matrixSize = 76;
            char[,] bigMatrix = new char[matrixSize, matrixSize];
            int brickInitRation = 5;
            InitMatrix(bigMatrix, brickInitRation);
            char[,] copy = new char[matrixSize, matrixSize];
            CopyArray(bigMatrix, copy);
            PrintMatrix(copy);

            while (true)
            {
                CopyArray(bigMatrix, copy);
                var lab = new Labirint(copy);
                int startRow;
                Console.Write("Start row: ");
                startRow = int.Parse(Console.ReadLine());
                int startCol;
                Console.Write("Start col: ");
                startCol = int.Parse(Console.ReadLine());
                int endRow;
                Console.Write("End row: ");
                endRow = int.Parse(Console.ReadLine());
                int endCol;
                Console.Write("End col: ");
                endCol = int.Parse(Console.ReadLine());
                Console.WriteLine("Is Path: {0}", lab.FindPaths(startRow, startCol, endRow, endCol, 'S'));
                PrintMatrixColored(copy);
                Console.WriteLine();
            }
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
        }

        private static void PrintMatrixColored(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("{0} ", i.ToString().PadLeft(2, '0'));
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    SetColor(matrix[i, j]);
                    Console.Write(matrix[i, j]);
                    SetDefaultColor();
                }

                Console.WriteLine();
            }
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
        
        private static void SetDefaultColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void SetColor(char ch)
        {
            if (ch == 'o')
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (ch == '*')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (ch == 'U')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (ch == 'R')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (ch == 'D')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (ch == 'L')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (ch == 'E')
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (ch == 'x')
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
    }
}
