namespace ConsoleWebServer.Framework.Interfaces
{
    /// <summary>
    /// Represents the responce provider
    /// </summary>
    public interface IResponseProvider
    {
        /// <summary>
        /// Returns HttpResponce base on the provider's request string
        /// </summary>
        /// <param name="requestAsString">the request string</param>
        /// <returns></returns>
        HttpResponse GetResponse(string requestAsString);
    }
}