namespace _09.LargestConnectedArea
{
    using System;
    using System.Collections.Generic;

    public class Labirint
    {
        private const char NotPassable = 'x';
        private const char Visited = 'o';
        private const char Passable = '*';
        private const char Exit = 'E';
        private const char Start = 's';
        private char[,] matrix;
        private List<char> directions = new List<char>();
        private int maxAreaCount = 0;
        private int tempAreaCount = 0;

        public Labirint(char[,] matrix)
        {
            this.matrix = matrix;
        }

        public void FindPaths(int row, int col, int endRow, int endCol, char direction)
        {
            if (!this.IsPossitionInsideMatrix(row, col))
            {
                return;
            }

            if (this.matrix[row, col] == NotPassable ||
                    this.matrix[row, col] == Visited)
            {
                return;
            }

            this.directions.Add(direction);
            if (row == endRow && col == endCol)
            {
                this.MarkCurrent(row, col, 'E');
                this.directions.Add(Exit);
                this.PrintPath();
                this.directions.RemoveAt(this.directions.LastIndexOf(Exit));
                this.directions.RemoveAt(this.directions.LastIndexOf(direction));
                this.UnmarkCurrent(row, col);
                return;
            }

            this.MarkCurrent(row, col);

            this.FindPaths(row - 1, col + 0, endRow, endCol, 'U'); // up
            this.FindPaths(row + 0, col + 1, endRow, endCol, 'R'); // right
            this.FindPaths(row + 1, col + 0, endRow, endCol, 'D'); // down
            this.FindPaths(row + 0, col - 1, endRow, endCol, 'L'); // left

            this.UnmarkCurrent(row, col);
            this.directions.RemoveAt(this.directions.LastIndexOf(direction));
        }

        public void FindLargestConnectedArea()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.tempAreaCount = 0;
                    this.TraverseAreaFromPosition(i, j);
                    if (this.tempAreaCount > this.maxAreaCount)
                    {
                        this.maxAreaCount = this.tempAreaCount;
                    }
                }
            }

            Console.WriteLine("Max Area Count: {0}", this.maxAreaCount);
        }

        private void TraverseAreaFromPosition(int row, int col)
        {
            if (!this.IsPossitionInsideMatrix(row, col))
            {
                return;
            }

            if (this.matrix[row, col] == NotPassable ||
                    this.matrix[row, col] == Visited)
            {
                return;
            }

            this.matrix[row, col] = Visited;
            this.tempAreaCount++;

            this.TraverseAreaFromPosition(row - 1, col + 0); // up
            this.TraverseAreaFromPosition(row + 0, col + 1); // right
            this.TraverseAreaFromPosition(row + 1, col + 0); // down
            this.TraverseAreaFromPosition(row + 0, col - 1); // left
        }

        private bool IsPossitionInsideMatrix(int row, int col)
        {
            bool isRowCorrect = row >= 0 && row < this.matrix.GetLength(0);
            bool isColCorrect = col >= 0 && col < this.matrix.GetLength(1);
            if (!isRowCorrect || !isColCorrect)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UnmarkCurrent(int row, int col)
        {
            this.matrix[row, col] = Passable;
        }

        private void MarkCurrent(int row, int col, char mark = Visited)
        {
            this.matrix[row, col] = mark;
        }

        private void PrintPath()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    Console.Write(" " + this.matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(string.Join(">", this.directions));
        }
    }
}
