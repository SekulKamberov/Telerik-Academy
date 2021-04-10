namespace PokerGame.Cards
{
    using PokerGame.Interfaces;

    public class Card : ICard
    {
        private CardType type;
        private CardSuit suit;

        public Card(CardType type, CardSuit suit)
        {
            this.type = type;
            this.suit = suit;
        }

        public CardSuit Suit
        {
            get { return this.suit; }
            private set { this.suit = value; }
        }

        public CardType Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.Type.CardTypeToString(), this.Suit.CardSuitToString());
        }
    }
}
