namespace _01.PriorityQueue
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    public class Comper : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
    public class Testing
    {
        public static void Main()
        {
            TestHeapInt();
            TestHeapIntWithComparator();
            var priorQ = new PriorityQueue<string>();
            priorQ.Enqueue("asd");
            priorQ.Enqueue("zzz");
            priorQ.Enqueue("aaaa");
            priorQ.Enqueue("fffff");
            Console.WriteLine(priorQ.Dequeue());
        }
        private static void TestHeapInt()
        {
            var heap = new BinaryHeap<int>();
            heap.Add(4);
            heap.Add(7);
            heap.Add(1);
            heap.Add(777);
            heap.Add(12);
            heap.Add(3);
            heap.RemoveTop();
            Console.WriteLine(heap.GetTopElement());
        }
        private static void TestHeapIntWithComparator()
        {
            var comper = new Comper();
            var heap = new BinaryHeap<int>(comper);
            heap.Add(4);
            heap.Add(7);
            heap.Add(1);
            heap.Add(777);
            heap.Add(12);
            heap.Add(3);
            heap.RemoveTop();
            Console.WriteLine(heap.GetTopElement());
        }
    }
}