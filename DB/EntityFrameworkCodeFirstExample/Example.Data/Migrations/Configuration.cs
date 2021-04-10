namespace Example.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Example.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ExampleDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ExampleDbContext context)
        {
            context.People.AddOrUpdate(
              p => p.Name,
              new Person { Name = "Andrew Peters" },
              new Person { Name = "Brice Lambson" },
              new Person { Name = "Rowan Miller" });
        }
    }
}
