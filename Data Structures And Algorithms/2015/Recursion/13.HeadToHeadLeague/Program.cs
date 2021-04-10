namespace _13.HeadToHeadLeague
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var hlmg = new HeadToHeadLeagueMatchesGenerator(12);
            hlmg.GenerateMatches();
            Console.WriteLine("Start");
            hlmg.PrintMatches();
            hlmg.PrintBoard();
        }
    }
}
