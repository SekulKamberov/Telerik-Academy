using System;

/*  Write a program that reads from the console a string of maximum 20 characters. If the length of the string 
    is less than 20, the rest of the characters should be filled with *.Print the result string into the console.
*/

class StringLength
{
    static void Main()
    {
        string text = Console.ReadLine();

        if (text.Length < 20)
        {
            Console.WriteLine(text.PadRight(20, '*'));
        }
        else
        {
            Console.WriteLine(text);
        }
    }
}
