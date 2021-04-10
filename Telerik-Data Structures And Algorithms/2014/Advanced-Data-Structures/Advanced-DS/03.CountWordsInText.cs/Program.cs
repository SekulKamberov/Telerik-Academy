namespace _03.CountWordsInText.cs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Timers;

    class Program
    {
        static void Main(string[] args)
        {
            string sourceFilePath = "../../Text.txt";
            string [] text = File.ReadAllLines(sourceFilePath);

            IDictionary<string, int> dict = new SortedDictionary<string, int>();
            char[] separator = new char[] {' ', '.', '!', '?' };
            string[] words;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            foreach (var line in text)
            {
                words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if(!(dict.ContainsKey(word)))
                    {
                        dict.Add(word, 0);
                    }
                    dict[word] += 1;
                }
            }

            timer.Stop();

            foreach (var word in dict)
            {
                Console.WriteLine(word.Key + " " + word.Value + " times");
            }

            Console.WriteLine(timer.Elapsed);


        }
    }
}
