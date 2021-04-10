namespace SubsetsSumTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SubsetSums;

    [TestClass]
    public class SubsetsTests
    {
        private static bool areSubsetsSumsEqual;

        [TestMethod]
        public void Test_NegativeAndPossitiveNumbersPermutations_ShouldReturnSame_SubsetsSums()
        {
            int[] numbers = new int[] { -100, -50, -1, -1, 0, 1, 1, 2, 70 };
            List<int> expectedNegativeAndPossitiveNumbersSubsetSums = new List<int>()
            { 
                -152, -151, -150, -149, -148, -147, -146, -102, -101, -100, -99, -98, -97, -96, -82, -81, -80, -79, -78, -77, -76, -52, -51, -50, -49, -48, -47, -46, -32, -31, -30, -29, -28, -27, -26, -2, -1, 0, 1, 2, 3, 4, 18, 19, 20, 21, 22, 23, 24, 68, 69, 70, 71, 72, 73, 74
            };

            areSubsetsSumsEqual = true;
            GeneratePermutationsForNegativeAndPossitive(numbers, 0, expectedNegativeAndPossitiveNumbersSubsetSums);
            Assert.IsTrue(areSubsetsSumsEqual, "Negative and possitive numbers permutations should return same subsets sums.");
        }

        [TestMethod]
        public void Test_NegativeAndPossitiveNumbersPermutations_ShouldReturnSame_SubsetsSums_WithZeroWhenPossible()
        {
            int[] numbers = new int[] { -100, -50, -1, -1, 1, 1, 2, 70 };
            List<int> expectedNegativeAndPossitiveNumbersSubsetSums = new List<int>()
            { 
                -152, -151, -150, -149, -148, -147, -146, -102, -101, -100, -99, -98, -97, -96, -82, -81, -80, -79, -78, -77, -76, -52, -51, -50, -49, -48, -47, -46, -32, -31, -30, -29, -28, -27, -26, -2, -1, 0, 1, 2, 3, 4, 18, 19, 20, 21, 22, 23, 24, 68, 69, 70, 71, 72, 73, 74
            };

            areSubsetsSumsEqual = true;
            GeneratePermutationsForNegativeAndPossitive(numbers, 0, expectedNegativeAndPossitiveNumbersSubsetSums);
            Assert.IsTrue(areSubsetsSumsEqual, "Negative and possitive numbers permutations should return same subsets sums with zero when possible.");
        }

        [TestMethod]
        public void Test_NegativeAndPossitiveNumbersPermutations_ShouldReturnSame_SubsetsSums_WithoutZero()
        {
            int[] numbers = new int[] { -100, -50, -25, -1, 2, 15, 90 };
            List<int> expectedNegativeAndPossitiveNumbersSubsetSums = new List<int>()
            { 
                -176, -175, -174, -173, -161, -160, -159, -158, -151, -150, -149, -148, -136, -135, -134, -133, -126, -125, -124, -123, -111, -110, -109, -108, -101, -100, -99, -98, -86, -85, -84, -83, -76, -75, -74, -73, -71, -70, -69, -68, -61, -60, -59, -58, -51, -50, -49, -48, -46, -45, -44, -43, -36, -35, -34, -33, -26, -25, -24, -23, -21, -20, -19, -18, -11, -10, -9, -8, -1, 1, 2, 4, 5, 6, 7, 14, 15, 16, 17, 29, 30, 31, 32, 39, 40, 41, 42, 54, 55, 56, 57, 64, 65, 66, 67, 79, 80, 81, 82, 89, 90, 91, 92, 104, 105, 106, 107
            };

            areSubsetsSumsEqual = true;
            GeneratePermutationsForNegativeAndPossitive(numbers, 0, expectedNegativeAndPossitiveNumbersSubsetSums);
            Assert.IsTrue(areSubsetsSumsEqual, "Negative and possitive numbers permutations should return same subsets sums without zero.");
        }

        [TestMethod]
        public void Test_PossitiveNumbersPermutations_ShouldReturnSame_SubsetsSums()
        {
            int[] positiveNumbers = new int[] { 0, 1, 7, 3, 11, 44 };
            List<int> expectedSubsetSums = new List<int>()
            { 
                0, 1, 3, 4, 7, 8, 10, 11, 12, 14, 15, 18, 19, 21, 22, 44, 45, 47, 48, 51, 52, 54, 55, 56, 58, 59, 62, 63, 65, 66
            };

            areSubsetsSumsEqual = true;
            GeneratePermutationsForNegativeAndPossitive(positiveNumbers, 0, expectedSubsetSums);
            Assert.IsTrue(areSubsetsSumsEqual, "Numbers permutations should return same subsets sums.");
        }

        [TestMethod]
        public void Test_PossitiveNumbersPermutations_ShouldReturnSame_SubsetsSums_WithoutZero()
        {
            int[] positiveNumbers = new int[] { 1, 7, 3, 11, 44 };
            List<int> expectedSubsetSums = new List<int>()
            { 
                1, 3, 4, 7, 8, 10, 11, 12, 14, 15, 18, 19, 21, 22, 44, 45, 47, 48, 51, 52, 54, 55, 56, 58, 59, 62, 63, 65, 66
            };

            areSubsetsSumsEqual = true;
            GeneratePermutationsForNegativeAndPossitive(positiveNumbers, 0, expectedSubsetSums);
            Assert.IsTrue(areSubsetsSumsEqual, "Numbers permutations should return same subsets sums without zero.");
        }

        private static void GeneratePermutationsForNegativeAndPossitive(int[] arr, int k, IList<int> expectedSubsetsSums)
        {
            if (k >= arr.Length)
            {
                var subsetSums = SubsetsSumEvaluator.FindPossibleSumsWithNegative(arr);
                var areEqual = AreListsOfIntegersEqual(subsetSums, expectedSubsetsSums);
                if (areEqual == false)
                {
                    areSubsetsSumsEqual = false;
                }
            }
            else
            {
                GeneratePermutationsForNegativeAndPossitive(arr, k + 1, expectedSubsetsSums);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutationsForNegativeAndPossitive(arr, k + 1, expectedSubsetsSums);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void GeneratePermutationsForPossitiveNumbers(int[] arr, int k, IList<int> expectedSubsetsSums)
        {
            if (k >= arr.Length)
            {
                var subsetSums = SubsetsSumEvaluator.FindPossibleSumsWithNegative(arr);
                var areEqual = AreListsOfIntegersEqual(subsetSums, expectedSubsetsSums);
                if (areEqual == false)
                {
                    areSubsetsSumsEqual = false;
                }
            }
            else
            {
                GeneratePermutationsForPossitiveNumbers(arr, k + 1, expectedSubsetsSums);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutationsForPossitiveNumbers(arr, k + 1, expectedSubsetsSums);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            int oldFirst = first;
            first = second;
            second = oldFirst;
        }

        private static bool AreListsOfIntegersEqual(IList<int> firstList, IList<int> secondList)
        {
            if (firstList.Count != secondList.Count)
            {
                return false;
            }

            for (int i = 0; i < firstList.Count; i++)
            {
                if (firstList[i] != secondList[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
