namespace EFData
{
    using EFCommon.Repository;
    using EFModels;

    public interface IEFData
    {
        IRepository<Person> People { get; }

        int SaveChanges();
    }
}
