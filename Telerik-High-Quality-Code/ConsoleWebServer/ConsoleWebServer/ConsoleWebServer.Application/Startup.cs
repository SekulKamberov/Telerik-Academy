namespace ConsoleWebServer.Application
{
    using System;
    using System.Text;

    using ConsoleWebServer.Framework;

    public static class Startup
    {
        public static void Main()
        {
            ResponseProvider responseProvider = new ResponseProvider();
            var stringBuilder = new StringBuilder();
            string inputLine;

            while ((inputLine = Console.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = responseProvider.GetResponse(stringBuilder.ToString());
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(response);
                    Console.ResetColor();
                    stringBuilder.Clear();
                    continue;
                }

                stringBuilder.AppendLine(inputLine);
            }
        }
    }
}