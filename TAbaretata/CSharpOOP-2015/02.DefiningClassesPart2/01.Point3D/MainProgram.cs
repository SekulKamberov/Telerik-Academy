/*
 * Task from 1 to 4
 */

namespace _01.Point3D
{
    using System;

    class MainProgram
    {
        static void Main()
        {
            Point3D fstPoint = new Point3D(1.5, 2.4, 3.0);
            Point3D secPoint = new Point3D(1.0, 2.0, 3.5);
            Point3D zero = new Point3D();

            Console.WriteLine("Initial Point3D: {0}", zero);
            Console.WriteLine("First Point3D: {0}", fstPoint);

            Console.WriteLine();
            Console.WriteLine("Distance calculation: {0:F2}", CalculateDistance.DistanceCalc(fstPoint, secPoint));

            Path pathList = new Path();
            pathList.Add(fstPoint);
            pathList.Add(secPoint);

            PathStorage.Save(pathList, @"../../PathStoring.txt");
            PathStorage.Load(@"../../PathStoring.txt");

            Console.WriteLine();
            Console.WriteLine("List of paths stored in the external text file: ");
            foreach (Point3D point in PathStorage.path.PointList)
            {
                Console.WriteLine(point);
            }

            Console.WriteLine();
        }
    }
}
