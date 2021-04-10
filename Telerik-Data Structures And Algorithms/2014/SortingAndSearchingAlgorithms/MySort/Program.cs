namespace MySort
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        static Random random;
        static int[] numbers;
        static int length;
        static int halfLength;
        static int min;
        static int max;
        static void Main(string[] args)
        {
            for (int k = 0; k < 5; k++)
            {

                random = new Random();
                int arrayLength = 10000;
                numbers = new int[arrayLength];
                length = numbers.Length;
                halfLength = length / 2;

                for (int i = 0; i < length; i++)
                {
                    numbers[i] = random.Next(arrayLength);
                }

                Stopwatch sw = new Stopwatch();
                sw.Start();
                OutherLoop(0);
                sw.Stop();
                //Console.WriteLine(string.Join(", ", numbers));
                Console.WriteLine("MySort    Elapsed={0}", sw.Elapsed);
            }
        }

        private static void OutherLoop(int i)
        {
            if (i == halfLength)
            {
                return;
            }

            int iMin = i;
            int iMax = length - i - 1;
            int innerLength = length - i;
            for (int j = i + 1; j < innerLength; j++)
            {
                if (numbers[iMin] > numbers[j])
                {
                    //if (iMax == (j - 1))
                    //{
                    //    iMax = j;
                    //}
                    Swap(ref numbers[iMin], ref numbers[j]);
                }
                if (numbers[iMax] < numbers[j])
                {
                    Swap(ref numbers[iMax], ref numbers[j]);
                    if (numbers[iMin] > numbers[j])
                    {
                        Swap(ref numbers[iMin], ref numbers[j]);
                    }
                }
            }

            OutherLoop(i + 1);
        }

        private static void Inner(int j, int len, int i)
        {
            if (j == len)
            {
                return;
            }
            if (numbers[min] > numbers[j])
            {
                Swap(ref numbers[min], ref numbers[j]);
            }
            if (numbers[max] < numbers[j])
            {
                Swap(ref numbers[max], ref numbers[j]);
                if (numbers[min] > numbers[j])
                {
                    Swap(ref numbers[min], ref numbers[j]);
                }
            }

            Inner(j + 1, len, i);

        }
        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
