namespace UniversitySystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using UniversitySystem.Models;

    public interface IUniversitySystemDbContext
    {
        IDbSet<Student> Students { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<StudentsInCoursesManyToManyAlternative> StudentsInCoursesManyToManyAlternatives { get; set; }

        int SaveChanges();
        
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
