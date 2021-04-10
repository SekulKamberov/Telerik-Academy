using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "beer", "vodka", "cheese", "nuts", "ham", "whiskey" };
            int[] weights = { 3, 8, 4, 1, 2, 8 };
            int[] costs = { 2, 12, 5, 4, 3, 13 };
            int[] numbers = {3, 2, 5, 3 };
            int capacity = 10;

            var maxSubsets = CalculateMaxCapacitySubset(names, weights, costs, capacity);
            Console.WriteLine(maxSubsets);
        }

        private static string CalculateMaxCapacitySubset(string[] names, int[] weights, int[] costs, int capacity)
        {
            int maxWeight = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                maxWeight += weights[i];
            }
            var length = maxWeight + 1;
            bool[] possibleWeight = new bool[length];
            int[] possibleCostSum = new int[length];
            string[] possibleNamesSum = new string[length];
            int[] possibleWeightSum = new int[length];

            possibleWeight[0] = true;

            int currentMaxSum = 0;
            int currentMinSum = 0;
            int currentMinSumWithNumber;
            int currentMaxSumWithNumber;

            for (int j = 0; j < weights.Length; j++)
            {

                currentMaxSumWithNumber = currentMaxSum;
                currentMinSumWithNumber = currentMinSum;

                for (int i = currentMaxSum; i >= currentMinSum; i--)
                {
                    if (possibleWeight[i])
                    {
                        if (currentMinSumWithNumber > i + weights[j])
                        {
                            currentMinSumWithNumber = i + weights[j];
                        }

                        if (currentMaxSumWithNumber < i + weights[j])
                        {
                            currentMaxSumWithNumber = i + weights[j];
                        }

                        if (i == 0)
                        {
                            var index = weights[j];
                            if (possibleWeightSum[index] == 0)
                            {
                                possibleWeightSum[index] = weights[j];
                                possibleNamesSum[index] = names[j];
                                possibleCostSum[index] = costs[j];
                            }
                            else if (possibleWeightSum[index] + weights[j] < capacity)
                            {
                                possibleWeightSum[index] += weights[j];
                                possibleNamesSum[index] += " " + names[j];
                                possibleCostSum[index] += costs[j];
                            }
                            else if (possibleWeightSum[index] < weights[j])
                            {
                                possibleWeightSum[index] = weights[j];
                                possibleNamesSum[index] = names[j];
                                possibleCostSum[index] = costs[j];
                            }

                            possibleWeight[index] = true;
                        }
                        else
                        {
                            var baseW = possibleWeightSum[i];
                            var baseC = possibleCostSum[i];
                            var baseN = possibleNamesSum[i];

                            var index = i + weights[j];

                            var currentW = possibleWeightSum[index];
                            var currentC = possibleCostSum[index];
                            var currentN = possibleNamesSum[index];

                            if (baseW + weights[j] < capacity && baseW + weights[j] > currentW)
                            {
                                possibleWeightSum[index] = baseW + weights[j];
                                possibleCostSum[index] = baseC + costs[j];
                                possibleNamesSum[index] = baseN + " " + names[j];

                                possibleWeight[index] = true;
                            }

                        }
                    }
                }

                currentMinSum = currentMinSumWithNumber;
                currentMaxSum = currentMaxSumWithNumber;
            }

            for (int i = 0; i < possibleNamesSum.Length; i++)
            {
                Console.WriteLine("Name: {0}, Weight: {1}, Cost: {2}", possibleNamesSum[i], possibleWeightSum[i], possibleCostSum[i]);
            }

            string winnersNames = string.Empty;
            int winnersWeight = 0;
            int winnersCost = 0;

            for (int i = 0; i < possibleNamesSum.Length; i++)
            {
                var weight = possibleWeightSum[i];
                if (weight < capacity && weight > winnersWeight)
                {
                    winnersWeight = weight;
                    winnersCost = possibleCostSum[i];
                    winnersNames = possibleNamesSum[i];
                }
            }

            return string.Format("Name: {0}, Weight: {1}, Cost: {2}", winnersNames, winnersWeight, winnersCost);
        }
    }
}
