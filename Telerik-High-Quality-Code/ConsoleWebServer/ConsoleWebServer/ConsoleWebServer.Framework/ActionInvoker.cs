namespace ConsoleWebServer.Framework
{
    using System.Linq;
    using System.Reflection;

    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Controllers;
    using ConsoleWebServer.Framework.Exceptions;
    using ConsoleWebServer.Framework.Interfaces;

    public class ActionInvoker
    {
        private const string ExceptionStringFormat = "Expected method with signature IActionResult {0}(string) in class {1}Controller";

        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            var methodWithIntParameter = controller.GetType()
                         .GetMethods()
                         .FirstOrDefault(x => x.Name.ToLower() == actionDescriptor.ActionName.ToLower() && x.GetParameters().Length == 1
                             && x.GetParameters()[0].ParameterType == typeof(string) && x.ReturnType == typeof(IActionResult));
            if (methodWithIntParameter == null)
            {
                throw new HttpNotFound(string.Format(ExceptionStringFormat, actionDescriptor.ActionName, actionDescriptor.ControllerName));
            } 
            
            try
            {
                var actionResult = (IActionResult)methodWithIntParameter.Invoke(controller, new object[] { actionDescriptor.Parameter });
                return actionResult;
            }
            catch (TargetInvocationException ex) 
            { 
                throw ex.InnerException; 
            }
        }
    }
}