namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    public class JsonActionResultWithCors : JsonActionResult
    {
        private const string HeaderKey = "Access-Control-Allow-Origin";

        public JsonActionResultWithCors(HttpRequest request, object model, string corsSettings)
            : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(HeaderKey, corsSettings));
        }
    }
}
