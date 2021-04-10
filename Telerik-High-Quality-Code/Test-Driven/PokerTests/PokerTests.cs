namespace PokerTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerTests
    {
        private static PokerHandsChecker pokerHandsChecker;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            pokerHandsChecker = new PokerHandsChecker();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
        }

        [TestMethod]
        public void CardToStringMethod_ShouldReturnNonEmptyString()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            string cardToString = card.ToString();

            Assert.IsFalse(string.IsNullOrWhiteSpace(cardToString), "ToString() of Card should not return null or white space!");
        }

        [TestMethod]
        public void CardToStringMethod_ShouldReturnCorrectString()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            string cardToString = card.ToString();

            Assert.AreEqual(CardFace.Ace + " " + CardSuit.Clubs, cardToString, "ToString() of Card should return correct string!");
        }

        [TestMethod]
        public void HandToString_ShouldReturnNonEmptyString()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            string handToString = hand.ToString();

            Assert.IsFalse(string.IsNullOrWhiteSpace(handToString), "Hand ToString() should not be null or white space.");
        }

        [TestMethod]
        public void HandToString_ShouldReturnCorrectString()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            string handToString = hand.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CardFace.Ace + " " + CardSuit.Clubs);
            sb.AppendLine(CardFace.Ace + " " + CardSuit.Diamonds);
            sb.AppendLine(CardFace.King + " " + CardSuit.Hearts);
            sb.AppendLine(CardFace.King + " " + CardSuit.Spades);
            sb.AppendLine(CardFace.Seven + " " + CardSuit.Diamonds);
            string expectedString = sb.ToString();

            Assert.AreEqual(expectedString, handToString, "Hand to string should return correct string.");
        }

        [TestMethod]
        public void IsValidHandMethod_ShouldCheckIfHandHasExactlyFiveCards()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            Assert.IsFalse(pokerHandsChecker.IsValidHand(hand), "IsValidHand() should check if hand consist exactly five cards.");
        }

        [TestMethod]
        public void IsValidHandMethod_ShouldReturnFalseIfHandHasSomeCardTwice()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            Assert.IsFalse(pokerHandsChecker.IsValidHand(hand), "IsValidHand() should return false if hand has some card twice.");
        }

        [TestMethod]
        public void IsValidHandMethod_ShouldReturnTrueIfHandHasDifferentCards()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            Assert.IsTrue(pokerHandsChecker.IsValidHand(hand), "IsValidHand() should return true if hand has different cards.");
        }

        [TestMethod]
        public void IsFlushShouldReturnFalse_IfHandIsNotFlush()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            Assert.IsFalse(pokerHandsChecker.IsFlush(hand), "IsFlush() should return false if hand is not flush.");
        }

        [TestMethod]
        public void IsFlushShouldReturnTrue_IfHandIsFlush()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            Assert.IsTrue(pokerHandsChecker.IsFlush(hand), "IsFlush() should return true if hand is flush.");
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnFalse_IfHandIsNotFourOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            Assert.IsFalse(pokerHandsChecker.IsFourOfAKind(hand), "IsFourOfAKind() should return false if hand is not four of a kind.");
        }

        [TestMethod]
        public void IsFourOfAKindShouldReturnTrue_IfHandIsFourOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            Assert.IsTrue(pokerHandsChecker.IsFourOfAKind(hand), "IsFourOfAKind() should return true if hand is four of a kind.");
        }

        [TestMethod]
        public void ComparisonShouldReturnMinusOne_WhenFirstCardFaceIsBigger()
        {
            Card firstCard = new Card(CardFace.Ace, CardSuit.Clubs);
            Card secondCard = new Card(CardFace.Nine, CardSuit.Clubs);
            int compareResult = firstCard.CompareTo(secondCard);

            Assert.IsTrue(compareResult == -1, "Comparison should return -1 when first card face is bigger.");
        }

        [TestMethod]
        public void ComparisonShouldReturnOne_WhenFirstCardFaceIsSmaller()
        {
            Card firstCard = new Card(CardFace.Seven, CardSuit.Clubs);
            Card secondCard = new Card(CardFace.Nine, CardSuit.Clubs);
            int compareResult = firstCard.CompareTo(secondCard);

            Assert.IsTrue(compareResult == 1, "Comparison should return 1 when first card face is smaller.");
        }

        [TestMethod]
        public void ComparisonShouldReturnZero_WhenCardsFacesAreEqual()
        {
            Card firstCard = new Card(CardFace.Nine, CardSuit.Clubs);
            Card secondCard = new Card(CardFace.Nine, CardSuit.Diamonds);
            int compareResult = firstCard.CompareTo(secondCard);

            Assert.IsTrue(compareResult == 0, "Comparison should return 0 when card faces are equal.");
        }

        [TestMethod]
        public void IsStraightShouldReturnTrueIfHandIsStraigth()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
            });
            bool isStraight = pokerHandsChecker.IsStraight(hand);
            Assert.IsTrue(isStraight, "IsStraight() should return true if hand is straight.");
        }

        [TestMethod]
        public void IsStraightShouldReturnFalseIfHandIsNotStraigth()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
            });
            bool isStraight = pokerHandsChecker.IsStraight(hand);
            Assert.IsFalse(isStraight, "IsStraight() should return false if hand is not straight.");
        }

        [TestMethod]
        public void IsStraightFlush_ShouldReturn_False_IfHandIsNotStraightFlush()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
            });

            Assert.IsFalse(pokerHandsChecker.IsStraightFlush(hand), "IsStraightFlush() should return false when hand is not straight flush.");
        }

        [TestMethod]
        public void IsStraightFlush_ShouldReturn_True_IfHandIsStraightFlush()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
            });
            Assert.IsTrue(pokerHandsChecker.IsStraightFlush(hand), "IsStraightFlush() should return true when hand is straight flush.");
        }

        [TestMethod]
        public void IsFullHouse_ShouldReturn_False_IfHandIsNotFullHouse()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
            });

            Assert.IsFalse(pokerHandsChecker.IsFullHouse(hand), "IsFullHouse() should return false when hand is not full house.");
        }

        [TestMethod]
        public void IsFullHouse_ShouldReturn_True_IfHandIsFullHouse()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });
            Assert.IsTrue(pokerHandsChecker.IsFullHouse(hand), "IsFullHouse() should return true when hand is full house.");
        }

        [TestMethod]
        public void IsThreeOfAKind_ShouldReturn_False_IfHandIsNotThreeOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
            });

            Assert.IsFalse(pokerHandsChecker.IsThreeOfAKind(hand), "IsThreeOfAKind() should return false when hand is not ThreeOfAKind.");
        }

        [TestMethod]
        public void IsThreeOfAKind_ShouldReturn_True_IfHandIsThreeOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });
            Assert.IsTrue(pokerHandsChecker.IsThreeOfAKind(hand), "IsThreeOfAKind() should return true when hand is ThreeOfAKind.");
        }

        [TestMethod]
        public void IsTwoPair_ShouldReturn_False_IfHandIsNotTwoPair()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
            });

            Assert.IsFalse(pokerHandsChecker.IsTwoPair(hand), "IsTwoPair() should return false when hand is not TwoPair.");
        }

        [TestMethod]
        public void IsTwoPair_ShouldReturn_True_IfHandIsTwoPair()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });
            Assert.IsTrue(pokerHandsChecker.IsTwoPair(hand), "IsTwoPair() should return true when hand is TwoPair.");
        }

        [TestMethod]
        public void IsOnePair_ShouldReturn_False_IfHandIsNotOnePair()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
            });

            Assert.IsFalse(pokerHandsChecker.IsOnePair(hand), "IsOnePair() should return false when hand is not OnePair.");
        }

        [TestMethod]
        public void IsOnePair_ShouldReturn_True_IfHandIsOnePair()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });
            Assert.IsTrue(pokerHandsChecker.IsOnePair(hand), "IsOnePair() should return true when hand is OnePair.");
        }

        [TestMethod]
        public void IsHighCard_ShouldReturn_True_IfHandIsHighCard()
        {
            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Assert.IsTrue(pokerHandsChecker.IsHighCard(hand), "IsHighCard() should return true when hand is HighCard.");
        }

        [TestMethod]
        public void Compare_HighCards_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are high cards.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnMinusOne_WhenOnlyFirstHand_IsHighCard()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == -1, "CompareHands() should return -1 when only first hand is IsHighCard.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnOne_WhenOnlySecondHand_IsHighCard()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 1, "CompareHands() should return 1 when only second hand is IsHighCard.");
        }

        [TestMethod]
        public void Compare_OnePair_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are OnePair.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnMinusOne_WhenFirstHand_IsOnePair_ButSecondHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == -1, "CompareHands() should return -1 when first hand is OnePair but second hand is higher.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnOne_WhenSecondHand_IsOnePair_ButFirstHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 1, "CompareHands() should return 1 when second hand is OnePair but first hand is higher.");
        }

        [TestMethod]
        public void Compare_TwoPair_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are TwoPair.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnMinusOne_WhenFirstHand_IsTwoPair_ButSecondHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == -1, "CompareHands() should return -1 when first hand is TwoPair but second hand is higher.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnOne_WhenSecondHand_IsTwoPair_ButFirstHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 1, "CompareHands() should return 1 when second hand is TwoPair but first hand is higher.");
        }

        [TestMethod]
        public void Compare_ThreeOfAKind_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are ThreeOfAKind.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnMinusOne_WhenFirstHand_IsThreeOfAKind_ButSecondHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == -1, "CompareHands() should return -1 when first hand is ThreeOfAKind but second hand is higher.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnOne_WhenSecondHand_IsThreeOfAKind_ButFirstHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 1, "CompareHands() should return 1 when second hand is ThreeOfAKind but first hand is higher.");
        }

        [TestMethod]
        public void Compare_Straight_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are Straight.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnMinusOne_WhenFirstHand_IsStraight_ButSecondHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == -1, "CompareHands() should return -1 when first hand is Straight but second hand is higher.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnOne_WhenSecondHand_IsStraight_ButFirstHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 1, "CompareHands() should return 1 when second hand is Straight but first hand is higher.");
        }

        [TestMethod]
        public void Compare_Flush_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are Flush.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnMinusOne_WhenFirstHand_IsFlush_ButSecondHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == -1, "CompareHands() should return -1 when first hand is Flush but second hand is higher.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnOne_WhenSecondHand_IsFlush_ButFirstHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 1, "CompareHands() should return 1 when second hand is Flush but first hand is higher.");
        }

        [TestMethod]
        public void Compare_FullHouse_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are FullHouse.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnMinusOne_WhenFirstHand_IsFullHouse_ButSecondHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == -1, "CompareHands() should return -1 when first hand is FullHouse but second hand is higher.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnOne_WhenSecondHand_IsFullHouse_ButFirstHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 1, "CompareHands() should return 1 when second hand is FullHouse but first hand is higher.");
        }

        [TestMethod]
        public void Compare_FourOfAKind_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are FourOfAKind.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnMinusOne_WhenFirstHand_IsFourOfAKind_ButSecondHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == -1, "CompareHands() should return -1 when first hand is FourOfAKind but second hand is higher.");
        }

        [TestMethod]
        public void CompareCards_ShouldReturnOne_WhenSecondHand_IsFourOfAKind_ButFirstHand_IsHigher()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 1, "CompareHands() should return 1 when second hand is FourOfAKind but first hand is higher.");
        }

        [TestMethod]
        public void Compare_StraightFlush_Hands_ShouldReturnZero()
        {
            IHand firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            IHand secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            int result = pokerHandsChecker.CompareHands(firstHand, secondHand);

            Assert.IsTrue(result == 0, "Should return 0 when both hands are StraightFlush.");
        }
    }
}
