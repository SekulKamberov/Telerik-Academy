namespace AdvancedDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            var comparerDesc = new StringComparerDescending();
            var comparerAsc = new StringComparerAscending();
            var priorityQueue = new PriorityQueue<string>();
            priorityQueue.Enqueue("E");
            Console.WriteLine(priorityQueue);
            priorityQueue.Enqueue("B");
            Console.WriteLine(priorityQueue);
            priorityQueue.Enqueue("G");
            Console.WriteLine(priorityQueue);
            priorityQueue.Enqueue("Z");
            Console.WriteLine(priorityQueue);
            priorityQueue.Enqueue("M");
            Console.WriteLine(priorityQueue);
            priorityQueue.Enqueue("D");
            Console.WriteLine(priorityQueue);
            priorityQueue.Enqueue("A");
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            Console.WriteLine(priorityQueue);
            priorityQueue.Dequeue();
            Console.WriteLine(priorityQueue);
        }
    }
}
