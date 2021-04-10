namespace ConsoleWebServer.Framework
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class StaticFileHandler
    {
        private const string Dot = ".";
        private const string Slash = "/";
        private const string PathStartDirectory = "C:\\";
        private const string FileNotExistsExceptionMessage = "File not found";

        public bool CanHandle(HttpRequest request)
        {
            return request.Uri.LastIndexOf(Dot, StringComparison.Ordinal) > request.Uri.LastIndexOf(Slash, StringComparison.Ordinal);
        }

        public HttpResponse Handle(HttpRequest request)
        {
            string filePath = Environment.CurrentDirectory + Slash + request.Uri;
            if (!this.FileExists(PathStartDirectory, filePath, 3))
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, FileNotExistsExceptionMessage);
            }

            string fileContents = File.ReadAllText(filePath);
            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);
            return response;
        }

        private bool FileExists(string path, string filePath, int depth)
        {
            if (depth <= 0)
            {
                return File.Exists(filePath);
            }

            try
            {
                var files = Directory.GetFiles(path);
                if (files.Contains(filePath))
                {
                    return true;
                }

                var directories = Directory.GetDirectories(path);
                foreach (var directory in directories)
                {
                    if (this.FileExists(directory, filePath, depth - 1))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}