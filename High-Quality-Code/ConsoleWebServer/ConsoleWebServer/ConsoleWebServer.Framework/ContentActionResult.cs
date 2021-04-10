namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    using ConsoleWebServer.Framework.Interfaces;

    public class ContentActionResult : IActionResult
    {
        private const string ContentType = "text/plain; charset=utf-8";
        private readonly object model;

        public ContentActionResult(IProtocol protocol, object model)
        {
            this.model = model;
            this.Protocol = protocol;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public IProtocol Protocol { get; private set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Protocol.ProtocolVersion, HttpStatusCode.OK, this.model.ToString(), ContentType);
            foreach (var responseHeader in this.ResponseHeaders) 
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value); 
            }

            return response;
        }
    }
}