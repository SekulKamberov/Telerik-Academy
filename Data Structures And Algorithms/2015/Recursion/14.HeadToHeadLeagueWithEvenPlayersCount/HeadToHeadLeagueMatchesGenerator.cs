namespace _14.HeadToHeadLeagueWithEvenPlayersCount
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// NEEED FIX, NOT WORKING CORRECT
    /// </summary>
    public class OpponentsRoundsMatchesGenerator
    {
        private const char SwapValue = 'x';
        private const char Empty = ' ';
        private const char Match = 'M';
        private int size;
        private int round;
        private int tempMatchesMaxCount;
        private bool[,] board;
        private bool[,] tempBoard;
        private bool hasFoundAllCombinations;
        private bool[] occupiedRowsAndCols;
        private IList<RoundMatch> matches;
        private Stack<RoundMatch> tempMatches;
        private bool hasAddedFixtureMatches;

        public OpponentsRoundsMatchesGenerator(int size)
        {
            this.size = size;
            this.tempMatchesMaxCount = this.size / 2;
            this.board = new bool[size, size];
            this.round = 0;
            this.hasFoundAllCombinations = false;
            this.matches = new List<RoundMatch>();
        }

        public void PrintBoard()
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7");
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

        public void PrintMatches()
        {
            for (int i = 0; i < this.matches.Count; i++)
            {
                Console.WriteLine(this.matches[i]);
            }
        }

        public IList<RoundMatch> GenerateRoundsMatches()
        {
            if (this.size <= 1)
            {
                return null;
            }
            else if (this.size == 2)
            {
                var firstMatch = new RoundMatch(1, 0, 0);
                this.matches.Add(firstMatch);
                this.board[1, 0] = true;

                // var secondMatch = new RoundMatch(0, 1, 1);
                // this.matches.Add(secondMatch);
                return this.matches;
            }

            int row = 1;
            while (row < this.size)
            {
                var match = new RoundMatch(row, 0, this.round);
                this.tempMatches = new Stack<RoundMatch>();
                this.tempMatches.Push(match);
                this.tempBoard = new bool[this.size, this.size];
                this.tempBoard[row, 0] = true;
                this.occupiedRowsAndCols = new bool[this.size];
                this.occupiedRowsAndCols[row] = true;
                this.occupiedRowsAndCols[0] = true;
                this.hasAddedFixtureMatches = false;
                this.board[row, 0] = true;
                this.FindPossibleMatch(2);
                row++;
            }

            return this.matches;
        }

        private void FindPossibleMatch(int row)
        {
            if (this.hasAddedFixtureMatches || this.hasFoundAllCombinations)
            {
                return;
            }

            if (row == this.size)
            {
                this.CheckAllComminations();

                return;
            }

            int col = 0;
            int maxCol = row - 1;
            while (col <= maxCol)
            {
                if (this.IsMatchAvailable(row, col))
                {
                    var match = new RoundMatch(row, col, this.round);
                    this.tempMatches.Push(match);
                    this.occupiedRowsAndCols[row] = true;
                    this.occupiedRowsAndCols[col] = true;
                    this.tempBoard[row, col] = true;

                    if (this.tempMatches.Count == this.tempMatchesMaxCount)
                    {
                        this.AddTempOpponetsToFinalList();
                        this.hasAddedFixtureMatches = true;
                    }

                    this.FindPossibleMatch(row + 1);

                    if (this.hasAddedFixtureMatches || this.hasFoundAllCombinations)
                    {
                        return;
                    }

                    this.tempMatches.Pop();
                    this.occupiedRowsAndCols[row] = false;
                    this.occupiedRowsAndCols[col] = false;
                    this.tempBoard[row, col] = false;
                }

                col++;
            }

            this.FindPossibleMatch(row + 1);
        }

        private bool IsMatchAvailable(int row, int col)
        {
            if (this.occupiedRowsAndCols[row] ||
                this.occupiedRowsAndCols[col] ||
                this.board[row, col] ||
                this.tempBoard[row, col])
            {
                return false;
            }

            return true;
        }

        private void AddTempOpponetsToFinalList()
        {
            while (this.tempMatches.Count != 0)
            {
                var match = this.tempMatches.Pop();
                this.board[match.HomeTeam, match.AwayTeam] = true;
                this.matches.Add(match);
            }

            this.round++;
        }

        private void CheckAllComminations()
        {
            int row = 1;

            while (row < this.size)
            {
                int col = 0;
                int maxCol = row - 1;
                while (col <= maxCol)
                {
                    if (this.board[row, col] == false)
                    {
                        return;
                    }

                    col++;
                }

                row++;
            }

            this.hasFoundAllCombinations = true;
        }
    }
}
