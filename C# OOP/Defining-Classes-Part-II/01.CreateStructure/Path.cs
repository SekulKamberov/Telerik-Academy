namespace _01.CreateStructure
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        public Path()
            : this(new List<Point3D>())
        {
        }

        public Path(List<Point3D> points)
        {
            this.Points = points;
        }

        public List<Point3D> Points { get; set; }

        public void AddPoint(Point3D point3D)
        {
            this.Points.Add(point3D);
        }

        public void RemovePoint(Point3D point3D)
        {
            this.Points.Remove(point3D);
        }

        public void PrintPoints()
        {
            foreach (var item in this.Points)
            {
                Console.WriteLine(item);
            }
        }
    }
}
