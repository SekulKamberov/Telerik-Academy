namespace _01.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}
