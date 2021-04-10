namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HighQualityCodeExamPointsProvider
    {
        private const string ContentType = "application/json";
        private const int MyPoints = 0;

        public static string GetContentType()
        {
            return ContentType;
        }

        public int GetMyPoints()
        {
            return MyPoints;
        }
    }
}