namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    using ConsoleWebServer.Framework.AbstractClasses;
    using ConsoleWebServer.Framework.Interfaces;

    public class HttpResponse : AbstractHttp
    {
        private const string ServerEngineName = "ConsoleWebServer";
        private const string DefaultContentType = "text/plain; charset=utf-8";
        private const string ProtocolReplacedVersionToLower = "http/";
        private const string ServerDefaultHeader = "Server";
        private const string ContentLengthDefaultHeader = "Content-Length";
        private const string ContentTypeDefaultHeader = "Content-Type";
        private const string ToStringFormat = "{0}{1} {2} {3}";
        private const string HTTPStartString = "HTTP/";
        private const string ToStringLineFormat = "{0}: {1}";
        private const string JoinSeparator = "; ";

        public HttpResponse(Version httpVersion, HttpStatusCode statusCode, string body, string contentType = DefaultContentType)
        {
            this.ProtocolVersion = Version.Parse(httpVersion.ToString().ToLower().Replace(ProtocolReplacedVersionToLower, string.Empty));
            this.Headers = new SortedDictionary<string, ICollection<string>>();
            this.Body = body;
            this.StatusCode = statusCode;
            this.AddHeader(ServerDefaultHeader, ServerEngineName);
            this.AddHeader(ContentLengthDefaultHeader, body.Length.ToString());
            this.AddHeader(ContentTypeDefaultHeader, contentType);
        }

        public Version ProtocolVersion { get; protected set; }

        public HttpStatusCode StatusCode { get; private set; }

        public string Body { get; private set; }

        public string StatusCodeAsString 
        {
            get 
            { 
                return this.StatusCode.ToString(); 
            } 
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(ToStringFormat, HTTPStartString, this.ProtocolVersion, (int)this.StatusCode, this.StatusCodeAsString));
            var headerStringBuilder = new StringBuilder();
            foreach (var key in this.Headers.Keys)
            {
                headerStringBuilder.AppendLine(string.Format(ToStringLineFormat, key, string.Join(JoinSeparator, this.Headers[key])));
            }

            stringBuilder.AppendLine(headerStringBuilder.ToString());

            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                stringBuilder.AppendLine(this.Body);
            }

            return stringBuilder.ToString();
        }
    }
}