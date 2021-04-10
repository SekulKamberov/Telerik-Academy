namespace MongoHW
{
    using System;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.Linq;

    public class Chat
    {
        //const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseHost = "mongodb://Svetlin:nakov@ds033740.mongolab.com:33740/chat";
        const string DatabaseName = "chat";

        public class User
        {
            public User(string username)
            {
                this.Username = username;
            }
            public string Username { get; set; }
        }

        public class Message
        {
            public Message(string text, DateTime logDate, User user)
            {
                this.Text = text;
                this.LogDate = logDate;
                this.User = user;
            }

            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            public string Text { get; set; }

            public DateTime LogDate { get; set; }

            public User User { get; set; }
        }

        public static MongoDatabase GetDataBase(string databaseName, string mongoClientHost)
        {
            var mongoClient = new MongoClient(mongoClientHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(databaseName);
        }

        public static void Main(string[] args)
        {
            var db = GetDataBase(DatabaseName, DatabaseHost);

            var userCollection = db.GetCollection<User>("Users");

            var user = new User("DonchoMinkov");

            //userCollection.Insert(user);

            var messageCollection = db.GetCollection<Message>("Messages");

            messageCollection.Insert(new Message("What time is it?", DateTime.Now.AddHours(-2), user));

            var logs = messageCollection.FindAll();

            foreach (var item in logs)
            {
                Console.WriteLine("Message: " + item.Text + " Logtime: " + item.LogDate + " User: " + item.User.Username);
            }

        }
    }
}
