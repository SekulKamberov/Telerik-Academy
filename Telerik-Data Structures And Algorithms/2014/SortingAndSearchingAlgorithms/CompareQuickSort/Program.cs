namespace _01.HW
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void QuickSort(int[] collection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            int partitionIndex = Partition(collection, startIndex, endIndex);
            QuickSort(collection, startIndex, partitionIndex - 1);
            QuickSort(collection, partitionIndex + 1, endIndex);
        }
        static int Partition(int[] collection, int startIndex, int endIndex)
        {
            var pivot = collection[endIndex];
            int index1 = startIndex - 1;
            for (int index2 = startIndex; index2 < endIndex; index2++)
            {
                if (collection[index2].CompareTo(pivot) < 0)
                {
                    index1++;
                    var temp = collection[index1];
                    collection[index1] = collection[index2];
                    collection[index2] = temp;
                }
            }
            var temp1 = collection[index1 + 1];
            collection[index1 + 1] = collection[endIndex];
            collection[endIndex] = temp1;
            return index1 + 1;
        }

        static void Main(string[] args)
        {
            for (int n = 0; n < 5; n++)
            {
                Random ran = new Random();

                int numberOfElements = 1000;
                int[] arr = new int[numberOfElements];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = ran.Next(0, numberOfElements);
                }

                int[] arrCopy = new int[numberOfElements];
                Array.Copy(arr, arrCopy, numberOfElements);

                Stopwatch sw = new Stopwatch();
                sw.Start();
                MySort(arr, arr.Length);
                sw.Stop();
                //Console.WriteLine(string.Join(", ", arr));
                Console.WriteLine("MySort    Elapsed={0}", sw.Elapsed);

                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                QuickSort(arrCopy, 0, arrCopy.Length - 1);
                sw2.Stop();
                Console.WriteLine("QuickSort Elapsed={0}", sw2.Elapsed);
                Console.WriteLine();
            }
        }

        private static void MySort(int[] arr, int length)
        {
            for (int i = 0; i < (length / 2); i++)
            {
                int iMin = i;
                int iMax = length - i - 1;
                int innerLength = length - i;
                for (int j = i + 1; j < innerLength; j++)
                {
                    if (arr[iMin] > arr[j])
                    {
                        Swap(ref arr[iMin], ref arr[j]);
                        iMin = j;
                    }
                    if (arr[iMax] < arr[j])
                    {
                        iMax = j;
                        Swap(ref arr[iMax], ref arr[j]);
                        if (arr[iMin] > arr[j])
                        {
                            Swap(ref arr[iMin], ref arr[j]);
                        }
                    }
                }
                //Swap(ref arr[iMin], ref arr[i]);
                //Swap(ref arr[iMax], ref arr[length - i - 1]);
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

    }
}
