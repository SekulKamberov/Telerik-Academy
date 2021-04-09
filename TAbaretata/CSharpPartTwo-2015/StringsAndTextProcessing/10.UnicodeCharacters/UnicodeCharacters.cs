using System;
using System.Text;

/*Write a program that converts a string to a sequence of C# Unicode character literals.Use format strings.
Example:    input 	    output
            Hi! 	    \u0048\u0069\u0021      */

class UnicodeCharacters
{
    static void Main()
    {
        string str = "Hi!";
        byte[] uniByte = Encoding.Unicode.GetBytes(str);
        string uniString = string.Empty;
        foreach (byte b in uniByte)
        {
            if (b == 0)
            {
                continue;
            }
            uniString += string.Format("{0}{1}", "\\u",b.ToString("X").PadLeft(4,'0'));
        }
        Console.WriteLine(uniString);
    }
}