
namespace Substring
{
    using System;
    using System.Text;

    public static class SubstringBuliderExtension
    {
        public static StringBuilder SubstringBuilder(this StringBuilder sb, int position)
        {
            string result = sb.ToString().Substring(position, sb.Length - position);
            StringBuilder resultSb = new StringBuilder(result);
            return resultSb;
        }

        public static StringBuilder SubstringBuilder(this StringBuilder sb, int position, int length)
        {
            string result = sb.ToString().Substring(position, length);
            StringBuilder resultSb = new StringBuilder(result);
            return resultSb;
        }
    }
}
