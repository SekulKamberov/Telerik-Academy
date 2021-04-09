using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

//Write a program that removes from a text file all words listed in given another text file.
//Handle all possible exceptions in your methods.

class DeleteDuplicatingWords
{
    static void Main()
    {
        try
        {
            //files are in 'bin/Debug' directory of the project
            string allLines = String.Join(" ", File.ReadAllLines("secondfile.txt"));
            string[] allWords = allLines.Split(' ');
            using (StreamReader start = new StreamReader("mainfile.txt"))
            {
                string line = start.ReadLine();
                using (StreamWriter finish = new StreamWriter("finish.txt"))
                {
                    while (line != null)
                    {
                        for (int i = 0; i < allWords.Length; i++)
                        {
                            string word = "\\b" + allWords[i] + "\\b";
                            line = Regex.Replace(line, word, "");
                        }
                        finish.WriteLine(line);
                        line = start.ReadLine();
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("{0}:{1}", e.GetType().Name, e.Message);
        }
        Console.WriteLine("Deleting duplicated words was succesful.");
    }
}
