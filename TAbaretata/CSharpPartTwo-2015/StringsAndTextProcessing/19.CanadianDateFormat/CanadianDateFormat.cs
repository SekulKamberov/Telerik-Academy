using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
//Display them in the standard date format for Canada.

class CanadianDateFormat
{
    static void Main()
    {
        string text = "Dwayne Douglas Johnson was born 02.05.1972. The Rock gained fame in WWE from 03.1996 to 03/2004.";
        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            if (Regex.IsMatch(words[i], @"\b\d{1,2}\.\d{1,2}.\d{4}"))
            {
                if (Regex.IsMatch(words[i], @"..$"))
                {
                    words[i] = words[i].Remove(words[i].Length - 1);
                }
                DateTime date = DateTime.ParseExact(words[i], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine(date.ToShortDateString().ToString(new CultureInfo("en-CA")));
            }
        }
    }
}