using System;
using System.Text;

/*  You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and 
    </upcase> to upper-case.The tags cannot be nested.
    Example: We are living in a yellow submarine. We don't have anything else.
    The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
 */

class ParseTags
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        StringBuilder uppercaseText = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '<')
            {
                i += 8;
                while (text[i] != '<')
                {
                    uppercaseText.Append(text[i].ToString().ToUpper());
                    i++;
                }
                i += 8;
            }
            else
            {
                uppercaseText.Append(text[i]);
            }
        }
        Console.WriteLine(uppercaseText.ToString());
    }
}
