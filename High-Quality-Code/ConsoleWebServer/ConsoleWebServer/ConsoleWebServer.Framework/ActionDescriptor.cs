namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;

    public class ActionDescriptor
    {
        private const char UriSeparator = '/';
        private const string DefaultControllerName = "Home";
        private const string DefaultActionName = "Index";
        private const string DefaultParameter = "Param";
        private const string StringFormat = "/{0}/{1}/{2}";

        public ActionDescriptor(string uri)
        {
            uri = uri ?? string.Empty;

            var uriParts = uri.Split(new[] { UriSeparator }, StringSplitOptions.RemoveEmptyEntries);

            this.ControllerName = uriParts.Length > 0 ? uriParts[0] : DefaultControllerName;

            this.ActionName = uriParts.Length > 1 ? uriParts[1] : DefaultActionName;

            this.Parameter = uriParts.Length > 2 ? uriParts[2] : DefaultParameter;
        }

        public string ControllerName { get; private set; }

        public string ActionName { get; private set; }

        public string Parameter { get; private set; }

        public override string ToString()
        {
            return string.Format(StringFormat, this.ControllerName, this.ActionName, this.Parameter);
        }
    }
}