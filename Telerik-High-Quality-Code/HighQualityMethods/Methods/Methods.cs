namespace Methods
{
    using System;

    internal class Methods
    {
        public static double CalculateTriangleArea(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides can not have negative values!");
            }

            bool firstSideToLong = firstSide > secondSide + thirdSide;
            bool secondSideToLong = secondSide > firstSide + thirdSide;
            bool thirdSideToLong = thirdSide > secondSide + firstSide;

            if (firstSideToLong || secondSideToLong || thirdSideToLong)
            {
                throw new ArgumentOutOfRangeException("Sides can not make triangle!");
            }

            double halfPerimetar = (firstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(halfPerimetar * (halfPerimetar - firstSide) * (halfPerimetar - secondSide) * (halfPerimetar - thirdSide));

            return area;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new ArgumentOutOfRangeException("Invalid digit value!");
            }
        }

        public static int FindMax(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Array is empty or null!");
            }

            int max = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        public static void PrintAsNumber(double number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            } 
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            } 
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else 
            {
                throw new ArgumentOutOfRangeException("Invalid format!");
            }
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov", City = "Plovdiv", BornOn = new DateTime(1992, 11, 3) };

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova", City = "Vidin", BornOn = new DateTime(1993, 11, 3) };

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
