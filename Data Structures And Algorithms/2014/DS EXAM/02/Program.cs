using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static int[] shirts;

        static string[] skirts;

        static int numberOfGirls;

        static void ReaDInput()
        {
            int shirtsNumber = int.Parse(Console.ReadLine());

            shirts = new int[shirtsNumber];

            for (int i = 0; i < shirtsNumber; i++)
            {
                shirts[i] = i;
            }

            string skirtsString = Console.ReadLine();

            skirts = new string[skirtsString.Length];

            for (int i = 0; i < skirts.Length; i++)
            {
                skirts[i] = skirtsString[i].ToString();
            }

            numberOfGirls = int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            ReaDInput();


        }
    }
}
