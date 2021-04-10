namespace Abstraction
{
    using System;

    public abstract class Figure : ISurfaceCalculatable, IPerimeterCalculatable
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();
    }
}
