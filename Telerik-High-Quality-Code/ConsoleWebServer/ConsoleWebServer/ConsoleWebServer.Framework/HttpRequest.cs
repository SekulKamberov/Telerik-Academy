namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using ConsoleWebServer.Framework.AbstractClasses;
    using ConsoleWebServer.Framework.Exceptions;
    using ConsoleWebServer.Framework.Interfaces;

    public class HttpRequest : AbstractHttp, IProtocol
    {
        private const string ReplacedProtocolString = "http/";
        private const string ToStringFormat = "{0} {1} {2}{3}";
        private const string ToStringProtocol = "HTTP/";
        private const string ToStringLineFormat = "{0}: {1}";
        private const string JoinSeparator = "; ";
        private const char DotsSeparator = ':';
        private const char SpaceSeparator = ' ';
        private const string InvalidParserExceptionMessage = "Invalid format for the first request line. Expected format: [Method] [Uri] HTTP/[Version]";

        public HttpRequest(string method, string uri, string httpVersion)
        {
            this.ProtocolVersion = Version.Parse(httpVersion.ToLower().Replace(ReplacedProtocolString, string.Empty));
            this.Headers = new SortedDictionary<string, ICollection<string>>();
            this.Uri = uri;
            this.Method = method;
            this.Action = new ActionDescriptor(uri);
        }

        public string Uri { get; private set; }

        public string Method { get; private set; }

        public Version ProtocolVersion { get; protected set; }

        public ActionDescriptor Action { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(ToStringFormat, this.Method, this.Action, ToStringProtocol, this.ProtocolVersion));
            var headerStringBuilder = new StringBuilder();
            foreach (var key in this.Headers.Keys)
            {
                headerStringBuilder.AppendLine(string.Format(ToStringLineFormat, key, string.Join(JoinSeparator, this.Headers[key])));
            }

            sb.AppendLine(headerStringBuilder.ToString());

            return sb.ToString();
        }

        public HttpRequest Parse(string requestAsString)
        {
            var stringReader = new StringReader(requestAsString);
            var firstLine = stringReader.ReadLine();
            var requestObject = this.CreateRequest(firstLine);
            string line;
            while ((line = stringReader.ReadLine()) != null)
            {
                this.AddHeaderToRequest(requestObject, line);
            }

            return requestObject;
        }

        private HttpRequest CreateRequest(string frl)
        {
            var firstRequestLineParts = frl.Split(' ');
            if (firstRequestLineParts.Length != 3)
            {
                throw new ParserException(InvalidParserExceptionMessage);
            }

            var requestObject = new HttpRequest(
                firstRequestLineParts[0],
                firstRequestLineParts[1],
                firstRequestLineParts[2]);

            return requestObject;
        }

        private void AddHeaderToRequest(HttpRequest httpRequest, string headerLine)
        {
            var lines = headerLine.Split(new[] { DotsSeparator, SpaceSeparator }, 2, StringSplitOptions.RemoveEmptyEntries);
            var headerName = lines[0];
            var headerValue = lines.Length == 2 ? lines[1] : string.Empty;
            httpRequest.AddHeader(headerName, headerValue);
        }
    }
}