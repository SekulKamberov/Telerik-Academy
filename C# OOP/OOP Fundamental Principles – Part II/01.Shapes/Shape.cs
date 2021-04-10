namespace _01.Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be > 0");
                }

                this.height = value;
            }
        }
        
        public double Width
        {
            get 
            {
                return this.width; 
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be > 0");
                }

                this.width = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
