namespace StudentSystem.Data.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T: class
    {
        IQueryable<T> All();

        IQueryable<T> Search(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        T Delete(T entity);

        void Update(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}
