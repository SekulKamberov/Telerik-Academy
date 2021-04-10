namespace VariablesExpressionsConstants
{
    using System;

    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public void Rotate(double angle)
        {
            this.Width = Math.Abs(Math.Cos(angle)) * this.Width + Math.Abs(Math.Sin(angle)) * this.Height;
            this.Height = Math.Abs(Math.Sin(angle)) * this.Width + Math.Abs(Math.Cos(angle)) * this.Height;
        }
    }
}