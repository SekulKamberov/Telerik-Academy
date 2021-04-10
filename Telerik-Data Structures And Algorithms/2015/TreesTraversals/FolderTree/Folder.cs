namespace FolderTree
{
    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public File[] Files { get; set; }

        public Folder[] SubFolders { get; set; }
    }
}
