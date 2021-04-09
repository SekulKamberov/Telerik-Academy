using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array.

class IndexOfLetters
{
    static void Main()
    {
        char[] charArr = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n'
            , 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        Console.Write("Enter word: ");
        string word = Console.ReadLine();
        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < charArr.Length; j++)
            {
                if (charArr[j] == word[i])
                {
                    Console.WriteLine("Letter \"{0}\" has index: {1}", word[i], j);
                }
            }
        }
    }
}
