namespace SocialNetwork.ConsoleClient
{
    using SocialNetwork.Data;
    using SocialNetwork.Models;
    using System.Data.Entity;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SocialNetworkDbContext>());
            var user = new User()
            {
                UserName = "12345",
                FirstName = "12",
                LastName = "32", 
            };

            var db = new SocialNetworkDbContext();
            db.Users.Add(user);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
