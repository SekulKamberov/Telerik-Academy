namespace _16.HeadToHeadLeagueCombinationsCount
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Head-To-Head-League with even players count only
    /// </summary>
    public class HeadToHeadLeague
    {
        private const char SwapValue = 'x';
        private const char Empty = ' ';
        private const char Match = 'M';
        private int size;
        private int maxRow;
        private int counter;
        private bool[,] board;
        private bool[] roundsOccupiedRowsAndCols;

        public HeadToHeadLeague(int size)
        {
            this.Size = size;
            this.maxRow = this.Size - 1;
            this.board = new bool[this.Size, this.Size];
            this.roundsOccupiedRowsAndCols = new bool[this.Size];
        }

        public int Size 
        { 
            get
            {
                return this.size;
            }

            set
            {
                if (value < 2 || value > 20 || value % 2 != 0)
                {
                    throw new ArgumentOutOfRangeException("League size must be even number in the range [2, 20]");
                }

                this.size = value;
            }
        }

        public int CountPossibleRounds()
        {
            this.counter = 0;
            this.FindPossibleMatch(1);

            return this.counter;
        }

        private void FindPossibleMatch(int row)
        {
            if (row > this.maxRow)
            {
                if (this.HasFullRound())
                {
                    this.counter++;
                    this.PrintBoard();
                }

                return;
            }

            if (this.roundsOccupiedRowsAndCols[row])
            {
                this.FindPossibleMatch(row + 1);
            }
            else
            {
                for (int col = 0; col < row; col++)
                {
                    if (this.roundsOccupiedRowsAndCols[col] == false)
                    {
                        this.roundsOccupiedRowsAndCols[row] = true;
                        this.roundsOccupiedRowsAndCols[col] = true;
                        this.board[row, col] = true;

                        this.FindPossibleMatch(row + 1);

                        this.roundsOccupiedRowsAndCols[row] = false;
                        this.roundsOccupiedRowsAndCols[col] = false;
                        this.board[row, col] = false;
                    }
                }

                this.FindPossibleMatch(row + 1);
            }
        }

        private bool HasFullRound()
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.roundsOccupiedRowsAndCols[i] == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void PrintBoard()
        {
            var horisontal = new StringBuilder("  ");
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                horisontal.Append(" ");
                horisontal.Append(i % 10);
            }

            Console.WriteLine(horisontal);
            for (int row = 0; row < this.board.GetLength(0); row++)
            {
                Console.Write("{0} ", row);
                for (int col = 0; col < this.board.GetLength(1); col++)
                {
                    if (this.board[row, col] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + Match);
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
    }
}
