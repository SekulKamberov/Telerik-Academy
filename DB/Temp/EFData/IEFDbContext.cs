namespace EFData
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using EFModels;

    public interface IEFDbContext
    {
        IDbSet<Person> People { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
