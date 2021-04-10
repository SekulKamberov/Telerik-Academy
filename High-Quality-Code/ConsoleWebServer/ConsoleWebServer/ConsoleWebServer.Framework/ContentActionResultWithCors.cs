namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    using ConsoleWebServer.Framework.Interfaces;

    public class ContentActionResultWithCors<TResult> : ContentActionResult
    {
        private const string AccessControllAllowOriginHeader = "Access-Control-Allow-Origin";

        public ContentActionResultWithCors(IProtocol protocol, object model, string corsSettings)
            : base(protocol, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(AccessControllAllowOriginHeader, corsSettings));
        }
    }
}
