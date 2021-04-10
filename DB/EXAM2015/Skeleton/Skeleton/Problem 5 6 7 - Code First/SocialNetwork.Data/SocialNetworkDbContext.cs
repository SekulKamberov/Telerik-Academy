namespace SocialNetwork.Data
{
    using SocialNetwork.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SocialNetworkDbContext : DbContext, ISocialNetworkDbContext
    {
        public SocialNetworkDbContext()
            : base("SocialNetworkDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());
        }

        public IDbSet<Models.User> Users { get; set; }

        public IDbSet<Models.Image> Images { get; set; }

        public IDbSet<Models.Message> Messages { get; set; }

        public IDbSet<Models.Friendship> Friendships { get; set; }

        public IDbSet<Models.Tag> Tags { get; set; }

        public IDbSet<Models.Post> Posts { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
