namespace PriorityQueueTests
{
    using System;
    using AdvancedDataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PriorityQueueTests
    {
        private static Random random = new Random();
        private static string chars = "abcdef";
        private static char letter1 = 'A';
        private static char letter2 = 'B';
        private static char letter3 = 'C';
        private static char letter4 = 'D';
        private static char letter5 = 'E';
        private PriorityQueue<char> priorityQueue;

        [TestInitialize]
        public void Init()
        {
            this.priorityQueue = new PriorityQueue<char>();
        }

        [TestMethod]
        public void Test_Constructor_ShouldSetDefaultCapacity()
        {
            var expectedCapacity = 16;
            var actualCapacity = this.priorityQueue.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity, "Default Constructor should set capacity to 16.");
        }

        [TestMethod]
        public void Test_Constructor_ShouldSetCapacity()
        {
            var expectedCapacity = 4;
            this.priorityQueue = new PriorityQueue<char>(expectedCapacity);
            var actualCapacity = this.priorityQueue.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity, "Constructor should set capacity to correctly.");
        }

        [TestMethod]
        public void Test_Enqueue_ShouldIncreaseCapacity()
        {
            var expectedCapacity = 32;
            for (int i = 0; i < 16; i++)
            {
                this.priorityQueue.Enqueue((char)i);
            }

            var actualCapacity = this.priorityQueue.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity, "Enqueue should increase capacity.");
        }

        [TestMethod]
        public void Test_Constructor_ShouldSetCount()
        {
            var expectedCount = 0;
            var actualCount = this.priorityQueue.Count;
            Assert.AreEqual(expectedCount, actualCount, "Constructor should set count to 0.");
        }

        [TestMethod]
        public void Test_Enqueue_ShouldIncreaseCount()
        {
            this.priorityQueue.Enqueue(letter1);
            var expectedCount = 1;
            var actualCount = this.priorityQueue.Count;
            Assert.AreEqual(expectedCount, actualCount, "Enqueue should encrease count.");
        }

        [TestMethod]
        public void Test_Dequeue_ShouldDecreaseCount()
        {
            this.priorityQueue.Enqueue(letter1);
            this.priorityQueue.Enqueue(letter1);
            this.priorityQueue.Enqueue(letter1);
            this.priorityQueue.Enqueue(letter1);
            this.priorityQueue.Dequeue();
            var actualCount = this.priorityQueue.Count;
            var expectedCount = 3;
            Assert.AreEqual(expectedCount, actualCount, "Enqueue should decrease count.");
        }

        [TestMethod]
        public void Test_Enqueue_ShouldAddItem()
        {
            this.priorityQueue.Enqueue(letter1);
            char actualLetter = this.priorityQueue.Dequeue();
            Assert.AreEqual(letter1, actualLetter, "Enqueue should add letter.");
        }

        [TestMethod]
        public void Test_DefaultComparer_ShouldSetPriorityAscending()
        {
            this.priorityQueue.Enqueue(letter3);
            this.priorityQueue.Enqueue(letter2);
            this.priorityQueue.Enqueue(letter1);
            this.priorityQueue.Enqueue(letter5);
            this.priorityQueue.Enqueue(letter4);
            var expectedLetter = 'A';
            char actualLetter = this.priorityQueue.Dequeue();
            Assert.AreEqual(expectedLetter, actualLetter, "Default comparer should set priority ascending.");
        }

        [TestMethod]
        public void Test_DefaultComparer_ShouldSetPriorityAscendingBiggetGoesOutLast()
        {
            this.priorityQueue.Enqueue(letter3);
            this.priorityQueue.Enqueue(letter2);
            this.priorityQueue.Enqueue(letter1);
            this.priorityQueue.Enqueue(letter5);
            this.priorityQueue.Enqueue(letter4);
            var expectedLetter = 'E';
            this.priorityQueue.Dequeue();
            this.priorityQueue.Dequeue();
            this.priorityQueue.Dequeue();
            this.priorityQueue.Dequeue();
            char actualLetter = this.priorityQueue.Dequeue();
            Assert.AreEqual(expectedLetter, actualLetter, "Default comparer should set priority ascending, biggest should go out last.");
        }

        [TestMethod]
        public void Test_Dequeue_ShouldLeaveBiggestItemLast()
        {
            var pq = new PriorityQueue<int>();
            int count = 100000;
            var max = int.MinValue;
            for (int i = 0; i < count; i++)
            {
                var randomNumber = random.Next(0, count * 10);
                pq.Enqueue(randomNumber);
                if (max < randomNumber)
                {
                    max = randomNumber;
                }
            }

            for (int i = 0; i < count - 1; i++)
            {
                var dequeuedNumber = pq.Dequeue();
            }

            var actual = pq.Dequeue();
            Assert.AreEqual(max, actual, "Dequeue should leave biggest item last.");
        }

        [TestMethod]
        public void Test_ToString_ShouldReturnCorrectString()
        {
            var pq = new PriorityQueue<int>();
            pq.Enqueue(52);
            pq.Enqueue(2);
            pq.Enqueue(1);
            pq.Enqueue(34);
            var expected = "1, 34, 2, 52\nCount: 4\nCapacity: 16\n----------------------";
            var actual = pq.ToString();
            Assert.AreEqual(expected, actual, "To string should return correct string");
        }

        [TestMethod]
        public void Test_ComprarerParam_ShouldCompareProperly()
        {
            var comparer = new StringComparerDescending();
            var pq = new PriorityQueue<string>(comparer);
            int count = 100;
            var min = "zzzzzzzzzz";
            for (int i = 0; i < count; i++)
            {
                var randomString = this.GetRandomString(10);
                pq.Enqueue(randomString);
                if (min.CompareTo(randomString) > 0)
                {
                    min = randomString;
                }
            }

            for (int i = 0; i < count - 1; i++)
            {
                var dequeuedNumber = pq.Dequeue();
            }

            var actual = pq.Dequeue().ToString();
            Assert.AreEqual(min, actual, "Comparer param should work properly.");
        }

        private string GetRandomString(int length)
        {
            var generatedChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                var randomIndex = random.Next(0, chars.Length);
                generatedChars[i] = chars[randomIndex];
            }

            return new string(generatedChars);
        }
    }
}
