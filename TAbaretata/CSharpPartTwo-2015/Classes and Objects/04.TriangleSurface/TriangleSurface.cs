using System;

/*
    Write methods that calculate the surface of a triangle by given:
        Side and an altitude to it;
        Three sides;
        Two sides and an angle between them;
    Use System.Math.
*/

class TriangleSurface
{
    static double sideAndAltitude(double side, double altitude)
    {
        double sum = (side * altitude) / 2;
        return sum;
    }

    static double threeSides(double a, double b, double c)
    {
        double s = (a + b + c);
        double sum = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        return sum;
    }

    static double twoSidesAndAngle(double a, double b, int angle)
    {
        double sum = ((a * b) / 2) * Math.Sin(angle);
        return sum;
    }

    static void ExitProgram()
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine(new string('-', 15));
            Console.WriteLine("Calculating area of triangle.");
            Console.WriteLine("Press 1 for calculating by side and altitude!");
            Console.WriteLine("Press 2 for calculating by 3 sides!");
            Console.WriteLine("Press 3 for calculating by 2 sides and an angle between them!");
            Console.WriteLine("Please enter a number [1 to 3] or 0 to exit: ");
            Console.WriteLine(new string('-', 15));
            try
            {

                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    ExitProgram();
                }
                else if (input == 1)
                {
                    Console.Write("Enter side: ");
                    double side = double.Parse(Console.ReadLine());
                    Console.Write("Enter altitude: ");
                    double altitude = double.Parse(Console.ReadLine());
                    Console.WriteLine("Area = {0:F2}", sideAndAltitude(side, altitude));
                }
                else if (input == 2)
                {
                    Console.Write("Enter first side: ");
                    double sideA = double.Parse(Console.ReadLine());
                    Console.Write("Enter second side: ");
                    double sideB = double.Parse(Console.ReadLine());
                    Console.Write("Enter third side: ");
                    double sideC = double.Parse(Console.ReadLine());
                    Console.WriteLine("Area = {0:F2}", threeSides(sideA, sideB, sideC));
                }
                else if (input == 3)
                {
                    Console.Write("Enter first side: ");
                    double sideA = double.Parse(Console.ReadLine());
                    Console.Write("Enter second side: ");
                    double sideB = double.Parse(Console.ReadLine());
                    Console.Write("Enter an angle: ");
                    int angle = int.Parse(Console.ReadLine());
                    Console.WriteLine("Area = {0:F2}", twoSidesAndAngle(sideA, sideB, angle));
                }
                else
                {
                    Console.WriteLine("Number must be between 1 and 3!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}