using System;

/*  Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding 
    tags [URL=…]…/URL].
    Example:                    input 	                                                output
<p>Please visit <a href="http://academy.telerik. com">           |<p>Please visit [URL=http://academy.telerik. com]our site[/URL] 
our site</a> to choose a training course. Also visit             |to choose a training course. Also visit [URL=www.devbg.org]our
<a href="www.devbg.org">our forum</a> to discuss the courses.</p>| forum[/URL] to discuss the courses.</p>          */

class ReplaceTags
{
    static void Main()
    {
        string text = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        string urlStart = "[URL=";
        string urlClose = "]";
        string urlEnd = "[/URL]";

        for (int i = 0; i < text.Length-9; i++)
        {
            if (text.Substring(i,9) == "<a href=\"")
            {
                text = text.Replace("<a href=\"", urlStart);
            }
            if (text.Substring(i,2) == "\">")
            {
                text = text.Replace("\">",urlClose);
            }
            if (text.Substring(i,4) == "</a>")
            {
                text = text.Replace("</a>", urlEnd);
            }
        }
        Console.WriteLine(text);
    }
}
