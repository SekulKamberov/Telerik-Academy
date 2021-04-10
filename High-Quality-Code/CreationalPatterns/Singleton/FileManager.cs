namespace Singleton
{
    using System.Collections.Generic;

    public sealed class FileManager
    {
        private static volatile FileManager logger;
        private static object syncLock = new object();
        private readonly List<FileManagerEvent> events;

        private FileManager()
        {
            this.events = new List<FileManagerEvent>();
        }

        public static FileManager Instance
        {
            get
            {
                if (logger == null)
                {
                    lock (syncLock)
                    {
                        if (logger == null)
                        {
                            logger = new FileManager();
                        }
                    }
                }

                return logger;
            }
        }

        public void WritteFile(string fileName, string content)
        {
            // TODO save file
        }

        public void DeleteFile(string fileName)
        {
            // TODO delete file
        }

        public void EditFile(string fileName, string content)
        {
            // TODO edit file
        }
    }
}
