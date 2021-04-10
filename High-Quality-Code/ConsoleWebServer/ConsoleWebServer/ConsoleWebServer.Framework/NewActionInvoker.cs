namespace ConsoleWebServer.Framework
{
    using ConsoleWebServer.Framework.Controllers;
    using ConsoleWebServer.Framework.Interfaces;

    public class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}