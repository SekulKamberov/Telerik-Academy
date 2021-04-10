namespace _03.WpfAplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.Linq;
    using System.Timers;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string DatabaseHost = "mongodb://Svetlin:nakov@ds033740.mongolab.com:33740/chat";
        const string DatabaseName = "chat";

        public MainWindow()
        {
            InitializeComponent();

            Timer timer = new Timer(100);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var db = GetDataBase(DatabaseName, DatabaseHost);
            var messageCollection2 = db.GetCollection<Message>("Messages");
            //var messages = messageCollection2.FindAll()
            //       .Select(log => string.Format("[{0}] {1} : {2}", log.LogDate, log.User.Username, log.Text));

            var findLastMessages = Query.GT("LogDate", DateTime.Now.AddMinutes(-1));
            var messages = messageCollection2.Find(findLastMessages)
                                .Select(log => string.Format("[{0}] {1} : {2}", log.LogDate, log.User.Username, log.Text));

            StringBuilder sb = new StringBuilder();
            foreach (var item in messages)
            {
                sb.Append(item + "\n"); 
            }
            //MessageBox.Show(sb.ToString());

            Action<string> addMethod = UpdateMessageThread;
            Application.Current.Dispatcher.BeginInvoke(addMethod, sb.ToString());
        }

        private void UpdateMessageThread(string message)
        {
            ListBoxMessages.Items.Clear();
            ListBoxMessages.Items.Add(new ListBoxItem { Content = message });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = GetDataBase(DatabaseName, DatabaseHost);

            var messageCollection = db.GetCollection<Message>("Messages");

            var username = Username.Text;

            User user = new User(username);

            var message = NewMessage.Text;
            NewMessage.Text = string.Empty;

            var messageToSend = new Message(message, DateTime.Now, user);

            messageCollection.Insert(messageToSend);
        }

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
    }
}