namespace ConsoleWebServer.Framework.Interfaces
{
    using System.Collections.Generic;

    public interface IHttp
    {
        IDictionary<string, ICollection<string>> Headers { get; }

        void AddHeader(string name, string value);
    }
}
