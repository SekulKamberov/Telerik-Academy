namespace FolderTree
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            string startingDirectory = @"C:\Windows\Temp";
            var folder = MapFolder(startingDirectory);
            var size = CalculateDirectorySize(folder);

            Console.WriteLine("Folder Name: " + folder.Name);
            Console.WriteLine("Total size: {0} bytes", size);
            Console.WriteLine("Total size: {0}MB", size / 1048576);

            foreach (var subFolder in folder.SubFolders)
            {
                Console.WriteLine("\nSubFolder Name: " + subFolder.Name);
                var subFolderSize = CalculateDirectorySize(subFolder);
                Console.WriteLine("Total size: {0} bytes", subFolderSize);
                Console.WriteLine("Total size: {0}MB", subFolderSize / 1048576);
            }
        }

        private static long CalculateDirectorySize(Folder folder)
        {
            long initialSize = 0;
            var size = SumFilesSizeDFS(folder, ref initialSize);
            return size;
        }

        private static long SumFilesSizeDFS(Folder folder, ref long size)
        {
            for (int i = 0; i < folder.SubFolders.Length; i++)
            {
                SumFilesSizeDFS(folder.SubFolders[i], ref size);
            }

            for (int i = 0; i < folder.Files.Length; i++)
            {
                size += folder.Files[i].Size;
            }

            return size;
        }

        private static Folder MapFolder(string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            var folderName = directoryInfo.Name;
            var newFolder = new Folder(folderName);
            MapInnerDirectory(newFolder, directory);
            return newFolder;
        }

        private static void MapInnerDirectory(Folder folder, string directory)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                folder.SubFolders = new Folder[subDirectories.Length];
                for (int i = 0; i < subDirectories.Length; i++)
                {
                    var newFolder = new Folder(subDirectories[i].Name);
                    folder.SubFolders[i] = newFolder;
                    MapInnerDirectory(newFolder, subDirectories[i].FullName);
                }

                FileInfo[] filesInfo = directoryInfo.GetFiles();
                folder.Files = new File[filesInfo.Length];

                for (int i = 0; i < filesInfo.Length; i++)
                {
                    var newFile = new File(filesInfo[i].Name, filesInfo[i].Length);
                    folder.Files[i] = newFile;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
