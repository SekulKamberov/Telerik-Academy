namespace ExeFilesInDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            string searchPattern = "*.exe";
            string startingDirectory = @"C:\WINDOWS";

            // FindFiles(startingDirectory, searchPattern);
            FindFilesRecursive(startingDirectory, searchPattern);
        }

        private static void FindFiles(string direcotory, string searchPattern)
        {
            try
            {
                var filesInThisDirectory = Directory.EnumerateFileSystemEntries(direcotory, searchPattern, SearchOption.AllDirectories);
                foreach (var file in filesInThisDirectory)
                {
                    Console.WriteLine(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void FindFilesRecursive(string direcotory, string searchPattern)
        {
            var subDirecotories = Directory.EnumerateDirectories(direcotory);
            foreach (var subDirectory in subDirecotories)
            {
                FindFilesRecursive(subDirectory, searchPattern);
            }

            try
            {
                var filesInThisDirectory = Directory.EnumerateFiles(direcotory, searchPattern);
                foreach (var file in filesInThisDirectory)
                {
                    Console.WriteLine(file.Substring(file.LastIndexOf("\\") + 1));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
