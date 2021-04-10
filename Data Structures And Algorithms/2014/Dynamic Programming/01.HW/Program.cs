using System;
internal class KnapsackProblem
{
    private static void SolveKnapsackProblemNoDuplicatesAllowed(int[] costs, int[] weights, int capacity)
    {
        int len = costs.Length;
        bool[,] isUsed = new bool[capacity + 1, len];
        int[] M = new int[capacity + 1];
        M[0] = 0;

        for (int j = 1; j <= capacity; j++)
        {
            int max1 = M[j - 1];
            int max2 = -999999;
            int mark = 0;
            int candidateUsed = 0;
            for (int i = 0; i < len; i++)
            {
                // Compare the current max. If it is greater
                // then update the current max.
                if (j - weights[i] >= 0 && !isUsed[j - weights[i], i] && costs[i] + M[j - weights[i]] > max2)
                {
                    // Update the max
                    max2 = costs[i] + M[j - weights[i]];
                    // Save the previous (j) position
                    // that gives us the maximum value
                    mark = j - weights[i];
                    // Update the candidate item which
                    // might be put in the knapsack
                    candidateUsed = i;
                }
            }
            //Case1: jth slot is empty
            if (max1 > max2)
            {
                M[j] = max1;
                for (int k = 0; k < len; k++)
                {
                    isUsed[j, k] = isUsed[j - 1, k];
                }
            }
            //Case 2: jth slot is occupied
            else
            {
                M[j] = max2;
                for (int k = 0; k < len; k++)
                {
                    isUsed[j, k] = isUsed[mark, k];
                }
                // mark the candidate as used, which will prevent us
                // from putting it again in the knapsack
                isUsed[j, candidateUsed] = true;
            }
        }
        Console.WriteLine("The maximum we can spend by filling\r\n" +
            "the knapsack with capacity {0} is {1}.", capacity, M[capacity]);
        for (int i = 0; i < len; i++)
        {
            if (isUsed[capacity, i])
            {
                Console.WriteLine("Weight: {0}, Cost: {1}", weights[i], costs[i]);
            }
        }
    }
    private static void Main()
    {
        int[] weight = new int[] { 3, 8, 4, 1, 2, 8 };
        int[] cost = new int[] { 2, 12, 5, 4, 3, 13 };
        int capacity = 10;
        SolveKnapsackProblemNoDuplicatesAllowed(cost, weight, capacity);
    }
}