namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        // optimization
        private int[] firstCardsCount;
        private IHand firstHand;
        private int[] secondCardsCount;
        private IHand secondHand;

        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                ICard firstCard = hand.Cards[i];
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    ICard secondCard = hand.Cards[j];
                    if (firstCard.ToString() == secondCard.ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (this.IsFlush(hand) && this.IsStraight(hand)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int[] cardsCount = this.CheckCards(hand);

            if (cardsCount[0] == 4 || cardsCount[1] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            int[] cardsCount = this.CheckCards(hand);

            if ((cardsCount[0] == 3 && cardsCount[1] == 2) || (cardsCount[0] == 2 && cardsCount[1] == 3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            CardSuit suid = hand.Cards[0].Suit;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                ICard card = hand.Cards[i];
                if (card.Suit != suid)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            List<ICard> cards = (List<ICard>)hand.Cards;
            cards.Sort();

            ICard card = hand.Cards[0];
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (cards[i].Face != (card.Face - 1))
                {
                    return false;
                } 
                else 
                {
                    card = hand.Cards[i];
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            int[] cardsCount = this.CheckCards(hand);

            if ((cardsCount[0] == 3 && cardsCount[1] != 2) || 
                    (cardsCount[1] == 3 && cardsCount[0] != 2) || 
                        cardsCount[2] == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            int[] cardsCount = this.CheckCards(hand);

            if ((cardsCount[0] == 2 && cardsCount[1] == 2) ||
                    (cardsCount[0] == 2 && cardsCount[2] == 2) ||
                        (cardsCount[1] == 2 && cardsCount[2] == 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            int[] cardsCount = this.CheckCards(hand);

            if ((cardsCount[0] == 2 && cardsCount[1] < 2 && cardsCount[2] < 2 && cardsCount[3] < 2) ||
                    (cardsCount[1] == 2 && cardsCount[0] < 2 && cardsCount[2] < 2 && cardsCount[3] < 2) ||
                        (cardsCount[2] == 2 && cardsCount[0] < 2 && cardsCount[1] < 2 && cardsCount[3] < 2) ||
                            (cardsCount[3] == 2 && cardsCount[0] < 2 && cardsCount[1] < 2 && cardsCount[2] < 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            int[] cardsCount = this.CheckCards(hand);
            if (cardsCount[4] != 0 && this.IsStraight(hand) == false && this.IsFlush(hand) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            bool firstHandIsHighCard = this.IsHighCard(firstHand);
            bool secondHandIsHighCard = this.IsHighCard(secondHand);
            if (firstHandIsHighCard && secondHandIsHighCard)
            {
                return 0;
            }
            else if (firstHandIsHighCard)
            {
                return -1;
            } 
            else if (secondHandIsHighCard)
            {
                return 1;
            }

            bool firstHandIsOnePair = this.IsOnePair(firstHand);
            bool secondHandIsOnePair = this.IsOnePair(secondHand);
            if (firstHandIsOnePair && secondHandIsOnePair)
            {
                return 0;
            }
            else if (firstHandIsOnePair)
            {
                return -1;
            }
            else if (secondHandIsOnePair)
            {
                return 1;
            }

            bool firstHandIsTwoPair = this.IsTwoPair(firstHand);
            bool secondHandIsTwoPair = this.IsTwoPair(secondHand);
            if (firstHandIsTwoPair && secondHandIsTwoPair)
            {
                return 0;
            }
            else if (firstHandIsTwoPair)
            {
                return -1;
            }
            else if (secondHandIsTwoPair)
            {
                return 1;
            }

            bool firstHandIsThreeOfAKind = this.IsThreeOfAKind(firstHand);
            bool secondHandIsThreeOfAKind = this.IsThreeOfAKind(secondHand);
            if (firstHandIsThreeOfAKind && secondHandIsThreeOfAKind)
            {
                return 0;
            }
            else if (firstHandIsThreeOfAKind)
            {
                return -1;
            }
            else if (secondHandIsThreeOfAKind)
            {
                return 1;
            }

            bool firstHandIsStraight = this.IsStraight(firstHand);
            bool secondHandIsStraight = this.IsStraight(secondHand);
            bool firstHandIsFlush = this.IsFlush(firstHand);
            bool secondHandIsFlush = this.IsFlush(secondHand);
            if (firstHandIsStraight && secondHandIsStraight && firstHandIsFlush == false && secondHandIsFlush == false)
            {
                return 0;
            }
            else if (firstHandIsStraight && firstHandIsFlush == false)
            {
                return -1;
            }
            else if (secondHandIsStraight && secondHandIsFlush == false)
            {
                return 1;
            }

            if (firstHandIsFlush && secondHandIsFlush && firstHandIsStraight == false && secondHandIsStraight == false)
            {
                return 0;
            }
            else if (firstHandIsFlush && firstHandIsStraight == false)
            {
                return -1;
            }
            else if (secondHandIsFlush && secondHandIsStraight == false)
            {
                return 1;
            }

            bool firstHandIsFullHouse = this.IsFullHouse(firstHand);
            bool secondHandIsFullHouse = this.IsFullHouse(secondHand);
            if (firstHandIsFullHouse && secondHandIsFullHouse)
            {
                return 0;
            }
            else if (firstHandIsFullHouse)
            {
                return -1;
            }
            else if (secondHandIsFullHouse)
            {
                return 1;
            }

            bool firstHandIsFourOfAKind = this.IsFourOfAKind(firstHand);
            bool secondHandIsFourOfAKind = this.IsFourOfAKind(secondHand);
            if (firstHandIsFourOfAKind && secondHandIsFourOfAKind)
            {
                return 0;
            }
            else if (firstHandIsFourOfAKind)
            {
                return -1;
            }
            else if (secondHandIsFourOfAKind)
            {
                return 1;
            }

            return 0;
        }

        private int[] CheckCards(IHand hand)
        {
            // optimization
            if (hand == this.firstHand)
            {
                return this.firstCardsCount;
            }
            else if (hand == this.secondHand)
            {
                return this.secondCardsCount;
            }
            else
            {
                this.firstHand = null;
                this.secondCardsCount = null;
            }

            int[] cardsCount = new int[5];

            // optimization
            if (this.firstHand == null)
            {
                this.firstHand = hand;
                this.firstCardsCount = cardsCount;
            }
            else
            {
                this.secondHand = hand;
                this.secondCardsCount = cardsCount;
            }

            ICard firstCard = hand.Cards[0];
            cardsCount[0] = 1;
            ICard secondCard = null;
            ICard thirdCard = null;
            ICard fourthCard = null;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                ICard card = hand.Cards[i];
                if (card.Face == firstCard.Face)
                {
                    cardsCount[0] += 1;
                }
                else if (secondCard == null)
                {
                    secondCard = card;
                    cardsCount[1] += 1;
                }
                else if (card.Face == secondCard.Face)
                {
                    cardsCount[1] += 1;
                }
                else if (thirdCard == null)
                {
                    thirdCard = card;
                    cardsCount[2] += 1;
                }
                else if (card.Face == thirdCard.Face)
                {
                    cardsCount[2] += 1;
                }
                else if (fourthCard == null)
                {
                    fourthCard = card;
                    cardsCount[3] += 1;
                }
                else if (card.Face == fourthCard.Face)
                {
                    cardsCount[3] += 1;
                }
                else
                {
                    cardsCount[4] += 1;
                }
            }

            return cardsCount;
        }
    }
}
