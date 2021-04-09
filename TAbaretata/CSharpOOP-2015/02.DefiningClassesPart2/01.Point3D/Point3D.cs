/*
 * Task 1: Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
            Implement the ToString() to enable printing a 3D point.
 * Task 2: Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
            Add a static property to return the point O.
*/

namespace _01.Point3D
{
    using System;

    public struct Point3D
    {
        private double x;
        private double y;
        private double z;
        private static readonly Point3D zero;

        public double X
        {
            get { return x; }

            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public Point3D Zero
        {
            get { return zero; }
        }

        static Point3D()
        {
            zero = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("{0:F1} {1:F1} {2:F1}", this.X, this.Y, this.Z);
        }
    }
}
