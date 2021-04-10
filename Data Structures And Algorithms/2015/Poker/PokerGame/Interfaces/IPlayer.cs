namespace PokerGame.Interfaces
{
    public interface IPlayer
    {
        int Money { get; set; }

        ICard[] Cards { get; set; }
    }
}