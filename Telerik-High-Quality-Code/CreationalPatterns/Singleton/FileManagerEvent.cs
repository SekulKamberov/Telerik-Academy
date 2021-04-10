namespace Singleton
{
    using System;

    public class FileManagerEvent
    {
        public FileManagerEvent(string name, FileState state)
        {
            this.Name = name;
            this.EventDate = DateTime.Now;
            this.State = state;
        }

        public string Name { get; private set; }

        public DateTime EventDate { get; private set; }

        public FileState State { get; set; }
    }
}
