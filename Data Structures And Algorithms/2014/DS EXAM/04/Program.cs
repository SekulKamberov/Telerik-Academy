using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    class Program
    {
        static int len;

        static int[] sequenceRigth;
        static int[] sequenceLeft;
        static int[] dict;
        static void Main(string[] args)
        {
            ReadGraph();

            int leftMax = 1;

            for (int i = 1; i < len; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (dict[i] > dict[j] && sequenceLeft[i] <= sequenceLeft[j])
                    {
                        sequenceLeft[i] = sequenceLeft[j] + 1;
                        if (leftMax < sequenceLeft[i])
                        {
                            leftMax = sequenceLeft[i];
                        }
                    }
                }
            }

            //Console.WriteLine(string.Join(", ", sequenceLeft.Values));

            int rigthMax = 1;
            for (int i = len - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (dict[i] > dict[j] && sequenceRigth[i] <= sequenceRigth[j])
                    {
                        sequenceRigth[i] = sequenceRigth[j] + 1;
                        if (rigthMax < sequenceRigth[i])
                        {
                            rigthMax = sequenceRigth[i];
                        }
                    }
                }
            }

            int MAX = 0;

            for (int i = 0; i < len; i++)
            {
                var max = sequenceLeft[i] + sequenceRigth[i];
                if (MAX < max)
                {
                    MAX = max;
                }
            }

            Console.WriteLine(MAX + 1);

            //Console.WriteLine(string.Join(", ", sequenceRigth.Values));

        }

        public static void ReadGraph()
        {
            len = int.Parse(Console.ReadLine());
            dict = new int[len];
            sequenceLeft = new int[len];
            sequenceRigth = new int[len];

            for (int i = 0; i < len; i++)
            {
                string townInfo = Console.ReadLine();
                dict[i] = int.Parse(townInfo.Substring(0, townInfo.IndexOf(' ')));
            }
        }
    }
}