using System;
using System.Text;

/*Write a program that reads a string from the console and replaces all series of consecutive identical letters 
    with a single one.
    Example:            input 	                        output
                        aaaaabbbbbcdddeeeedssaa 	    abcdedsa            */

class SeriesOfLetters
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder letters = new StringBuilder();

        letters.Append(text[0]);

        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != text[i - 1])
            {
                letters.Append(text[i]);
            }
        }
        Console.WriteLine(letters.ToString());
    }
}
