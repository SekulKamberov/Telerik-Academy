namespace Example.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Example.Common.Repository;
    using Example.Models;

    public class ExampleData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public ExampleData()
            : this(new ExampleDbContext())
        {
        }

        public ExampleData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Person> People
        {
            get { return this.GetRepository<Person>(); }
        }

        public IRepository<Kid> Kids
        {
            get { return this.GetRepository<Kid>(); }
        }

        public IRepository<Store> Stores
        {
            get { return this.GetRepository<Store>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
