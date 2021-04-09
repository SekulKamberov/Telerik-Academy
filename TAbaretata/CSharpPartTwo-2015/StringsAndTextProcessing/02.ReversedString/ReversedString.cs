using System;
using System.Text;

/*Write a program that reads a string, reverses it and prints the result at the console.
Example:
input 	output
sample 	elpmas
*/

class ReversedString
{
    static void Main()
    {
        Console.Write("Enter string to reverse: ");
        string input = Console.ReadLine();
        StringBuilder reversed = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed.Append(input[i]);
        }
        string result = reversed.ToString();
        Console.WriteLine(result);
    }
}
