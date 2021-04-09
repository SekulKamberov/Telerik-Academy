using System;

/*  Write a program that encodes and decodes a string using given encryption key (cipher).
    The key consists of a sequence of characters.
    The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the 
    string with the first of the key, the second – with the second, etc. When the last key character is reached,
    the next is the first.
*/

class EncodeDecode
{
    static void Main()
    {
        string text = "The key is important.Don't forget your key.";
        string key = "key";
        char[] charArr = text.ToCharArray();

        for (int i = 0; i < charArr.Length; i++)
        {
            for (int j = 0; j < key.Length; j++)
            {
                charArr[i] ^= key[j];
            }
        }
        text = new string(charArr);
        Console.WriteLine(text);
    }
}