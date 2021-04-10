namespace EFData
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;

    using EFCommon.Repository;
    using EFModels;

    public class EFData : IEFData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public EFData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Person> People
        {
            get { return this.GetRepository<Person>(); }
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
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}