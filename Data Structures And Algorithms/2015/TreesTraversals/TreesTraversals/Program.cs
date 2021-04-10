namespace TreesTraversals
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
            Console.WriteLine("Insert N: ");
            int numberOfNodes = int.Parse(Console.ReadLine());
            Tree tree = new Tree();
            Queue<int[]> notAdded = new Queue<int[]>();
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                Console.WriteLine("Insert parent[{0}] and child[{0}] values separated: ", i);
                string line = Console.ReadLine();
                string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(values[0]);
                int child = int.Parse(values[1]);
                if (tree.Add(parent, child) == false)
                {
                    notAdded.Enqueue(new int[] { parent, child });
                }
            }

            while (notAdded.Count != 0)
            {
                int[] parentChildValues = notAdded.Dequeue();
                int parent = parentChildValues[0];
                int child = parentChildValues[1];
                if (tree.Add(parent, child) == false)
                {
                    notAdded.Enqueue(parentChildValues);
                }
            }

            tree.ReadTree();
            Console.WriteLine("=====Root=====");
            Console.WriteLine(tree.Root);

            var leadNodes = tree.GetLeafNodes();
            Console.WriteLine("=====LeafNodes=====");
            for (int i = 0; i < leadNodes.Count; i++)
            {
                Console.WriteLine(leadNodes[i]);
            }

            var middleNodes = tree.GetMiddleNodes();
            Console.WriteLine("=====MiddleNodes=====");
            for (int i = 0; i < middleNodes.Count; i++)
            {
                Console.WriteLine(middleNodes[i]);
            }

            Console.WriteLine();
            Console.WriteLine("=====Longest path=====");
            Console.WriteLine(string.Join(", ", tree.GetLongestPath()));

            Console.WriteLine();
            Console.WriteLine("=====All paths with Sum 9 =====");
            tree.PrintPathsBySum(9);

            Console.WriteLine();
            Console.WriteLine("=====All subtrees with Sum 6 =====");
            tree.FindSubtreesWithGivenSum(6);
            Console.WriteLine();
            Console.WriteLine("=====All subtrees with Sum 12 =====");
            tree.FindSubtreesWithGivenSum(12);
            Console.WriteLine();
            Console.WriteLine("=====All subtrees with Sum 21 =====");
            tree.FindSubtreesWithGivenSum(21);
        }
    }
}
