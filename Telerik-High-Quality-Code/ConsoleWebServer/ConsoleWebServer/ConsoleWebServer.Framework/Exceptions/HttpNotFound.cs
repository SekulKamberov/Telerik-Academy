namespace ConsoleWebServer.Framework.Exceptions
{
    using System;
    using System.Linq;

    public class HttpNotFound : Exception
    {
        public HttpNotFound(string message) 
            : base(message) 
        {
        }
    }
}