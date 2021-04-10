namespace StudentSystem.Data.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    public class TestingRepository<T> : IGenericRepository<T>
    {
        private IList<T> data;

        public IQueryable<T> All()
        {
            return this.data.AsQueryable();
        }

        public System.Linq.IQueryable<T> Search(System.Linq.Expressions.Expression<System.Func<T, bool>> conditions)
        {
            throw new System.NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Detach(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
