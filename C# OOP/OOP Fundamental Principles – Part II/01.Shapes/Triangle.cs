namespace _01.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            double surface = (this.Width * this.Height) / 2;

            return surface;
        }
    }
}
