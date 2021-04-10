namespace SocialNetwork.Data
{    
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using SocialNetwork.Models;

    public interface ISocialNetworkDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Friendship> Friendships { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<Post> Posts { get; set; }

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
