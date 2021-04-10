namespace _06.PhoneBook
{
    public class Command
    {
        public Command(string actualCommand, string commandAsString, string[] parametars)
        {
            this.ActualCommand = actualCommand;
            this.Parrams = parametars;
            this.CommandAsString = commandAsString;
        }

        public string ActualCommand { get; set; }

        public string CommandAsString { get; set; }

        public string[] Parrams { get; set; }
    }
}
