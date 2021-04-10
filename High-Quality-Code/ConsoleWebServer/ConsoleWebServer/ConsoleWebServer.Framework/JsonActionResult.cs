namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    using ConsoleWebServer.Framework.Interfaces;
    using Newtonsoft.Json;

    public class JsonActionResult : IActionResult
    {
        public readonly object Model;

        public JsonActionResult(IProtocol protocol, object model)
        {
            this.Model = model;
            this.Protocol = protocol;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public IProtocol Protocol { get; private set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.Model);
        }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Protocol.ProtocolVersion, this.GetStatusCode(), this.GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}