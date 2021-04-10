namespace _08.ChechAnyPath
{
    using System;
    using System.Collections.Generic;

    public class Labirint
    {
        private const char NotPassable = 'x';
        private const char Visited = 'o';
        private const char Path = 'p';
        private const char Passable = '*';
        private const char Exit = 'E';
        private const char Start = 's';
        private const char Down = 'D';
        private const char Left = 'L';
        private const char Right = 'R';
        private const char Up = 'U';
        private char[,] matrix;
        private List<char> directions = new List<char>();

        public Labirint(char[,] matrix)
        {
            this.matrix = matrix;
        }

        public bool FindPaths(int row, int col, int endRow, int endCol, char direction)
        {
            if (!this.IsPossitionInsideMatrix(row, col))
            {
                return false;
            }

            if (this.matrix[row, col] == NotPassable ||
                    this.matrix[row, col] == Visited || this.matrix[row, col] == Path)
            {
                return false;
            }

            this.directions.Add(direction);
            if (row == endRow && col == endCol)
            {
                this.MarkPathWhenBacktrackingToStart(row, col, Exit);
                return true;
            }

            this.MarkCurrent(row, col);

            // up
            if (this.FindPaths(row - 1, col + 0, endRow, endCol, Up))
            {
                this.MarkPathWhenBacktrackingToStart(row, col, Up);
                return true;
            }

            // right
            if (this.FindPaths(row + 0, col + 1, endRow, endCol, Right))
            {
                this.MarkPathWhenBacktrackingToStart(row, col, Right);
                return true;
            }

            // down
            if (this.FindPaths(row + 1, col + 0, endRow, endCol, Down))
            {
                this.MarkPathWhenBacktrackingToStart(row, col, Down);
                return true;
            }

            // left
            if (this.FindPaths(row + 0, col - 1, endRow, endCol, Left))
            {
                this.MarkPathWhenBacktrackingToStart(row, col, Left);
                return true;
            }

            return false;
        }

        private void MarkPathWhenBacktrackingToStart(int row, int col, char c)
        {
            this.matrix[row, col] = c;
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

        private void MarkCurrent(int row, int col)
        {
            this.matrix[row, col] = Visited;
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
