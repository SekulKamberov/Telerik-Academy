namespace SortingAlgorithmsTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingAlgorithms;

    [TestClass]
    public class SortersTests
    {
        private static SortableCollection<int> collection;
        private static Random random = new Random();
        private static int minRange = 0;
        private static int maxRange = 100;
        private static int collectionLength = 100;

        [TestInitialize]
        public void InitMethod()
        {
            collection = GenerateList(collectionLength);
        }

        [TestMethod]
        public void Test_SelectionSorter_ShouldSortCorrectly()
        {
            var selectionSorter = new SelectionSorter<int>();
            collection.Sort(selectionSorter);

            bool isSortedCorrectly = true;
            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                if (collection.Items[i].CompareTo(collection.Items[i + 1]) > 0)
                {
                    isSortedCorrectly = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrectly, "SelectionSorter should sort correctly.");
        }

        [TestMethod]
        public void Test_QuickSorter_ShouldSortCorrectly()
        {
            var quickSorter = new QuickSorter<int>();
            collection.Sort(quickSorter);

            bool isSortedCorrectly = true;
            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                if (collection.Items[i].CompareTo(collection.Items[i + 1]) > 0)
                {
                    isSortedCorrectly = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrectly, "QuickSorter should sort correctly.");
        }

        [TestMethod]
        public void Test_MergeSorter_ShouldSortCorrectly()
        {
            var mergeSorter = new MergeSorter<int>();
            collection.Sort(mergeSorter);

            bool isSortedCorrectly = true;
            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                if (collection.Items[i].CompareTo(collection.Items[i + 1]) > 0)
                {
                    isSortedCorrectly = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrectly, "MergeSorter should sort correctly.");
        }

        [TestMethod]
        public void Test_InsertionSorter_ShouldSortCorrectly()
        {
            var insertionSorter = new InsertionSorter<int>();
            collection.Sort(insertionSorter);

            bool isSortedCorrectly = true;
            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                if (collection.Items[i].CompareTo(collection.Items[i + 1]) > 0)
                {
                    isSortedCorrectly = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrectly, "InsertionSorter should sort correctly.");
        }

        [TestMethod]
        public void Test_MergeInsertionSorter_ShouldSortCorrectly()
        {
            var mergeInsertionSorter = new MergeInsertionSorter<int>();
            collection.Sort(mergeInsertionSorter);

            bool isSortedCorrectly = true;
            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                if (collection.Items[i].CompareTo(collection.Items[i + 1]) > 0)
                {
                    isSortedCorrectly = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrectly, "MergeInsertionSorter should sort correctly.");
        }

        [TestMethod]
        public void Test_UpgradedSelectionSorter_ShouldSortCorrectly()
        {
            var upgradedSelectionSorter = new UpgradedSelectionSorter<int>();
            collection.Sort(upgradedSelectionSorter);

            bool isSortedCorrectly = true;
            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                if (collection.Items[i].CompareTo(collection.Items[i + 1]) > 0)
                {
                    isSortedCorrectly = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrectly, "UpgradedSelectionSorter should sort correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_SelectionSorter_ShouldThrowExceptionWhenCollectionIsNull()
        {
            var sorter = new SelectionSorter<int>();
            var emptyCollection = new SortableCollection<int>(null);
            emptyCollection.Sort(sorter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_InsertionSorter_ShouldThrowExceptionWhenCollectionIsNull()
        {
            var sorter = new InsertionSorter<int>();
            var emptyCollection = new SortableCollection<int>(null);
            emptyCollection.Sort(sorter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_MergeInsertionSorter_ShouldThrowExceptionWhenCollectionIsNull()
        {
            var sorter = new MergeInsertionSorter<int>();
            var emptyCollection = new SortableCollection<int>(null);
            emptyCollection.Sort(sorter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_MergeSorter_ShouldThrowExceptionWhenCollectionIsNull()
        {
            var sorter = new MergeSorter<int>();
            var emptyCollection = new SortableCollection<int>(null);
            emptyCollection.Sort(sorter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_QuickSorter_ShouldThrowExceptionWhenCollectionIsNull()
        {
            var sorter = new QuickSorter<int>();
            var emptyCollection = new SortableCollection<int>(null);
            emptyCollection.Sort(sorter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_UpgradedSelectionSorter_ShouldThrowExceptionWhenCollectionIsNull()
        {
            var sorter = new UpgradedSelectionSorter<int>();
            var emptyCollection = new SortableCollection<int>(null);
            emptyCollection.Sort(sorter);
        }

        [TestMethod]
        public void Test_SelectionSorter_ShouldSwapCorrectly()
        {
            var selectionSorter = new SelectionSorter<int>();
            var smallCollection = new SortableCollection<int>(new List<int>() { 4, 2 });
            smallCollection.Sort(selectionSorter);
            bool isSortedCorrectly = smallCollection.Items[0] == 2 && smallCollection.Items[1] == 4;

            Assert.IsTrue(isSortedCorrectly, "SelectionSorter should sort correctly.");
        }

        [TestMethod]
        public void Test_SelectionSorter_ShouldNotSwapWhenCollectionIsSorted()
        {
            var selectionSorter = new SelectionSorter<int>();
            var smallCollection = new SortableCollection<int>(new List<int>() { 2, 4 });
            smallCollection.Sort(selectionSorter);
            bool isSortedCorrectly = smallCollection.Items[0] == 2 && smallCollection.Items[1] == 4;

            Assert.IsTrue(isSortedCorrectly, "SelectionSorter should not swap when collection is sorted.");
        }

        [TestMethod]
        public void Test_SelectionSorter_OneElementCollectionShouldBeStable()
        {
            var selectionSorter = new SelectionSorter<int>();
            var smallCollection = new SortableCollection<int>(new List<int>() { 4 });
            smallCollection.Sort(selectionSorter);
            bool isSortedCorrectly = smallCollection.Items[0] == 4;

            Assert.IsTrue(isSortedCorrectly, "SelectionSorter should be stable on sorting 1 element.");
        }

        [TestMethod]
        public void Test_SelectionSorter_ShouldSortCorrectlyForAnyTipe()
        {
            var selectionSorter = new SelectionSorter<string>();
            var stringCollection = new SortableCollection<string>(new List<string>() { "b", "c", "a" });
            stringCollection.Sort(selectionSorter);

            bool isSortedCorrectly = true;
            for (int i = 0; i < stringCollection.Items.Count - 1; i++)
            {
                if (stringCollection.Items[i].CompareTo(stringCollection.Items[i + 1]) > 0)
                {
                    isSortedCorrectly = false;
                    break;
                }
            }

            Assert.IsTrue(isSortedCorrectly, "SelectionSorter should sort correctly for any Type.");
        }

        private static SortableCollection<int> GenerateList(int length)
        {
            var collection = new SortableCollection<int>();
            for (int i = 0; i < length; i++)
            {
                collection.Items.Add(GetRandomNumber());
            }

            return collection;
        }

        private static int GetRandomNumber()
        {
            return random.Next(minRange, maxRange);
        }
    }
}
