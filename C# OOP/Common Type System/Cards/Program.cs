namespace Cards
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Card firstCard = new Card(CardType.Ace, CardSuit.Heart);
            Card secondCard = new Card(CardType.King, CardSuit.Spade);
            Card thirdCard = new Card(CardType.Queen, CardSuit.Club);
            Console.WriteLine(firstCard);
            Console.WriteLine(secondCard);
            Console.WriteLine(thirdCard);
        }
    }
}