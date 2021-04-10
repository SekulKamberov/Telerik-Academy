using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountWordFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 03. Write a program that counts how many times each word from given text file words.txt appears in it. 
             * The character casing differences should be ignored. 
             * The result words should be ordered by their number of occurrences in the text.   
             * 
             * Example: This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
	         *  is  2
	         *  the  2
	         *  this  3
	         *  text  6
            */

            string text = System.IO.File.ReadAllText(@"..\..\words.txt");
            Console.WriteLine(text);

            char[] separator = {',', ' ', '!', '.', '?', '-'};
            string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            IDictionary<string, int> dictionary = new SortedDictionary<string, int>();

            foreach (var word in words)
            {
                var wordToLower = word.ToLower();
                if (!(dictionary.ContainsKey(wordToLower)))
                {
                    dictionary.Add(wordToLower, 0);
                }
                dictionary[wordToLower] += 1;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("Key: {0} Value: {1}", item.Key, item.Value);
            }
            Console.WriteLine();

            System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\result.txt");
            var order = from item in dictionary
                        orderby item.Value
                        select item.Key + " -> " + item.Value;

            foreach (var item in order)
            {
                file.WriteLine(item);
                Console.WriteLine(item);
            }

            file.Close();
        }
    }
}
