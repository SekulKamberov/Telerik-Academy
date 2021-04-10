namespace PokerGame
{
    using System;
    using PokerGame.Cards;
    using PokerGame.Interfaces;

    public class Deck : IShuffle
    {
        private const int Size = 52;
        private static Random random = new Random();
        private ICard[] cards = new Card[Size];
        
        public Deck()
        {
            this.Init();
        }

        public Deck Clone()
        {
            var copy = new Deck();
            for (int i = 0; i < Size; i++)
            {
                copy.cards[i] = this.cards[i];
            }

            return copy;
        }

        public void Shuffle()
        {
            for (int i = 0; i < Size; i++)
            {
                int randomIndex = random.Next(0, Size);
                var temp = this.cards[i];
                this.cards[i] = this.cards[randomIndex];
                this.cards[randomIndex] = temp;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join<ICard>(", ", this.cards));
        }

        private void Init()
        {
            this.cards[0] = new Card(CardType.Two, CardSuit.Club);
            this.cards[1] = new Card(CardType.Two, CardSuit.Diamond);
            this.cards[2] = new Card(CardType.Two, CardSuit.Heart);
            this.cards[3] = new Card(CardType.Two, CardSuit.Spade);
            this.cards[4] = new Card(CardType.Three, CardSuit.Club);
            this.cards[5] = new Card(CardType.Three, CardSuit.Diamond);
            this.cards[6] = new Card(CardType.Three, CardSuit.Heart);
            this.cards[7] = new Card(CardType.Three, CardSuit.Spade);
            this.cards[8] = new Card(CardType.Four, CardSuit.Club);
            this.cards[9] = new Card(CardType.Four, CardSuit.Diamond);
            this.cards[10] = new Card(CardType.Four, CardSuit.Heart);
            this.cards[11] = new Card(CardType.Four, CardSuit.Spade);
            this.cards[12] = new Card(CardType.Five, CardSuit.Club);
            this.cards[13] = new Card(CardType.Five, CardSuit.Diamond);
            this.cards[14] = new Card(CardType.Five, CardSuit.Heart);
            this.cards[15] = new Card(CardType.Five, CardSuit.Spade);
            this.cards[16] = new Card(CardType.Six, CardSuit.Club);
            this.cards[17] = new Card(CardType.Six, CardSuit.Diamond);
            this.cards[18] = new Card(CardType.Six, CardSuit.Heart);
            this.cards[19] = new Card(CardType.Six, CardSuit.Spade);
            this.cards[20] = new Card(CardType.Seven, CardSuit.Club);
            this.cards[21] = new Card(CardType.Seven, CardSuit.Diamond);
            this.cards[22] = new Card(CardType.Seven, CardSuit.Heart);
            this.cards[23] = new Card(CardType.Seven, CardSuit.Spade);
            this.cards[24] = new Card(CardType.Eight, CardSuit.Club);
            this.cards[25] = new Card(CardType.Eight, CardSuit.Diamond);
            this.cards[26] = new Card(CardType.Eight, CardSuit.Heart);
            this.cards[27] = new Card(CardType.Eight, CardSuit.Spade);
            this.cards[28] = new Card(CardType.Nine, CardSuit.Club);
            this.cards[29] = new Card(CardType.Nine, CardSuit.Diamond);
            this.cards[30] = new Card(CardType.Nine, CardSuit.Heart);
            this.cards[31] = new Card(CardType.Nine, CardSuit.Spade);
            this.cards[32] = new Card(CardType.Ten, CardSuit.Club);
            this.cards[33] = new Card(CardType.Ten, CardSuit.Diamond);
            this.cards[34] = new Card(CardType.Ten, CardSuit.Heart);
            this.cards[35] = new Card(CardType.Ten, CardSuit.Spade);
            this.cards[36] = new Card(CardType.Jack, CardSuit.Club);
            this.cards[37] = new Card(CardType.Jack, CardSuit.Diamond);
            this.cards[38] = new Card(CardType.Jack, CardSuit.Heart);
            this.cards[39] = new Card(CardType.Jack, CardSuit.Spade);
            this.cards[40] = new Card(CardType.Queen, CardSuit.Club);
            this.cards[41] = new Card(CardType.Queen, CardSuit.Diamond);
            this.cards[42] = new Card(CardType.Queen, CardSuit.Heart);
            this.cards[43] = new Card(CardType.Queen, CardSuit.Spade);
            this.cards[44] = new Card(CardType.King, CardSuit.Club);
            this.cards[45] = new Card(CardType.King, CardSuit.Diamond);
            this.cards[46] = new Card(CardType.King, CardSuit.Heart);
            this.cards[47] = new Card(CardType.King, CardSuit.Spade);
            this.cards[48] = new Card(CardType.Ace, CardSuit.Club);
            this.cards[49] = new Card(CardType.Ace, CardSuit.Diamond);
            this.cards[50] = new Card(CardType.Ace, CardSuit.Heart);
            this.cards[51] = new Card(CardType.Ace, CardSuit.Spade);

            this.Shuffle();
        }
    }
}
