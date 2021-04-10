namespace Example.Data
{
    using Example.Common.Repository;
    using Example.Models;

    public interface IExampleData
    {
        IRepository<Person> People { get; }

        IRepository<Kid> Kids { get; }

        IRepository<Store> Stores { get; }

        int SaveChanges();
    }
}
