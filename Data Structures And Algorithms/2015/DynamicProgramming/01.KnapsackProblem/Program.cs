namespace _01.KnapsackProblem
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            // int n = 6;            
            int[] weights = new int[] { 3, 8, 4, 1, 2, 8 };
            int[] costs = new int[] { 2, 12, 5, 4, 3, 13 };
            int maxWeight = 10;
            FindHighestCostAndWeightBagNoDuplicates(weights, costs, maxWeight);

            Product[] products = new Product[] 
            {
                new Product("Beer", 3, 2),
                new Product("Vodka", 8, 12),
                new Product("Трошия", 4, 7),
                new Product("Nuts", 1, 4),
                new Product("Сланина", 3, 6),
                new Product("Whiskey", 8, 13),
                new Product("Ракия", 3, 5),
            };
            FindHighestCostAndWeightBagNoDuplicates(products, maxWeight);

            maxWeight = 23;
            products = new Product[] 
            {
                new Product("Трошия", 6, 6),
                new Product("Сланина", 8, 7),
                new Product("Ракия", 7, 7),
            };
            FindHighestCostAndWeightBagWithDuplicates(products, maxWeight);
        }
                
        private static void FindHighestCostAndWeightBagNoDuplicates(int[] weights, int[] costs, int maxBasketWeight)
        {
            if (weights.Length != costs.Length)
            {
                throw new ArgumentException("Weights and costs length should be equal!");
            }

            bool[] possibleWeights = new bool[maxBasketWeight + 1];
            int[] possibleCosts = new int[maxBasketWeight + 1];
            possibleWeights[0] = true;
            int maxWeight = 0;
            int tempMaxWeight = 0;
            int maxCostIndex = 0;

            for (int j = 0; j < weights.Length; j++)
            {
                for (int i = maxWeight; i >= 0; i--)
                {
                    if (possibleWeights[i])
                    {
                        var currentWeight = i + weights[j];
                        if (currentWeight > maxBasketWeight)
                        {
                            continue;
                        }

                        if (tempMaxWeight < currentWeight)
                        {
                            tempMaxWeight = currentWeight;
                        }

                        var newCost = possibleCosts[i] + costs[j];
                        if (possibleCosts[currentWeight] < newCost)
                        {
                            possibleCosts[currentWeight] = newCost;

                            if (possibleCosts[maxCostIndex] <= newCost)
                            {
                                maxCostIndex = currentWeight;
                            }
                        }

                        possibleWeights[currentWeight] = true;
                    }
                }

                maxWeight = tempMaxWeight;
            }

            Console.WriteLine("Weight: {0} Cost: {1}", maxCostIndex, possibleCosts[maxCostIndex]);
        }

        private static void FindHighestCostAndWeightBagNoDuplicates(Product[] products, int maxBasketWeight)
        {
            bool[] possibleWeights = new bool[maxBasketWeight + 1];
            int[] possibleCosts = new int[maxBasketWeight + 1];
            string[] possibleProducts = new string[maxBasketWeight + 1];
            possibleWeights[0] = true;
            int maxWeight = 0;
            int tempMaxWeight = 0;
            int maxCostIndex = 0;

            foreach (var product in products)
            {
                for (int i = maxWeight; i >= 0; i--)
                {
                    if (possibleWeights[i])
                    {
                        var currentWeight = i + product.Weight;
                        if (currentWeight > maxBasketWeight)
                        {
                            continue;
                        }

                        if (tempMaxWeight < currentWeight)
                        {
                            tempMaxWeight = currentWeight;
                        }

                        var newCost = possibleCosts[i] + product.Price;
                        if (possibleCosts[currentWeight] < newCost)
                        {
                            possibleCosts[currentWeight] = newCost;
                            var currentProducts = possibleProducts[i];
                            if (currentProducts == null)
                            {
                                possibleProducts[currentWeight] = product.Name;
                            }
                            else
                            {
                                possibleProducts[currentWeight] = currentProducts + ", " + product.Name;
                            }

                            if (possibleCosts[maxCostIndex] <= newCost)
                            {
                                maxCostIndex = currentWeight;
                            }
                        }

                        possibleWeights[currentWeight] = true;
                    }
                }

                maxWeight = tempMaxWeight;
            }

            Console.WriteLine("\nПродукти: {0} \nТегло: {1} \nСтойност: {2}\n", possibleProducts[maxCostIndex], maxCostIndex, possibleCosts[maxCostIndex]);
        }
        
        private static void FindHighestCostAndWeightBagWithDuplicates(Product[] products, int maxBasketWeight)
        {
            bool[] possibleWeights = new bool[maxBasketWeight + 1];
            int[] possibleCosts = new int[maxBasketWeight + 1];
            string[] possibleProducts = new string[maxBasketWeight + 1];
            possibleWeights[0] = true;
            int maxCostIndex = 0;

            foreach (var product in products)
            {
                for (int i = 0; i <= maxBasketWeight; i++)
                {
                    if (possibleWeights[i])
                    {
                        var currentWeight = i + product.Weight;
                        if (currentWeight > maxBasketWeight)
                        {
                            continue;
                        }

                        var newCost = possibleCosts[i] + product.Price;
                        if (possibleCosts[currentWeight] < newCost)
                        {
                            possibleCosts[currentWeight] = newCost;
                            var currentProducts = possibleProducts[i];
                            if (currentProducts == null)
                            {
                                possibleProducts[currentWeight] = product.Name;
                            }
                            else
                            {
                                possibleProducts[currentWeight] = currentProducts + ", " + product.Name;
                            }

                            if (possibleCosts[maxCostIndex] <= newCost)
                            {
                                maxCostIndex = currentWeight;
                            }
                        }

                        possibleWeights[currentWeight] = true;
                    }
                }
            }
            
            Console.WriteLine("\nПродукти: {0} \nТегло: {1} \nСтойност: {2}\n", possibleProducts[maxCostIndex], maxCostIndex, possibleCosts[maxCostIndex]);
        }
    }
}
