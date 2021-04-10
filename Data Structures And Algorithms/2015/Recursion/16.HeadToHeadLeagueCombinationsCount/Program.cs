namespace _16.HeadToHeadLeagueCombinationsCount
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var hthl = new HeadToHeadLeague(4);
            Console.WriteLine("Possible rounds: " + hthl.CountPossibleRounds());
        }
    }
}
