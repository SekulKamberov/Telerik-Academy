using System;

/*  Write a program that extracts from a given text all sentences containing given word.
    Example: The word is: in
    The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. 
    So we are drinking all the day. We will move out of it in 5 days.
    The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.
    Consider that the sentences are separated by . and the words – by non-letter symbols.   */

class ExtractSentences
{
    static void Main()
    {
        string text = @"We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. 
    So we are drinking all the day. We will move out of it in 5 days.";
        string[] sentence = text.Split('.');

        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i].Contains(" in ") || sentence[i].Contains("In ") || sentence[i].Contains(" in"))
            {
                Console.Write(sentence[i].Trim() + ".");
            }
        }
        Console.WriteLine();
    }
}
