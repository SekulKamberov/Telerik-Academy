namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class PokerExample
    {
        public static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);

            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);
            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsValidHand(hand));

            // Console.WriteLine(checker.IsOnePair(hand));
            // Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}
