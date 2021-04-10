namespace MongoDB
{
    using System;
    using System.Linq;

    using ExtensionsMethods;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.Linq;

    class Program
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "Logger";

        class Log
        {
            public Log(string text, DateTime logDate)
            {
                this.Text = text;
                this.LogDate = logDate;
            }

            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            public string Text { get; set; }

            public DateTime LogDate { get; set; }
        }

        class User
        {
            public string Name { get; set; }

            public string Text { get; set; }
        }

        static MongoDatabase GetDataBase(string databaseName, string mongoClientHost)
        {
            var mongoClient = new MongoClient(mongoClientHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(databaseName);
        }

        static void Main(string[] args)
        {
            var db = GetDataBase(DatabaseName, DatabaseHost);

            var logsCollection = db.GetCollection<Log>("Logs");

            //var newLog = new Log()
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    LogDate = DateTime.Now,
            //    Text = "Say Hello"
            //};

            //logsCollection.Insert(newLog);

            // STEP 1
            //// SELECT * FROM ...
            //var logs = logsCollection.FindAll();

            ////logs.Select(log => log.Text).Print();

            //foreach (var item in logs)
            //{
            //    Console.WriteLine("Message: " + item.Text + " Logtime: " + item.LogDate);
            //    Console.WriteLine(Extensions.RepeatText("-", 100));
            //}


            //// SELECT * FROM ... WHERE ...
            //var filterQuery = Query<Log>.Where(log => log.Text.Contains("Say"));
            //logsCollection.Find(filterQuery)
            //    .Select(l => l.Text)
            //    .Print();

            //// GENERATE ObjectID
            //var objectId = ObjectId.GenerateNewId();
            //Console.WriteLine(objectId);


            //var variousObjects = db.GetCollection<object>("Logs");
            
            //variousObjects.Insert(
            //    new Log
            //    {
            //        LogDate = DateTime.Now,
            //        Text = "Various Object GetCollection"
            //    });

            //variousObjects.Insert( 
            //    new
            //    {
            //        LogDate = DateTime.Now,
            //        Name = "Insert new object"
            //    });


            // STEP 2
            ////var bsonObject = db.GetCollection<BsonObjectId>("Logs");

            ////var bsonObj = new BsonDocument();

            ////bsonObj.GetElement("Text");

            ////var logObj = new Log()
            ////        {
            ////            LogDate = DateTime.Now,
            ////            Text = "BsonObject"
            ////        };
            ////var logObjToJSON = logObj.ToJson();
            ////BsonDocument bsonDoc = BsonDocument.Parse(logObjToJSON);

            ////Console.WriteLine(bsonDoc.GetElement("Text").Value);
            
            ////var bsonDoument = BsonDocument.Create(logObj);

            // STEP 3
            //Log[] logsToIsert = { 
            //                        new Log("InsertBatch", DateTime.Now.AddHours(-1)),
            //                        new Log("Lqlqlq", DateTime.Now)
            //                    };

            //logsCollection.InsertBatch(logsToIsert);

            //logsCollection.FindAll()
            //    .Select(log => "[DateTime: " + log.LogDate + "] " + log.Text)
            //    .Print();

            //logsCollection.Insert(new {Name = "Name parametar"});
            //var searchNonLogsQuery = Query<BsonDocument>
            //    .Where(doc => doc.Names.Contains("Name"));

            //logsCollection.Remove(searchNonLogsQuery);


            // STEP 4
            //logsCollection.Insert(
            //    new
            //        {
            //            Text = "Good morning",
            //            LogDate = DateTime.Now
            //        });

            //var findAfter10Query = Query.Or(
            //    Query.GT("LogDate", DateTime.Now.AddHours(-10)),
            //    Query.LT("LogDate", DateTime.Now.AddHours(-11)));
            
            //logsCollection.Find(findAfter10Query)
            //    .Select(log => string.Format("[{0}] {1}", 
            //                                     log.LogDate, log.Text))
            //    .Print();

            //var specialQuery = Query<Log>.Where(log => log.LogDate > DateTime.Now.AddHours(-1));
            
            //logsCollection.Find(specialQuery)
            //    .Select(log => string.Format("[{0}] {1}",
            //                                     log.LogDate, log.Text))
            //    .Print();

            //logsCollection.FindAll()
            //    .Select(log => string.Format("[{0}] {1}",
            //                                     log.LogDate, log.Text))
            //    .Print();


            // STEP 5

            (from log 
             in logsCollection.AsQueryable<Log>()
             where log.LogDate > DateTime.Now.AddHours(-2)
             select log.LogDate + " " + log.Text)
                .Print();

            var userCollection = db.GetCollection<User>("Users");

            userCollection.Insert(
                new 
                    {
                        Name = "Bay Ivan",
                        Text = "Good morning"
                    });

            // JOIN IS NOT SUPPORTED
            //(from log in logsCollection.AsQueryable<Log>()
            // join user in userCollection.AsQueryable<User>()
            // on log.Text equals user.Text
            // select log.LogDate + " " + user.Name)
            //    .Print();

        }
    }
}
