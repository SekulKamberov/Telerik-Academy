namespace UniversitySystem.Data
{
    using System.Data.Entity;
    using UniversitySystem.Data.Migrations;
    using UniversitySystem.Models;

    public class UniversitySystemDbContext : DbContext, IUniversitySystemDbContext
    {
        public UniversitySystemDbContext()
            : base("UniversitySystemDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversitySystemDbContext, Configuration>());
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<StudentsInCoursesManyToManyAlternative> StudentsInCoursesManyToManyAlternatives { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // InverseProperty
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.Menthor)
                .WithMany(s => s.MentorStudents)
                .HasForeignKey(s => s.MentorId);
        }
    }
}
