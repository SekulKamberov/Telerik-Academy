namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    using ConsoleWebServer.Framework.Interfaces;

    public class ContentActionResultWithoutCaching : ContentActionResult
    {
        private const string CacheControlHeader = "Cache-Control";
        private const string CacheControllesettings = "private, max-age=0, no-cache";

        public ContentActionResultWithoutCaching(IProtocol protocol, object model)
            : base(protocol, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(CacheControlHeader, CacheControllesettings));
        }
    }
}
