using System;
using System.Text.RegularExpressions;

//Write a program for extracting all email addresses from given text.
//All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.

class ExtractEmails
{
    static void Main()
    {
        string text =  "Email examples example@abv.bg or dwayne.johnson@gmail.com are valid.These emails: example@yahoo.  @academy.com how@you.is. are not valid.";
        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string regex = @"^([a-zA-Z0-9_\-][a-zA-Z0-9_\-\.]{0,49})" + @"@(([a-zA-Z0-9][a-zA-Z0-9\-]{0,49}\.)+[a-zA-Z]{2,4})$";

        Console.WriteLine("Extracted e-mail addresses: ");
        for (int i = 0; i < words.Length; i++)
        {
            if (Regex.IsMatch(words[i],regex))
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}
