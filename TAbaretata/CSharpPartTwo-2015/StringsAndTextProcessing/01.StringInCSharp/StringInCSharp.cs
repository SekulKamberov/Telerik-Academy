using System;
using System.Text;

//Describe the strings in C#.What is typical for the string data type?Describe the most important methods of the String class.

class StringInCSharp
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(new string('-', 15));
        sb.AppendLine(@"A string is an object of type String whose value is text. Internally, 
the text is stored as a sequential read-only collection of Char objects. 
The Length property of a string represents the number of Char objects it contains, not the number of Unicode characters. 
To access the individual Unicode code points in a string, use the StringInfo object.");
        sb.AppendLine(new string('-',15));
        sb.AppendLine("Important C# string methods:");
        sb.AppendLine("string.Compare(): Compares String objects.Has different overloads.");
        sb.AppendLine("string.Equals(): Determines whether two specified String objects have the same value.");
        sb.AppendLine("string.IndexOf(): Finding a character or substring within given string.");
        sb.AppendLine("string.Substring(): Extract substring from the String object.");
        sb.AppendLine("string.Split(): Splits string object by given separator.");
        sb.AppendLine(new string('-', 15));

        Console.WriteLine(sb.ToString());
    }
}