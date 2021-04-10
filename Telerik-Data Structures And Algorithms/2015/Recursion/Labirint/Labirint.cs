namespace Labirint
{
    using System;
    using System.Collections.Generic;

    public class Labirint
    {
        private const char NotPassable = 'x';
        private const char Marked = 'm';
        private const char Passable = ' ';
        private const char Exit = 'e';
        private const char Start = 's';
        private char[,] matrix;
        private List<char> directions = new List<char>();

        public Labirint(char[,] matrix)
        {
            this.matrix = matrix;
        }

        public void FindPaths(int row, int col, char direction)
        {
            bool isRowCorrect = row >= 0 && row < this.matrix.GetLength(0);
            bool isColCorrect = col >= 0 && col < this.matrix.GetLength(1);
            if (!isRowCorrect || !isColCorrect)
            {
                return;
            }

            if (this.matrix[row, col] == NotPassable ||
                    this.matrix[row, col] == Marked)
            {
                return;
            }

            this.directions.Add(direction);
            if (this.matrix[row, col] == Exit)
            {
                this.directions.Add(Exit);
                this.PrintPath();
                this.directions.RemoveAt(this.directions.LastIndexOf(Exit));
                this.directions.RemoveAt(this.directions.LastIndexOf(direction));
                return;
            }

            this.MarkCurrent(row, col);

            this.FindPaths(row - 1, col + 0, 'U'); // up
            this.FindPaths(row + 0, col + 1, 'R'); // right
            this.FindPaths(row + 1, col + 0, 'D'); // down
            this.FindPaths(row + 0, col - 1, 'L'); // left
            this.UnmarkCurrent(row, col);
            this.directions.RemoveAt(this.directions.LastIndexOf(direction));
        }

        private void UnmarkCurrent(int row, int col)
        {
            this.matrix[row, col] = Passable;
        }

        private void MarkCurrent(int row, int col)
        {
            this.matrix[row, col] = Marked;
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
