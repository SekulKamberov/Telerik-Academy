namespace UniversitySystem.Data.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();

        TEntity FindById(object id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void SaveChanges();
    }
}
