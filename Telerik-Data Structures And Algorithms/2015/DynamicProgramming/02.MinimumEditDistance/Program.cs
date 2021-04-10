namespace _02.MinimumEditDistance
{
    using System;
    using System.Linq;
    using System.Text;
    using LongestCommonSubsequence;

    public class Program
    {
        public static void Main(string[] args)
        {
            var firstString = "developer";
            var secondString = "enveloped";
            Console.WriteLine("\nMED = {0}\n", CalculateMinimumEditDistance(firstString, secondString));

            string firstReversed = string.Join("", firstString.Reverse());
            string secondReversed = string.Join("", secondString.Reverse());
            Console.WriteLine("\nMED = {0}\n", CalculateMinimumEditDistance(firstReversed, secondReversed));
        }

        private static double CalculateMinimumEditDistance(string firstString, string secondString)
        {
            var med1 = MinimumEditDistance(firstString, secondString);
            var med2 = MinimumEditDistance(secondString, firstString);

            return med1 < med2 ? med1 : med2;
        }

        private static double MinimumEditDistance(string firstString, string secondString)
        {
            Console.WriteLine();
            Console.WriteLine("First  : " + firstString);
            Console.WriteLine("Second : " + secondString);

            double minimumEditDistance = 0;
            if (firstString.Length != secondString.Length)
            {
                throw new ArgumentException("String should have same length.");
            }

            var lcsMatrix = LongestCommonSubsequenceCalculator.DrawLongestCommonSequenceMatrix(firstString, secondString);
            var common = LongestCommonSubsequenceCalculator.ExtractSequence(lcsMatrix, firstString, secondString);
            Console.WriteLine("Common: " + common);

            var first = new StringBuilder(firstString);
            var second = new StringBuilder(secondString);

            var firstIndex = 0;
            var secondIndex = 0;
            var commonIndex = 0;

            while (first.Length > second.Length || firstIndex < firstString.Length || secondIndex < secondString.Length)
            {
                if (commonIndex < common.Length)
                {
                    if (second[secondIndex] == common[commonIndex])
                    {
                        if (second[secondIndex] == first[firstIndex])
                        {
                            // DO NOTHING
                            commonIndex++;
                            firstIndex++;
                            secondIndex++;
                            continue;
                        }
                        else
                        {
                            // DELETE UNTIL common[index]
                            while (second[secondIndex] != first[firstIndex])
                            {
                                Console.WriteLine("DELETE -> {0}", first[firstIndex]);
                                minimumEditDistance += 0.9;
                                first.Remove(firstIndex, 1);
                            }
                        }
                    }
                    else if (second[secondIndex] != common[commonIndex])
                    {
                        if (first[firstIndex] != common[commonIndex])
                        {
                            // REPLACE
                            Console.WriteLine("REPLACE -> {0} with {1}", first[firstIndex], second[secondIndex]);
                            minimumEditDistance += 1;
                            first[firstIndex] = second[secondIndex];
                            firstIndex++;
                            secondIndex++;
                        }
                        else
                        {
                            // INSERT
                            Console.WriteLine("INSERT -> {0}", second[secondIndex]);
                            minimumEditDistance += 0.8;
                            first.Insert(firstIndex, second[secondIndex]);
                            firstIndex++;
                            secondIndex++;
                        }
                    }
                }
                else
                {
                    // NO MORE COMMON
                    if (first.Length > second.Length)
                    {
                        // DELETE EXTRA CHARS
                        Console.WriteLine("DELETE -> {0}", first[firstIndex]);
                        minimumEditDistance += 0.9;
                        first.Remove(firstIndex, 1);
                        continue;
                    }
                    else if (firstIndex == first.Length)
                    {
                        // INSERT MISSING CHARS
                        Console.WriteLine("INSERT -> {0}", second[secondIndex]);
                        minimumEditDistance += 0.8;
                        first.Append(second[secondIndex]);
                        firstIndex++;
                        secondIndex++;
                    }
                    else
                    {
                        // REPLACE
                        Console.WriteLine("REPLACE -> {0}", second[secondIndex]);
                        minimumEditDistance += 1;
                        first[firstIndex] = second[secondIndex];
                        firstIndex++;
                        secondIndex++;
                    }
                }                
            }

            Console.WriteLine("First  : " + first.ToString());
            Console.WriteLine("Second : " + second.ToString());

            return minimumEditDistance;
        }
    }
}
