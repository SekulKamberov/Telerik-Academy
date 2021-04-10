namespace ConsoleWebServer.Framework.AbstractClasses
{
    using System.Collections.Generic;
    using ConsoleWebServer.Framework.Interfaces;

    public class AbstractHttp : IHttp
    {
        public IDictionary<string, ICollection<string>> Headers { get; set; }

        public void AddHeader(string headerName, string headerValue)
        {
            if (!this.Headers.ContainsKey(headerName))
            {
                this.Headers.Add(headerName, new HashSet<string>());
            }

            this.Headers[headerName].Add(headerValue);
        }
    }
}
