namespace _12.QueensBacktracking
{
    using System;
    using System.Collections.Generic;

    public class QueenBoard
    {
        private const char SwapValue = 'x';
        private const char Empty = ' ';
        private const char Queen = 'Q';
        private const bool BoolQueen = true;
        private static int counter = 0;
        private int size = 0;
        private byte[,] matrix;

        public QueenBoard(int size)
        {
            this.size = size;
            this.matrix = new byte[size, size];
        }

        public int FindQueensSolutions()
        {
            counter = 0;
            this.CountSolutions(0);
            return counter;
        }

        public void PrintBoard()
        {
            Console.WriteLine("   a b c d e f g h");
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                Console.Write("{0} ", 8 - i);
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    // Console.Write(" " + this.matrix[i, j]);
                    if (this.matrix[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + Queen);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(" " + SwapValue);
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void CountSolutions(int row)
        {
            if (row == this.matrix.GetLength(0))
            {
                counter++;

                // this.PrintBoard();
                return;
            }

            for (int col = 0; col < this.matrix.GetLength(1); col++)
            {
                if (this.matrix[row, col] == 0)
                {
                    this.matrix[row, col] += 1;
                    this.MarkQueen(row, col);

                    this.CountSolutions(row + 1);

                    this.matrix[row, col] -= 1;
                    this.UnMarkQueen(row, col);
                }
            }
        }

        private void UnMarkQueen(int row, int col)
        {
            for (int i = row; i < this.matrix.GetLength(0); i++)
            {
                this.matrix[i, col] -= 1;
                if (col + (i - row) < this.matrix.GetLength(0))
                {
                    this.matrix[i, col + (i - row)] -= 1;
                }

                if (col - (i - row) >= 0)
                {
                    this.matrix[i, col - (i - row)] -= 1;
                }
            }
        }

        private void MarkQueen(int row, int col)
        {
            for (int i = row; i < this.matrix.GetLength(0); i++)
            {
                this.matrix[i, col] += 1;
                if (col + (i - row) < this.matrix.GetLength(0))
                {
                    this.matrix[i, col + (i - row)] += 1;
                }

                if (col - (i - row) >= 0)
                {
                    this.matrix[i, col - (i - row)] += 1;
                }
            }
        }
    }
}
