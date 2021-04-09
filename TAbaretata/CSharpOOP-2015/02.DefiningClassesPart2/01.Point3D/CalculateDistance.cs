/*
 * Task 3: Write a static class with a static method to calculate the distance between two points in the 3D space.
*/

namespace _01.Point3D
{
    using System;

    public static class CalculateDistance
    {
        public static double DistanceCalc(Point3D first, Point3D second)
        {
            return Math.Sqrt((first.X - second.X) * (first.X - second.X) +
                            (first.Y - second.Y) * (first.Y - second.Y) +
                            (first.Z - second.Z) * (first.Z - second.Z));
        }
    }
}
