using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashDictionary<string, int>();
            table.Add("P", 2);
            table.Add("A", 3);
            table.Add("B", 4);

            Console.WriteLine(table.ContainsKey("P"));
            Console.WriteLine(table.ContainsKey("P2"));

            foreach (var pair in table)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
            Console.WriteLine();

            //Console.WriteLine(table.Find("B"));
            //Console.WriteLine(table["P"]);
            //table["P"] = 5;
            //Console.WriteLine(table["P"]);
            //Console.WriteLine(table["D"]);
            //Console.WriteLine();

            Console.WriteLine("!!!!!!!!!!!!!!!!!");
            table.Remove("P");
            foreach (var pair in table)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
        }

    }
}
