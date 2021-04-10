namespace _07.PathsBetweenPoints
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

        public Labirint(char[,] matrix)
        {
            this.matrix = matrix;
        }

        public void FindPaths(int row, int col, int endRow, int endCol, char direction)
        {
            if (!this.CheckRowAndCol(row, col))
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

        private bool CheckRowAndCol(int row, int col)
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
                    this.SetColor(this.matrix[row, col]);
                    Console.Write(" " + this.matrix[row, col]);
                    this.SetDefaultColor();
                }

                Console.WriteLine();
            }

            Console.WriteLine(string.Join(">", this.directions));
        }

        private void SetDefaultColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void SetColor(char ch)
        {
            if (ch == 'o')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (ch == '*')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (ch == 'x')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }
}
