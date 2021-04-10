namespace CompareQuickSortObject
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void QuickSort(Person[] collection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            int partitionIndex = Partition(collection, startIndex, endIndex);
            QuickSort(collection, startIndex, partitionIndex - 1);
            QuickSort(collection, partitionIndex + 1, endIndex);
        }
        static int Partition(Person[] collection, int startIndex, int endIndex)
        {
            var pivot = collection[endIndex];
            int index1 = startIndex - 1;
            for (int index2 = startIndex; index2 < endIndex; index2++)
            {
                if (collection[index2].Name.CompareTo(pivot.Name) < 0)
                {
                    index1++;
                    Swap(ref collection[index1], ref collection[index2]);
                }
            }

            Swap(ref collection[index1 + 1], ref collection[endIndex]);
            return index1 + 1;
        }

        static void Main(string[] args)
        {
            for (int n = 0; n < 5; n++)
            {
                Random ran = new Random();

                int numberOfElements = 10000;
                int[] arr = new int[numberOfElements];

                Person [] personArray = new Person[numberOfElements];
                Console.Write("Generating person array...");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = ran.Next(0, numberOfElements);
                    Person person = new Person();
                    person.Id = i;
                    person.Name = i + "Name";
                    person.Fname = "Fname" + i;
                    personArray[i] = person;
                    Console.Write(".");
                }
                Console.WriteLine("...complete!");
                int[] arrCopy = new int[numberOfElements];
                Array.Copy(arr, arrCopy, numberOfElements);

                //Stopwatch sw2 = new Stopwatch();
                //sw2.Start();
                //QuickSort(arrCopy, 0, arrCopy.Length - 1);
                //sw2.Stop();
                //Console.WriteLine("QuickSort Elapsed={0}", sw2.Elapsed);
                //Console.WriteLine();

                Stopwatch sw3 = new Stopwatch();
                sw3.Start();
                QuickSort(personArray, 0, personArray.Length - 1);
                sw3.Stop();
                Console.WriteLine("QuickSortObject Elapsed={0}", sw3.Elapsed);
                Console.WriteLine();
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

    }

    class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Fname { get; set; }
    }
}
