using System;
using System.Collections.Generic;
using System.Text;

/*  Write a program that reverses the words in given sentence.
    Example:                input 	                                    output
            C# is not C++, not PHP and not Delphi! 	            Delphi not and PHP, not C++ not is C#!  */

class ReverseSentence
{
    static void Main()
    {
        string text = "C# is not C++, not PHP and not Delphi!";

        string[] words = text.Split(new char[] { ' ', '!', '?', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

        //creating List to exclude the following chars from it.This list is for the spliting elements like ' ','.', etc.
        List<char> signs = new List<char>();

        for (char i = 'a'; i <= 'z'; i++)
        {
            signs.Add(i);
        }
        for (char i = 'A'; i <= 'Z'; i++)
        {
            signs.Add(i);
        }
        for (char i = '0'; i <= '9'; i++)
        {
            signs.Add(i);
        }
        signs.Add('#');
        signs.Add('+');

        //this array holds the spliting elements
        string[] splitElements = text.Split(signs.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        Array.Reverse(words);

        var reversedText = new StringBuilder();

        for (int i = 0; i < splitElements.Length; i++)
        {
            reversedText.Append(words[i]);
            reversedText.Append(splitElements[i]);
        }
        Console.WriteLine(reversedText.ToString());
    }
}
