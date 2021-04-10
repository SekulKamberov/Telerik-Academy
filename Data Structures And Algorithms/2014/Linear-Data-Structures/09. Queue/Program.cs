namespace _09.Queue
{
    using System;
    using System.Collections.Generic;

    public class Sequence
    {
        //  09. We are given the following sequence:
        //  S1 = N;
        //  S2 = S1 + 1;
        //  S3 = 2*S1 + 1;
        //  S4 = S1 + 2;
        //  S5 = S2 + 1;
        //  S6 = 2*S2 + 1;
        //  S7 = S2 + 2;
        //  ...
        //  Using the Queue<T> class write a program to print its first 50 members for given N.
        //  Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

        public static void FindSequence(int startNumber)
        {
            Queue<int> sequence = new Queue<int>();
            Queue<int> tempSequence = new Queue<int>();

            int S1 = startNumber;
            int S2;
            int S3;
            int S4;

            sequence.Enqueue(S1);

            for (int i = 0; i < 50; i+=3)
            {
                S2 = S1 + 1;
                S3 = 2*S1 + 1;
                S4 = S1 + 2;
                sequence.Enqueue(S2);
                sequence.Enqueue(S3);
                sequence.Enqueue(S4);
                tempSequence.Enqueue(S2);
                tempSequence.Enqueue(S3);
                tempSequence.Enqueue(S4);
                S1 = tempSequence.Dequeue();
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(sequence.Dequeue() + ", ");
            }
        } 

        static void Main(string[] args)
        {
            int N = 2;
            FindSequence(N);
        }
    }
}
