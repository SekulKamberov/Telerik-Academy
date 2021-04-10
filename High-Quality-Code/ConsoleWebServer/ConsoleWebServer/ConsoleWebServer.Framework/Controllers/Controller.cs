namespace ConsoleWebServer.Framework.Controllers
{
    using System.Text;

    using ConsoleWebServer.Framework.Interfaces;

    public abstract class Controller
    {
        protected Controller(HttpRequest httpRequest)
        { 
            this.Request = httpRequest; 
        }

        public HttpRequest Request { get; private set; }

        protected IActionResult Content(object model) 
        {
            return new ContentActionResult(this.Request, model); 
        }

        protected IActionResult Json(object model) 
        {
            return new JsonActionResult(this.Request, model); 
        }
    }
}