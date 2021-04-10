namespace StudentSystem.Data.Migrations
{
    using StudentSystemModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // in production DB, set = false
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
            
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedStudents(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any() == true)
            {
                return;
            }
            context.Students.Add(new Student
            {
                FirstName = "Svetlin",
                MiddleName = "SeededStudents",
                LastName = "Nakov",
                Age = 35,
                ContactInfo = new StudentContactInfo 
                { 
                    Email = "seed@configuaration.com" 
                }
            });
        }
    }
}
