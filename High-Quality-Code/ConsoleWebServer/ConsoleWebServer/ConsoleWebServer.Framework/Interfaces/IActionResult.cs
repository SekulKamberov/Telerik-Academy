namespace ConsoleWebServer.Framework.Interfaces
{
    /// <summary>
    /// Represents the result of action method witch return HttpResponse
    /// </summary>
    public interface IActionResult
    {
        /// <summary>
        /// Returns the http response
        /// </summary>
        /// <returns></returns>
        HttpResponse GetResponse();
    }
}