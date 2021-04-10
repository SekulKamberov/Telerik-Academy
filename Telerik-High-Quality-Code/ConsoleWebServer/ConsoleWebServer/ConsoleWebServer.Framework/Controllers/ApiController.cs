namespace ConsoleWebServer.Framework.Controllers
{
    using System;
    using System.Linq;

    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Interfaces;

    public class ApiController : Controller
    {
        private const string RefererKey = "Referer";
        private const string InvalidRefererOrDomainMessage = "Invalid referer or invalid domain!";
        private const string DateFormat = "yyyy-MM-dd";
        private const string InfoStartWith = "Data available for ";

        public ApiController(HttpRequest request)
            : base(request)
        {
        }

        public IActionResult ReturnMe(string param)
        {
            return this.Json(new { param = param });
        }

        public IActionResult GetDateWithCors(string domainName)
        {
            var requestReferer = string.Empty;
            if (this.Request.Headers.ContainsKey(RefererKey))
            {
                requestReferer = this.Request.Headers[RefererKey].FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(domainName))
            {
                throw new ArgumentException(InvalidRefererOrDomainMessage);
            }

            return new JsonActionResultWithCors(this.Request, new { date = DateTime.Now.ToString(DateFormat), moreInfo = InfoStartWith + domainName }, domainName);
        }
    }
}