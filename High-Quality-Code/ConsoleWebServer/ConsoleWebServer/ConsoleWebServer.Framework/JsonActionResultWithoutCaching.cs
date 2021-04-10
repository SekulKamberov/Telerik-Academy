namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;

    public class JsonActionResultWithoutCaching : JsonActionResult
    {
        private const string HeaderKeyNoCache = "Cache-Control";
        private const string HeaderSettingsNoCache = "private, max-age=0, no-cache";

        public JsonActionResultWithoutCaching(HttpRequest request, object model)
            : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(HeaderKeyNoCache, HeaderSettingsNoCache));
            throw new Exception();
        }
    }
}
