/*
 * Problem 1: Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
      Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure 
    (heightwidth for rectangle and heightwidth/2 for triangle).
      Define class Square and suitable constructor so that at initialization height must be kept equal to width and
    implement the CalculateSurface() method.
      Write a program that tests the behaviour of the CalculateSurface() method for 
    different shapes (Square, Rectangle, Triangle) stored in an array.
 */

namespace _01.Shapes
{
    using System;

    public class TestShapes
    {
        public static void Main()
        {
            Shape[] shapes = new Shape[]
            {
                new Rectangle(5.0, 4.5),
                new Triangle(3.1, 5.5),
                new Square(3.5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0:F2}", shape.CalculateSurface());
            }
        }
    }
}
