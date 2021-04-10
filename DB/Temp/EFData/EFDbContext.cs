namespace EFData
{
    using System.Data.Entity;

    using EFModels;
    using EF.Data.Migrations;

    public class EFDbContext : DbContext, IEFDbContext
    {
        public EFDbContext()
            : base("EFDbContext")
        {
            // OR INITIALIZE IT IN CLIENT
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>());
        }

        public IDbSet<EFModels.Person> People { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // required field
            // modelBuilder
            // .Entity<Test>()
            // .HasRequired(t => t.Name);

            // modelBuilder
            // .Entity<Person>()
            // .Property(person => person.Name)
            // .IsUnicode();

            // modelBuilder.Entity<Test>().HasMany(t => t.Students).WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
