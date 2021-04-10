namespace ConsoleWebServer.Framework.Controllers
{
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Interfaces;

    public class HomeController : Controller
    {
        private const string LivePageMessage = "Live page with no caching";
        private const string LivePageNoCachingAndCorsMessage = "Live page with no caching and CORS";
        private const string CorsSettings = "*";

        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult LivePage(string param)
        {
            return new ContentActionResultWithoutCaching(this.Request, LivePageMessage);
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new ContentActionResultWithCorsWithoutCaching(this.Request, LivePageNoCachingAndCorsMessage, CorsSettings);
        }
    }
}