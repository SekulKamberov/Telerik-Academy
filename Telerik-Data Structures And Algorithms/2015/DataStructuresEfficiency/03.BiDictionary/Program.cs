namespace _03.BiDictionary
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            BiDictionary<int, string, string> dictionary = new BiDictionary<int, string, string>();
            var key1 = 1;
            var key2 = "2";
            dictionary.Add(key1, key2, "valid keys 1");
            dictionary.Add(key1, key2, "valid keys 2");
            Console.WriteLine("==========Find(key1)==========");
            Console.WriteLine(dictionary.Find(key1));
            Console.WriteLine("==========Find(key2)==========");
            Console.WriteLine(dictionary.Find(key2));
            Console.WriteLine("==========Find(key1, key2)==========");
            Console.WriteLine(dictionary.Find(key1, key2));
            var key3 = 1;
            var key4 = "4";
            dictionary.Add(key3, key4, "default value INVALID");
        }
    }
}
