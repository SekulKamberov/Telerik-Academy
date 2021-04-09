using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

//Write a program that reads a string from the console and lists all different words in the string
//along with information how many times each word is found.

class WordsCount
{
    static void Main()
    {
        string text = "text repeats repeats some text words repeats words words words";
        string[] words = text.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

        var dictionary = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (dictionary.ContainsKey(word))
            {
                dictionary[word]++;
            }
            else
            {
                dictionary.Add(word, 1);
            }
        }
        foreach (var word in dictionary.OrderBy(key => key.Value))
        {
            Console.WriteLine("{0} - {1} times", word.Key, word.Value);
        }
    }
}
