namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystemModel;
    using StudentSystem.Data.Migrations;

    public class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        // name of the database "StudentSystemDbContext"
        public StudentSystemDbContext() :base("StudentSystemDbContext")
        {
            // OR INITIALIZE IT IN StudentSystemConsoleClient.cs
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //// required field
            //modelBuilder
            //    .Entity<Test>()
            //    .HasRequired(t => t.Name);

            modelBuilder
                .Entity<Student>()
                .Property(s => s.FirstName)
                .IsUnicode();

            //modelBuilder.Entity<Test>().HasMany(t => t.Students).WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
