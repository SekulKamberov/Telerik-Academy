namespace _14.HeadToHeadLeagueWithEvenPlayersCount
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var hlmg = new OpponentsRoundsMatchesGenerator(12);
            hlmg.GenerateRoundsMatches();
            Console.WriteLine("Start");
            hlmg.PrintMatches();
            hlmg.PrintBoard();
        }
    }
}
