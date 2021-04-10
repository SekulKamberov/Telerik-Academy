namespace PokerGame.Interfaces
{
    using PokerGame.Cards;

    public interface ICard
    {
        CardSuit Suit { get; }

        CardType Type { get; }
    }
}
