namespace Models.Interfaces
{
    public interface IGear
    {
        decimal Price { get; }

        string Description { get; }

        double Weight { get; }
    }
}
