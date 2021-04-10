namespace _13.HeadToHeadLeague
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// NEEED FIX, NOT WORKING CORRECT
    /// </summary>
    public class HeadToHeadLeagueMatchesGenerator
    {
        private const char SwapValue = 'x';
        private const char Empty = ' ';
        private const char Match = 'M';
        private int size;
        private int round;
        private int tempOpponentsMaxCount;
        private bool[,] board;
        private bool[,] tempMatches;
        private bool hasFoundAllCombinations;
        private bool[] occupiedRowsAndCols;
        private IList<MatchOpponents> matches;
        private Stack<MatchOpponents> tempOpponets;
        private bool hasEvenPlayers;
        private bool hasPlayerAgainstAverage;
        private bool hasAddedFixtureMatches;

        public HeadToHeadLeagueMatchesGenerator(int size)
        {
            this.size = size;
            this.tempOpponentsMaxCount = (this.size / 2) + 1;
            if (size % 2 == 0)
            {
                this.hasEvenPlayers = true;
                this.tempOpponentsMaxCount = this.size / 2;
            }

            this.board = new bool[size, size];
            this.round = 0;
            this.hasFoundAllCombinations = false;
            this.matches = new List<MatchOpponents>();
        }

        public void PrintBoard()
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7");
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                Console.Write("{0} ", i);
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    if (this.board[i, j] == true)
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

        public IList<MatchOpponents> GenerateMatches()
        {
            if (this.size <= 1)
            {
                return null;
            }
            else if (this.size == 2)
            {
                var firstMatch = new MatchOpponents(0, 1, this.round);
                this.matches.Add(firstMatch);
                var secondMatch = new MatchOpponents(1, 0, this.round);
                this.matches.Add(secondMatch);

                return this.matches;
            }

            int row = 0;
            if (this.hasEvenPlayers == true)
            {
                row = 1;
            }

            while (row < this.size)
            {
                this.tempMatches = new bool[this.size, this.size];
                this.tempOpponets = new Stack<MatchOpponents>();
                this.occupiedRowsAndCols = new bool[this.size];
                this.hasPlayerAgainstAverage = false;
                this.hasAddedFixtureMatches = false;
                var match = new MatchOpponents(row, 0, this.round);
                this.tempOpponets.Push(match);
                this.occupiedRowsAndCols[row] = true;
                this.occupiedRowsAndCols[0] = true;
                this.board[row, 0] = true;
                if (this.hasEvenPlayers == false && row == 0)
                {
                    this.hasPlayerAgainstAverage = true;
                }

                this.FindPossible(0);
                row++;
            }

            return this.matches;
        }

        private void FindPossible(int row)
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

            int maxCol = row;
            if (this.hasEvenPlayers == true)
            {
                maxCol -= 1;
            }

            int col = 0;
            while (col <= maxCol)
            {
                if (this.tempMatches[row, col] == false && this.IsMatchAvailable(row, col))
                {
                    if (row == col)
                    {
                        this.hasPlayerAgainstAverage = true;
                    }

                    var match = new MatchOpponents(row, col, this.round);
                    this.tempOpponets.Push(match);
                    this.occupiedRowsAndCols[row] = true;
                    this.occupiedRowsAndCols[col] = true;
                    this.tempMatches[row, col] = true;

                    if (this.tempOpponets.Count == this.tempOpponentsMaxCount)
                    {
                        this.AddTempOpponetsToFinalList();
                        this.hasAddedFixtureMatches = true;
                    }

                    this.FindPossible(row + 1);

                    if (this.hasAddedFixtureMatches || this.hasFoundAllCombinations)
                    {
                        return;
                    }

                    if (row == col)
                    {
                        this.hasPlayerAgainstAverage = false;
                    }

                    this.tempOpponets.Pop();
                    this.occupiedRowsAndCols[row] = false;
                    this.occupiedRowsAndCols[col] = false;
                    this.tempMatches[row, col] = false;
                }

                col++;
            }

            this.FindPossible(row + 1);
        }

        private bool IsMatchAvailable(int row, int col)
        {
            if (this.occupiedRowsAndCols[row] || this.occupiedRowsAndCols[col])
            {
                return false;
            }

            if (this.board[row, col])
            {
                return false;
            }

            if (this.hasEvenPlayers == false && 
                row == col && 
                this.hasPlayerAgainstAverage)
            {
                return false;
            }

            return true;
        }

        private void AddTempOpponetsToFinalList()
        {
            while (this.tempOpponets.Count != 0)
            {
                var match = this.tempOpponets.Pop();
                this.board[match.HomeTeam, match.AwayTeam] = true;
                this.matches.Add(match);
            }

            this.round++;
        }

        private void CheckAllComminations()
        {
            int row = 0;
            if (this.hasEvenPlayers == false)
            {
                row = 1;
            }

            while (row < this.size)
            {
                int maxCol = row;
                if (this.hasEvenPlayers == false)
                {
                    maxCol -= 1;
                }

                int col = 0;
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
