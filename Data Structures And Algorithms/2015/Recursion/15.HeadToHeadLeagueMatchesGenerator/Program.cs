namespace _15.HeadToHeadLeagueMatchesGenerator
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var hlmg = new RoundsMatchesGenerator(6);
            Console.WriteLine("Start");
            hlmg.GenerateRoundsMatches();
            hlmg.PrintMatches();
            hlmg.PrintBoard();
        }
    }
}
