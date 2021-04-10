namespace _01.Shapes
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Triangle triangle = new Triangle(10, 20);
            Rectangle rectangle = new Rectangle(10, 20);
            Square square = new Square(20);
            IList<Shape> shapes = new List<Shape>() { triangle, rectangle, square };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0} {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
