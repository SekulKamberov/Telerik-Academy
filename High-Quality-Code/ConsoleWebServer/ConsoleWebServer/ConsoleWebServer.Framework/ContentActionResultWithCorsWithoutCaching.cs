namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    using ConsoleWebServer.Framework.Interfaces;

    public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
    {
        private const string AccessControlAllowOriginHeader = "Access-Control-Allow-Origin";
        private const string CacheControlHeader = "Cache-Control";
        private const string CacheControllSettings = "private, max-age=0, no-cache";

        public ContentActionResultWithCorsWithoutCaching(IProtocol protocol, object model, string corsSettings)
            : base(protocol, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(AccessControlAllowOriginHeader, corsSettings));
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(CacheControlHeader, CacheControllSettings));
        }
    }
}
