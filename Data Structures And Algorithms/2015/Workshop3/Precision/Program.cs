namespace Precision
{
    using System;

    public class Program
    {
        private static int maxDenominator;
        private static int maxPrecisionMatchLength = 0;
        private static decimal minDenominator = 100000;
        private static decimal minNominator = 100000;
        private static string number;
        private static string fraction;

        private static void Main()
        {
            // Console.WriteLine(CountMatches("141", 1, 7));
            // Precisions("42", "0.141592658");
            // Precisions("3", "0.1337");
            // Precisions("80000", "0.1234567891011121314151617181920");
            // Precisions("1000", "0.42");
            // Precisions("100", "0.420");
            // Precisions("115", "0.141592658");
            Precisions(null, null);
        }

        private static void Precisions(string denominatorString = null, string numberString = null)
        {
            if (denominatorString != null && numberString != null)
            {
                maxDenominator = int.Parse(denominatorString);
                number = numberString;
            }
            else
            {
                maxDenominator = int.Parse(Console.ReadLine());
                number = Console.ReadLine();
            }

            fraction = number.Substring(2);

            for (int nominator = 0; nominator < maxDenominator; nominator++)
            {
                int leftIndex = nominator + 1;
                int rightIndex = maxDenominator;
                int middleIndex = maxDenominator;
                while (leftIndex < rightIndex)
                {
                    middleIndex = (leftIndex + rightIndex) / 2;
                    bool isBigger = CompareFraction(nominator, middleIndex);
                    if (!isBigger)
                    {
                        rightIndex = middleIndex;
                        CheckMaxMatches(CountMatches(nominator, middleIndex), nominator, middleIndex);
                    }
                    else
                    {
                        leftIndex = middleIndex + 1;
                        CheckMaxMatches(CountMatches(nominator, middleIndex), nominator, middleIndex);
                    }
                }

                CheckMaxMatches(CountMatches(nominator, middleIndex), nominator, middleIndex);

                // int current = CountMatches(nominator, leftIndex);
                // CheckMaxMatches(current, nominator, leftIndex);
                // current = CountMatches(nominator, middleIndex);
                // CheckMaxMatches(current, nominator, middleIndex);
                // current = CountMatches(nominator, rightIndex);
                // CheckMaxMatches(current, nominator, rightIndex);
            }

            if (maxPrecisionMatchLength == 0)
            {
                Console.WriteLine("0/1");
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine("{0}/{1}", minNominator, minDenominator);
                Console.WriteLine(maxPrecisionMatchLength + 1);
            }
        }

        private static void CheckMaxMatches(int precisionMatchLength, int nominator, int denominator)
        {
            if (precisionMatchLength > maxPrecisionMatchLength)
            {
                maxPrecisionMatchLength = precisionMatchLength;
                minDenominator = denominator;
                minNominator = nominator;
            }
            else if (precisionMatchLength == maxPrecisionMatchLength)
            {
                if (minDenominator > denominator)
                {
                    minDenominator = denominator;
                    minNominator = nominator;
                }
                else if (minDenominator == denominator)
                {
                    if (minNominator > nominator)
                    {
                        minNominator = nominator;
                    }
                }
            }
        }

        private static int CountMatches(int nominator, int denominator)
        {
            nominator *= 10;
            int i;
            for (i = 0; i < fraction.Length; i++)
            {
                int digit = nominator / denominator;
                if (digit != fraction[i] - '0')
                {
                    break;
                }

                nominator = (nominator % denominator) * 10;
            }

            return i;
        }

        private static bool CompareFraction(int nominator, int denominator)
        {
            nominator *= 10;
            int i;
            for (i = 0; i < fraction.Length; i++)
            {
                int digit = nominator / denominator;
                if (digit < fraction[i] - '0')
                {
                    return false;
                }
                else if (digit > fraction[i] - '0')
                {
                    return true;
                }

                nominator = (nominator % denominator) * 10;
            }

            return true;
        }
    }
}
