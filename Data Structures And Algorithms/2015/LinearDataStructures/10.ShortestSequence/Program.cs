namespace _10.ShortestSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = 5;
            int m = 16;
            int skip = 0;
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);

            while (true)
            {
                var newQueue = new Queue<int>();
                while (sequence.Count != 0)
                {
                    // take out
                    var length = skip + 1;
                    var numbers = new List<int>(length);
                    int lastNumberDequed = 0;

                    for (int i = 0; i < length; i++)
                    {
                        lastNumberDequed = sequence.Dequeue();
                        numbers.Add(lastNumberDequed);
                    }

                    // add in queue
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            newQueue.Enqueue(numbers[j]);
                        }

                        int lastAdded = 0;
                        if (i == 0)
                        {
                            lastAdded = lastNumberDequed + 1;
                        }
                        else if (i == 1)
                        {
                            lastAdded = lastNumberDequed + 2;
                        }
                        else if (i == 2)
                        {
                            lastAdded = lastNumberDequed * 2;
                        }

                        if (lastAdded == m)
                        {
                            numbers.Add(lastAdded);
                            Console.WriteLine(string.Join(" => ", numbers));
                            return;
                        }

                        newQueue.Enqueue(lastAdded);
                    }
                }

                skip++;
                sequence = newQueue;
            }
        }
    }
}
