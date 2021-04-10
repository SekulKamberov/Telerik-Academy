namespace HashSetTests
{
    using System;
    using HashTablesAndSets;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashSetTests
    {
        private static Hashset<int> data;
        private static int key1 = 1;
        private static int key2 = 2;
        private static int key3 = 3;
        private static int key4 = 4;

        [TestInitialize]
        public void TestInit()
        {
            data = new Hashset<int>();
        }

        [TestMethod]
        public void Test_Init_ShouldHaveCorrectInitialCapacity()
        {
            var expectedCapacity = 16;
            var actualCapacity = data.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity, "Hashset should have correct initial capacity!");
        }

        [TestMethod]
        public void Test_Add_ShouldIncreaseCapacityWhenRangeIsMet()
        {
            data = new Hashset<int>(4);
            data.Add(key1);
            data.Add(key2);
            data.Add(key3);
            data.Add(key4);
            var expectedCapacity = 8;
            var actualCapacity = data.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity, "Hashset should increase capacity when range is met!");
        }

        [TestMethod]
        public void Test_Clear_ShouldEmptyAndSetCountToZero()
        {
            data = new Hashset<int>(4);
            data.Add(key1);
            data.Clear();
            var expectedCount = 0;
            var actualCount = data.Count;
            Assert.AreEqual(expectedCount, actualCount, "Hashset should increase capacity when range is met!");
        }

        [TestMethod]
        public void Test_Containes_ShouldReturnTrueWhenContained()
        {
            data = new Hashset<int>(4);
            data.Add(key1);
            data.Add(key2);
            data.Add(key3);
            var isContained = data.Containes(key2);
            Assert.IsTrue(isContained, "Hashset Containes should true when contained.");
        }

        [TestMethod]
        public void Test_Fine_ShouldKeyWhenContained()
        {
            data = new Hashset<int>(4);
            data.Add(key1);
            data.Add(key2);
            data.Add(key3);
            var keyFound = data.Find(key2);
            Assert.AreEqual(key2, keyFound, "Hashset Find should return key.");
        }

        [TestMethod]
        public void Test_Remove_ShouldRemoveAndDecreaseCount()
        {
            data = new Hashset<int>(4);
            data.Add(key1);
            data.Add(key2);
            data.Add(key3);
            data.Remove(key2);
            var expectedCount = 2;
            var actualCount = data.Count;
            Assert.AreEqual(expectedCount, actualCount, "Hashset should decrease count when removed!");
        }

        [TestMethod]
        public void Test_Union_ShouldHaveUniqueKeys()
        {
            data = new Hashset<int>(4);
            data.Add(key1);
            data.Add(key2);

            var secondHashSet = new Hashset<int>();
            secondHashSet.Add(key2);
            secondHashSet.Add(key3);
            var unionSet = data.Union(secondHashSet);
            var expectedCount = 3;
            var actualCount = unionSet.Count;
            Assert.IsTrue(
                expectedCount == actualCount &&
                unionSet.Containes(key1) &&
                unionSet.Containes(key2) && 
                unionSet.Containes(key3), 
                "Hashset union should have uniqie keys and correct count.");
        }

        [TestMethod]
        public void Test_Intersect_ShouldAddOnlyKeysContainedInBothSets()
        {
            data = new Hashset<int>(4);
            data.Add(key1);
            data.Add(key2);
            var secondHashSet = new Hashset<int>();
            secondHashSet.Add(key2);
            secondHashSet.Add(key3);
            var intersectSet = data.Intersect(secondHashSet);
            var expectedCount = 1;
            var actualCount = intersectSet.Count;
            Assert.IsTrue(
                expectedCount == actualCount &&
                intersectSet.Containes(key2),
                "Hashset intersect should add only keys contained in both hasjsets.");
        }
    }
}
