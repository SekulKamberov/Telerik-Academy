/*
 * Problem 1: Implement an extension method Substring(int index, int length) for the class StringBuilder that returns 
                new StringBuilder and has the same functionality as Substring in the class String.
*/
namespace Substring
{
    using System;
    using System.Text;

    public class Test
    {
        public static void Main()
        {
            string test = "WTF am I doing here";
            var sb = new StringBuilder();
            sb.Append(test);

            Console.WriteLine(sb.SubstringBuilder(0, 3));
            Console.WriteLine(sb.SubstringBuilder(4));
        }
    }
}
