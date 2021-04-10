namespace PokerGame.Cards
{
    using System;

    public static class CardsExtensions
    {
        public static string CardSuitToString(this CardSuit suit)
        {
            switch (suit)
            {
                case CardSuit.Club:
                    return "♣";
                case CardSuit.Diamond:
                    return "♦";
                case CardSuit.Heart:
                    return "♥";
                case CardSuit.Spade:
                    return "♠";
                default:
                    throw new ArgumentException("Card suit is invalid.");
            }
        }

        public static string CardTypeToString(this CardType type)
        {
            switch (type)
            {
                case CardType.Two:
                    return "2";
                case CardType.Three:
                    return "3";
                case CardType.Four:
                    return "4";
                case CardType.Five:
                    return "5";
                case CardType.Six:
                    return "6";
                case CardType.Seven:
                    return "7";
                case CardType.Eight:
                    return "8";
                case CardType.Nine:
                    return "9";
                case CardType.Ten:
                    return "10";
                case CardType.Jack:
                    return "J";
                case CardType.Queen:
                    return "Q";
                case CardType.King:
                    return "K";
                case CardType.Ace:
                    return "A";
                default:
                    throw new ArgumentOutOfRangeException("Card type is invalid.");
            }
        }
    }
}
