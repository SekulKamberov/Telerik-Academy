namespace _15.HeadToHeadLeagueMatchesGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RoundsMatchesGenerator
    {
        private const char SwapValue = 'x';
        private const char Empty = ' ';
        private const char Match = 'M';
        private int size;
        private int maxRound;
        private bool[,] board;
        private bool[,] finalBoard;
        private bool[,] roundsOccupiedRowsAndCols;
        private bool[,,] roundMatches;
        private bool hasFoundAllCombinations;
        private IList<RoundMatch> matches;
        private Stack<RoundMatch> tempMatches;

        public RoundsMatchesGenerator(int size)
        {
            this.Size = size;
            this.maxRound = this.Size - 2;
            this.board = new bool[this.Size, this.Size];
            this.roundsOccupiedRowsAndCols = new bool[this.Size - 1, this.Size];
            this.roundMatches = new bool[this.Size - 1, this.Size, this.Size];
            this.hasFoundAllCombinations = false;
            this.matches = new List<RoundMatch>();
            this.tempMatches = new Stack<RoundMatch>();
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

        public void PrintBoard()
        {
            var horisontal = new StringBuilder("  ");
            for (int i = 0; i < this.finalBoard.GetLength(0); i++)
            {
                horisontal.Append(" ");
                horisontal.Append(i % 10);
            }

            Console.WriteLine(horisontal);
            for (int row = 0; row < this.finalBoard.GetLength(0); row++)
            {
                Console.Write("{0} ", row);
                for (int col = 0; col < this.finalBoard.GetLength(1); col++)
                {
                    if (this.finalBoard[row, col] == true)
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

        public void PrintMatches()
        {
            for (int i = 0; i < this.matches.Count; i++)
            {
                Console.WriteLine(this.matches[i]);
            }
        }

        public IList<RoundMatch> GenerateRoundsMatches()
        {
            this.FindPossibleMatch(1, 0, 0);

            return this.matches;
        }

        private void FindPossibleMatch(int row, int col, int round)
        {
            if (this.hasFoundAllCombinations ||
                !this.AreParramsCorrect(row, col, round))
            {
                return;
            }

            if (this.IsMatchAvailable(row, col, round))
            {
                var match = new RoundMatch(row, col, round);
                this.tempMatches.Push(match);
                this.roundMatches[round, row, col] = true;
                this.roundsOccupiedRowsAndCols[round, row] = true;
                this.roundsOccupiedRowsAndCols[round, col] = true;
                this.board[row, col] = true;

                this.FindPossibleMatch(row + 1, 0, round);
                if (this.HasFullRound(round))
                {
                    if (round == this.maxRound)
                    {
                        this.hasFoundAllCombinations = true;
                        this.finalBoard = (bool[,])this.board.Clone();
                        this.matches = this.tempMatches.ToArray();

                        return;
                    }

                    this.FindPossibleMatch(2, 0, round + 1);
                }

                this.tempMatches.Pop();
                this.roundMatches[round, row, col] = false;
                this.roundsOccupiedRowsAndCols[round, row] = false;
                this.roundsOccupiedRowsAndCols[round, col] = false;
                this.board[row, col] = false;
            }
            else
            {
                if (this.roundsOccupiedRowsAndCols[round, row] == false)
                {
                    this.FindPossibleMatch(row, col + 1, round);
                }

                this.FindPossibleMatch(row + 1, 0, round);
                if (this.HasFullRound(round))
                {
                    this.FindPossibleMatch(2, 0, round + 1);
                }
            }
        }

        private bool IsMatchAvailable(int row, int col, int round)
        {
            if (this.board[row, col] ||
                this.roundsOccupiedRowsAndCols[round, row] ||
                this.roundsOccupiedRowsAndCols[round, col])
            {
                return false;
            }

            return true;
        }

        private bool HasFullRound(int round)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this.roundsOccupiedRowsAndCols[round, i] == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreParramsCorrect(int row, int col, int round)
        {
            if (row < 1 ||
                this.Size <= row)
            {
                return false;
            }

            if (col < 0 ||
                row <= col)
            {
                return false;
            }

            if (round < 0 ||
                this.maxRound < round)
            {
                return false;
            }

            return true;
        }
    }
}
