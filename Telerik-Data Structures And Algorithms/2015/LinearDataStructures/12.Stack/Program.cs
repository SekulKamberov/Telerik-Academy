namespace _12.Stack
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();
            Console.WriteLine(stack);
            stack.Push(1);
            Console.WriteLine(stack);
            stack.Push(2);
            Console.WriteLine(stack);
            stack.Push(3);
            Console.WriteLine(stack);
            stack.Push(4);
            Console.WriteLine(stack);
            stack.Push(5);
            Console.WriteLine(stack);
            stack.Push(6);
            Console.WriteLine(stack);

            Console.WriteLine("Containes(4): {0}", stack.Contains(4));
            Console.WriteLine("Containes(7): {0}", stack.Contains(7));

            // stack.Clear();
            // Console.WriteLine(stack);
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Console.WriteLine(stack);
            stack.TrimExcess();
            Console.WriteLine(stack);
            stack.Pop();
            Console.WriteLine(stack);
            Console.WriteLine("Peek() => {0}\n", stack.Peek());
            Console.WriteLine(stack);

            // stack.Pop();
            // Console.WriteLine(stack);
            // stack.Pop();
            // Console.WriteLine(stack);
        }
    }
}
