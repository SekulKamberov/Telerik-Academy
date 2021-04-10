namespace Example.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Example.Models;

    public interface IExampleDbContext
    {
        IDbSet<Person> People { get; set; }

        IDbSet<Kid> Kids { get; set; }

        IDbSet<Store> Stores { get; set; }
        
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
