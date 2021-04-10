namespace Poker
{
    using System;

    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Face, this.Suit);
        }

        public int CompareTo(ICard other)
        {
            if (this.Face > other.Face)
            {
                return -1;
            }
            else if (this.Face < other.Face)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
