using System;
using System.Collections.Generic;
using System.IO;

//Write a program that deletes from given text file all odd lines.The result should be in the same file.

class DeleteOddLines
{
    static void Main()
    {
        //file is in 'bin/Debug' directory of the project
        List<string> evenLines = new List<string>();
        using (StreamReader reader = new StreamReader("text.txt"))
        {
            int lineNum = 1;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (lineNum % 2 == 0)
                {
                    evenLines.Add(line);
                }
                lineNum++;
                line = reader.ReadLine();
            }
        }
        using (StreamWriter output = new StreamWriter("text.txt"))
        {
            for (int i = 0; i < evenLines.Count; i++)
            {
                output.WriteLine(evenLines[i]);
            }
        }
        Console.WriteLine("Odd lines removed!");
    }
}
