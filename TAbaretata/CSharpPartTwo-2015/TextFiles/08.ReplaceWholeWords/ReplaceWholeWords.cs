using System;
using System.Collections.Generic;
using System.IO;

//Modify the solution of the previous problem to replace only whole words (not strings).

class ReplaceWholeWords
{
    static void Main()
    {
        //files are in 'bin/Debug' directory of the project
        using (StreamReader reader = new StreamReader("text.txt"))
        {
            using (StreamWriter output = new StreamWriter("result.txt"))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    for (int i = line.IndexOf("start"); i != -1; i = line.IndexOf("start", i + 1))
                    {
                        if ((i - 1 < 0 || !Char.IsLetter(line[i - 1])) && (i + 5 >= line.Length) || !Char.IsLetter(line[i + 5]))
                        {
                            line = line.Insert(i, "finish").Remove(i + 6, 5);
                        }
                    }
                    output.WriteLine(line);
                }
            }
        }
        Console.WriteLine("Replacing done!");
    }
}
