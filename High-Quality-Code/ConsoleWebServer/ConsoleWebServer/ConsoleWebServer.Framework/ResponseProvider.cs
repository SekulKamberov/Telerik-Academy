namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    using ConsoleWebServer.Framework.Controllers;
    using ConsoleWebServer.Framework.Exceptions;
    using ConsoleWebServer.Framework.Interfaces;

    public class ResponseProvider
    {
        private const string HttpRequestType = "GET";
        private const string HttpRequestUri = " / ";
        private const string HttpRequestVerion = "1.1";
        private const string MethodOptionsString = "options";
        private const string ControllerSubstringEnd = "Controller";
        private const string MethodFormat = "/{0}/{1}/{{parameter}}";
        private const string ResponseExceptionMessage = "Request cannot be handled.";
        private const string HttpNotFOundExceptionMessageFormat = "Controller with name {0} not found!";

        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;
            try
            {
                var requestParser = new HttpRequest(HttpRequestType, HttpRequestUri, HttpRequestVerion);
                request = requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.Process(request);
            return response;
        }

        private HttpResponse Process(HttpRequest request)
        {
            if (request.Method.ToLower() == MethodOptionsString)
            {
                var routes =
                    Assembly.GetEntryAssembly()
                        .GetTypes()
                        .Where(x => x.Name.EndsWith(ControllerSubstringEnd) && typeof(Controller).IsAssignableFrom(x))
                        .Select(x => new { x.Name, Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult)) })
                        .SelectMany(x => x.Methods.Select(m => string.Format(MethodFormat, x.Name.Replace(ControllerSubstringEnd, string.Empty), m.Name)))
                        .ToList();

                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, routes));
            }
            else if (new StaticFileHandler().CanHandle(request))
            {
                return new StaticFileHandler().Handle(request);
            }
            else if (request.ProtocolVersion.Major <= 3)
            {
                HttpResponse response;
                try
                {
                    var controller = this.CreateController(request);
                    var actionInvoker = new NewActionInvoker();
                    var actionResult = actionInvoker.InvokeAction(controller, request.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFound exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }

                return response;
            }
            else
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, ResponseExceptionMessage);
            }
        }

        private Controller CreateController(HttpRequest request)
        {
            var controllerClassName = request.Action.ControllerName + ControllerSubstringEnd;
            var type = Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));
            if (type == null)
            {
                throw new HttpNotFound(
                    string.Format(HttpNotFOundExceptionMessageFormat, controllerClassName));
            }

            var instance = (Controller)Activator.CreateInstance(type, request);
            return instance;
        }
    }
}