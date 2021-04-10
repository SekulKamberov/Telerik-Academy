namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    
    public class JsonActionResultWithCorsWithoutCaching : JsonActionResult
    {
        private const string HeaderKeyAllowOrigin = "Access-Control-Allow-Origin";
        private const string HeaderKeyCache = "Cache-Control";
        private const string HeaderSettingsCache = "private, max-age=0, no-cache";

        public JsonActionResultWithCorsWithoutCaching(HttpRequest request, object model, string corsSettings)
            : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(HeaderKeyAllowOrigin, corsSettings));
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(HeaderKeyCache, HeaderSettingsCache));
        }
    }
}
