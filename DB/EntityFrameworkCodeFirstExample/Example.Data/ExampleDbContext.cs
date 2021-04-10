namespace Example.Data
{
    using System.Data.Entity;

    using Example.Data.Migrations;
    using Example.Models;

    public class ExampleDbContext : DbContext, IExampleDbContext
    {
        public ExampleDbContext()
            : base("Example")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExampleDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ExampleDbContext>());
        }

        public IDbSet<Person> People { get; set; }

        public IDbSet<Kid> Kids { get; set; }

        public IDbSet<Store> Stores { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // MOTHER FATHER
            modelBuilder.Entity<Person>()
                    .HasOptional(p => p.Mother)
                    .WithMany()
                    .HasForeignKey(p => p.MotherId);

            modelBuilder.Entity<Person>()
                    .HasOptional(p => p.Father)
                    .WithMany()
                    .HasForeignKey(p => p.FatherId);

            // KIDS
            modelBuilder.Properties<int>()
                    .Where(x => x.Name == "ParentId")
                    .Configure(x => x.IsKey().HasColumnOrder(1));

            modelBuilder.Properties<int>()
                    .Where(x => x.Name == "ChildId")
                    .Configure(x => x.IsKey().HasColumnOrder(2));

            base.OnModelCreating(modelBuilder);
        }
    }
}
