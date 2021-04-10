namespace HashTableTests
{
    using System;
    using System.Collections.Generic;

    using HashTablesAndSets;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashTableTests
    {
        private static HashTable<string, string> hashTable;
        private static string key1 = "firstKey";
        private static string value1 = "firstValue";
        private static string key2 = "secondKey";
        private static string value2 = "secondValue";
        private static string key3 = "thirdKey";
        private static string value3 = "thirdValue";

        [TestInitialize]
        public void TestInit()
        {
            hashTable = new HashTable<string, string>();
        }

        [TestMethod]
        public void Test_NewHashTable_ShouldHaveInitialCorrectCapacity()
        {
            var hashTableCapacity = hashTable.Capacity;
            var expectedCapacity = 16;
            Assert.AreEqual(expectedCapacity, hashTableCapacity, "New Hash table should initialize with correct capacity!");
        }

        [TestMethod]
        public void Test_NewHashTable_ShouldHaveCorrectCount()
        {
            var hashTableCount = hashTable.Count;
            var expectedCount = 0;
            Assert.AreEqual(expectedCount, hashTableCount, "New Hash table should have correct count!");
        }

        [TestMethod]
        public void Test_Add_ShouldIncreaseCount()
        {
            hashTable.Add(key1, value1);
            var hashTableCount = hashTable.Count;
            var expectedCount = 1;
            Assert.AreEqual(expectedCount, hashTableCount, "Hash table should increase count when adding!");
        }

        [TestMethod]
        public void Test_Add_ShouldIncreaseCapacityWhenNeeded()
        {
            hashTable = new HashTable<string, string>(4);
            var initialCapacity = hashTable.Capacity;
            hashTable.Add(key1, value1);
            hashTable.Add(key2, value2);
            hashTable.Add(key3, value3);
            var currentCapacity = hashTable.Capacity;
            var expectedCapacity = initialCapacity * 2;
            Assert.AreEqual(expectedCapacity, currentCapacity, "Hash table should increase capacity when range exceeded!");
        }

        [TestMethod]
        public void Test_Add_ShouldAddCorrect()
        {
            hashTable.Add(key1, value1);
            hashTable.Add(key2, value2);
            hashTable.Add(key3, value3);
            var expectedCount = 3;
            var expectedCapacity = 16;
            var actualCount = hashTable.Count;
            var actualCapacity = hashTable.Capacity;
            var firstIsAdded = hashTable.ContainesKey(key1);
            var secondIsAdded = hashTable.ContainesKey(key2);
            var thirdIsAdded = hashTable.ContainesKey(key3);
            Assert.IsTrue(
                expectedCount == actualCount &&
                expectedCapacity == actualCapacity &&
                firstIsAdded && 
                secondIsAdded && 
                thirdIsAdded, 
                "Hash table should add correct!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Add_ShouldThrowWhenAddingSameKey()
        {
            hashTable.Add(key1, value1);
            hashTable.Add(key1, value2);
        }

        [TestMethod]
        public void Test_Clear_ShouldClearCountOnClear()
        {
            hashTable.Add(key1, key2);
            hashTable.Clear();
            var hashTableCount = hashTable.Count;
            var expectedCount = 0;
            Assert.AreEqual(expectedCount, hashTableCount, "Hash table should clear count when on Clear()!");
        }

        [TestMethod]
        public void Test_Keys_ShouldReturnKeys()
        {
            hashTable.Add(key1, value1);
            hashTable.Add(key2, value2);
            var keys = hashTable.Keys();
            var isFirstKey = false;
            var isSecondKey = false;
            foreach (var key in keys)
            {
                if (key == key1)
                {
                    isFirstKey = true;
                }
                else if (key == key2)
                {
                    isSecondKey = true;
                }
            }

            Assert.IsTrue(isFirstKey && isSecondKey, "Hash table should return keys!");
        }

        [TestMethod]
        public void Test_Index_ShouldReturnValue()
        {
            hashTable.Add(key1, value1);
            var returnedValue = hashTable[key1];
            Assert.IsTrue(value1.Equals(returnedValue), "Hash table index should return correct value");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Index_GetShouldThrowWhenEmpty()
        {
            var returnedValue = hashTable[key1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Index_ShouldThrowExceptionIfRemoved()
        {
            hashTable.Add(key1, value1);
            hashTable.Remove(key1);
            var returnedValue = hashTable[key1];
        }

        [TestMethod]
        public void Test_Index_ShouldSetValue()
        {
            hashTable[key1] = value1;
            var returnedValue = hashTable[key1];
            Assert.AreEqual(value1, returnedValue, "Hash table index should set correct value");
        }

        [TestMethod]
        public void Test_Index_SetterShouldReplaceWhenExistingKey()
        {
            var expectedValue = "newValue";
            hashTable[key1] = value1;
            hashTable[key1] = expectedValue;
            var returnedValue = hashTable[key1];
            Assert.AreEqual(expectedValue, returnedValue, "Hash table index setter should replace value correct");
        }

        [TestMethod]
        public void Test_Enumerator_ShouldIterateAll()
        {
            hashTable.Add(key1, value1);
            hashTable.Add(key2, value2);
            var hasFirst = false;
            var hasSecond = false;
            foreach (KeyValuePair<string, string> item in hashTable)
            {
                if (item.Key == key1 && item.Value == value1)
                {
                    hasFirst = true;
                }
                else if (item.Key == key2 && item.Value == value2)
                {
                    hasSecond = true;
                }
            }

            Assert.IsTrue(hasFirst && hasSecond, "Hash table should iterate all!");
        }

        [TestMethod]
        
        public void Test_Enumerator_Should_Not_Throw_When_Empty()
        {
            foreach (KeyValuePair<string, string> item in hashTable)
            {
            }
        }

        [TestMethod]
        public void Test_Remove_ShouldDecreaseCount()
        {
            hashTable.Add(key1, value1);
            var isRemoved = hashTable.Remove(key1);
            var expectedCount = 0;
            var actualCount = hashTable.Count;
            Assert.IsTrue(isRemoved && expectedCount == actualCount, "Hash table remove should decrease count.");
        }

        [TestMethod]
        public void Test_Remove_NoShouldNotChangeCount()
        {
            hashTable.Add(key1, value1);
            hashTable.Add(key2, value2);
            var isRemoved = hashTable.Remove(key3);
            var expectedCount = 2;
            var actualCount = hashTable.Count;
            Assert.IsTrue(isRemoved == false && expectedCount == actualCount, "Hash table remove should not decrease count if not removed.");
        }

        [TestMethod]
        public void Test_Remove_ShouldReturnFalseIfNotContained()
        {
            hashTable.Add(key1, value1);
            hashTable.Remove(key1);
            var isRemoved = hashTable.Remove(key1);
            Assert.IsFalse(isRemoved, "Hash table remove should return false if not contained.");
        }

        [TestMethod]
        public void Test_Remove_ShouldReturnTrueWhenRemoved()
        {
            hashTable.Add(key1, value1);
            var isRemoved = hashTable.Remove(key1);
            Assert.IsTrue(isRemoved, "Hash table remove should return true when removed.");
        }

        [TestMethod]
        public void Test_Find_ShouldReturnNullIfNotFound()
        {
            hashTable.Add(key1, value1);
            var result = hashTable.Find(key2);
            Assert.IsNull(result, "Hash table find() should return false when not found.");
        }

        [TestMethod]
        public void Test_Find_ShouldReturnNullWhenEmpty()
        {
            var result = hashTable.Find(key1);
            Assert.IsNull(result, "Hash table find() should return null when empty.");
        }

        [TestMethod]
        public void Test_Find_ShouldReturnNullWhenRemoved()
        {
            hashTable.Add(key1, value1);
            hashTable.Remove(key1);
            var result = hashTable.Find(key1);
            Assert.IsNull(result, "Hash table find() should return null when removed.");
        }

        [TestMethod]
        public void Test_Find_ShouldReturnKeyValuePairIfFound()
        {
            hashTable.Add(key1, value1);
            var result = hashTable.Find(key1);
            Assert.IsTrue(result.HasValue && result.Value.Key.Equals(key1) && result.Value.Value.Equals(value1), "Hash table find() should return keyValuePair when found.");
        }

        [TestMethod]
        public void Test_Find_ShouldReturnEqualKeyValuePair()
        {
            hashTable.Add(key1, value1);
            var result = hashTable.Find(key1);
            var pair = new KeyValuePair<string, string>(key1, value1);
            Assert.IsTrue(pair.Key.Equals(key1), "Hash table find() should return equal keyValue when found.");
        }

        [TestMethod]
        public void Test_Find_ShouldReturnEqualKeyValue()
        {
            hashTable.Add(key1, value1);
            var result = hashTable.Find(key1);
            var pair = new KeyValuePair<string, string>(key1, value1);
            Assert.IsTrue(pair.Equals(result), "Hash table find() should return equal key when found.");
        }

        [TestMethod]
        public void Test_ContaineKey_ShouldReturnTrueIfFound()
        {
            hashTable.Add(key1, value1);
            var isContained = hashTable.ContainesKey(key1);
            Assert.IsTrue(isContained, "Hash table ContainesKey() should return true when contained.");
        }

        [TestMethod]
        public void Test_ContaineKey_ShouldReturnFalseNotIfFound()
        {
            var isContained = hashTable.ContainesKey(key1);
            Assert.IsFalse(isContained, "Hash table ContainesKey() should return false when not contained.");
        }
    }
}
