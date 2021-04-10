namespace _01.TreeNodes
{
    using System;
    using System.Collections.Generic;

    public class TreeNode
    {
        public TreeNode(int value)
        {
            this.Value = value;
            this.Children = new List<TreeNode>();
        }

        public int Value { get; set; }

        public List<TreeNode> Children { get; set; }
    }

    public class Tree
    {
        public TreeNode Root { get; set; }

        public void Add(int parentValue, int numberValue)
        {
            TreeNode childNode = new TreeNode(numberValue);
            if (this.Root != null)
            {
                TreeNode parent = this.FindParentOf(parentValue);
                if(parent != null)
                {
                    parent.Children.Add(childNode);
                }
                else
                {
                    TreeNode newRoot = new TreeNode(parentValue);
                    newRoot.Children.Add(this.Root);
                    this.Root = newRoot;
                }
            }
            else
            {
                TreeNode parentNode = new TreeNode(parentValue);
                parentNode.Children.Add(childNode);
                this.Root = parentNode;
            }
        }

        private TreeNode FindParentOf(int parentValue)
        {
            if(this.Root.Value == parentValue)
            {
                return this.Root;
            }
            else
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                PushChildren(stack, this.Root);
                
                while (stack.Count != 0)
                {
                    TreeNode node = stack.Pop();
                    if (node.Value == parentValue)
                    {
                        return node;
                    }
                    else if(node.Children.Count != 0)
                    {
                        PushChildren(stack, node);
                    }
                }

                return null;
            }
        }
        private void PushChildren(Stack<TreeNode> stack, TreeNode node)
        {
            List<TreeNode> children = node.Children;
            for (int i = 0; i < children.Count; i++)
            {
                stack.Push(children[i]);
            }
        }

        public void ReadTree()
        {
            TreeNode root = this.Root;
            Console.WriteLine("Root: " + this.Root.Value);
            Stack<TreeNode> stack = new Stack<TreeNode>();
            PushChildren(stack, root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                    if (node.Children.Count != 0)
                    {
                        PushChildren(stack, node);
                        Console.WriteLine("Middle node: " + node.Value);
                    }
                    else
                    {
                        Console.WriteLine("Leaf node: " + node.Value);
                    }
            }
        }
    }
    public class Program
    {
        public static int ReadNumber(int max = int.MaxValue)
        {
            bool isNumber = false;
            string input;
            int number = 0;
            while (!isNumber)
            {
                input = Console.ReadLine();
                isNumber = Int32.TryParse(input, out number);
                if (isNumber == false)
                {
                    Console.WriteLine("Insert number not string!");
                }
                if (number < 0)
                {
                    isNumber = false;
                    Console.WriteLine("Insert positive number!");
                }
                if (number >= max )
                {
                    isNumber = false;
                    Console.WriteLine("Insert number < max");
                }
            }
            return number;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Insert N: ");
            int N = ReadNumber();
            Stack<int> setOfNumbers = new Stack<int>();
            for (int i = 0; i < N - 1; i++)
            {
                // parent
                Console.WriteLine("Insert parent: ");
                setOfNumbers.Push(ReadNumber(N));
                //child
                Console.WriteLine("Insert child: ");
                setOfNumbers.Push(ReadNumber(N));
            }

            Tree tree = new Tree();
            int length = setOfNumbers.Count;
            for (int i = 0; i < length; i+=2)
            {
                int child = setOfNumbers.Pop();
                int parent = setOfNumbers.Pop();
                tree.Add(parent, child);
            }

            tree.ReadTree();

            //List<int> parents = new List<int>();
            //List<int> children = new List<int>();
            //for (int i = 0; i < N - 1; i++)
            //{
            //    int parent = ReadNumber(N);
            //    if(!parents.Contains(parent))
            //    {
            //        parents.Add(parent);
            //    }

            //    int child = ReadNumber(N);
            //    if (!children.Contains(child))
            //    {
            //        children.Add(child);
            //    }
            //}

            //for (int i = 0; i < parents.Count; i++)
            //{
            //    if (!children.Contains(parents[i]))
            //    {
            //        Console.WriteLine("Root node= " + parents[i]);
            //    }
            //}
            //for (int i = 0; i < children.Count; i++)
            //{
            //    if (!parents.Contains(children[i]))
            //    {
            //        Console.WriteLine("Child node = " + children[i]);
            //    }
            //}
            //for (int i = 0; i < parents.Count; i++)
            //{
            //    if (children.Contains(parents[i]))
            //    {
            //        Console.WriteLine("Middle node = " + parents[i]);
            //    }
            //}
        }
    }
}
