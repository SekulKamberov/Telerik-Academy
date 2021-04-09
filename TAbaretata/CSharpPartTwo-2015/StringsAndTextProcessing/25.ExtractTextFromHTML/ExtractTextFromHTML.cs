using System;
using System.Linq;
using System.Text.RegularExpressions;

/*Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
Example input:                                                              Output:
<html>
  <head><title>News</title></head>                                          Title: News
  <body><p><a href="http://academy.telerik.com">Telerik                     Text: Telerik Academy aims to provide  
    Academy</a>aims to provide free real-world practical                    free real-world practical training
    training for young people who want to turn into                         for young people who want to turn 
    skilful .NET software engineers.</p></body>                             into skilful .NET software engineers.   
</html>             */

class ExtractTextFromHTML
{
    static void Main()
    {
        string text = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.</p></body></html>";
        
        MatchCollection tags = Regex.Matches(text, @"((?<=^|>)[^><]+?(?=<|$))");
        int count = 1;

        foreach (Match tag in tags)
        {
            if (count == 1)
            {
                Console.WriteLine("Title: {0}", tag);
                Console.Write("Text: ");
            }
            else
            {
                Console.Write(tag + " ");
            }
            count++;
        }
        Console.WriteLine();
    }
}
