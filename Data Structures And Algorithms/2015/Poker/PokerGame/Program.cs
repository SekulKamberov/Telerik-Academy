namespace PokerGame
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var deck = new Deck();
            Console.WriteLine(deck);
            var copy = deck.Clone();
            Console.WriteLine(copy);

            deck.Shuffle();
            Console.WriteLine(deck);
            Console.WriteLine(copy);
        }
    }
}
