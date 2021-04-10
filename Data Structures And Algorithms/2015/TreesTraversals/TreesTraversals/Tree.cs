namespace TreesTraversals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tree
    {
        public TreeNode Root { get; set; }

        public bool Add(int parentValue, int childValue)
        {
            if (this.Root != null)
            {
                TreeNode foundParentNode = this.FindNode(parentValue);
                TreeNode foundChildNode = this.FindNode(childValue);

                if (foundParentNode == null && foundChildNode != null)
                {
                    // parent not found, child found
                    TreeNode parentNode = new TreeNode(parentValue);
                    parentNode.Children.Add(foundChildNode);
                    this.Root = parentNode;
                    return true;
                }
                else if (foundParentNode != null && foundChildNode == null) 
                {
                    // parent found, child not found
                    TreeNode childNode = new TreeNode(childValue);
                    foundParentNode.Children.Add(childNode);
                    return true;
                }

                return false;
            }
            else
            {
                TreeNode parentNode = new TreeNode(parentValue);
                TreeNode childNode = new TreeNode(childValue);
                parentNode.Children.Add(childNode);
                this.Root = parentNode;
                return true;
            }
        }

        public void ReadTree(TreeNode root = null)
        {
            if (root == null)
            {
                root = this.Root;
            }

            Console.WriteLine("\nRoot: " + root.Value);
            Stack<TreeNode> stack = new Stack<TreeNode>();
            this.PushChildren(stack, root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                if (node.Children.Count != 0)
                {
                    this.PushChildren(stack, node);
                    Console.WriteLine("Middle node: " + node.Value);
                }
                else
                {
                    Console.WriteLine("Leaf node: " + node.Value);
                }
            }
        }

        public List<TreeNode> GetLeafNodes()
        {
            List<TreeNode> leafNodes = new List<TreeNode>();
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            nodes.Push(this.Root);
            while (nodes.Count != 0)
            {
                var currentNode = nodes.Pop();
                if (currentNode.Children.Count == 0)
                {
                    leafNodes.Add(currentNode);
                }
                else
                {
                    for (int i = 0; i < currentNode.Children.Count; i++)
                    {
                        var childNode = currentNode.Children[i];
                        nodes.Push(childNode);
                    }
                }
            }

            return leafNodes;
        }

        public List<TreeNode> GetMiddleNodes()
        {
            List<TreeNode> middleNodes = new List<TreeNode>();
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            for (int i = 0; i < this.Root.Children.Count; i++)
            {
                var childNode = this.Root.Children[i];
                nodes.Push(childNode);
            }

            while (nodes.Count != 0)
            {
                var currentNode = nodes.Pop();
                if (currentNode.Children.Count != 0)
                {
                    middleNodes.Add(currentNode);
                    for (int i = 0; i < currentNode.Children.Count; i++)
                    {
                        var childNode = currentNode.Children[i];
                        nodes.Push(childNode);
                    }
                }
            }

            return middleNodes;
        }

        public int[] GetLongestPath()
        {
            if (this.Root == null)
            {
                return null;
            }

            int[] longestPath = new int[1];
            List<int> currentPath = new List<int>();
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            nodes.Push(this.Root);
            longestPath[0] = this.Root.Value;
            currentPath.Add(this.Root.Value);
            return this.LongestPath(ref longestPath, ref currentPath, nodes);
        }

        public void PrintPathsBySum(long sum)
        {
            if (this.Root == null)
            {
                return;
            }

            List<int> currentPath = new List<int>();
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            nodes.Push(this.Root);
            currentPath.Add(this.Root.Value);
            this.CalculateSum(sum, ref currentPath, nodes);
        }

        public void FindSubtreesWithGivenSum(long sum)
        {
            if (this.Root == null)
            {
                return;
            }

            Stack<TreeNode> nodes = new Stack<TreeNode>();
            nodes.Push(this.Root);

            while (nodes.Count != 0)
            {
                var currentNode = nodes.Pop();
                bool isSumEqual = this.CheckIsSumEqual(currentNode, sum);
                if (isSumEqual)
                {
                    this.ReadTree(currentNode);
                }

                for (int i = 0; i < currentNode.Children.Count; i++)
                {
                    var child = currentNode.Children[i];
                    nodes.Push(child);
                }
            }
        }

        private bool CheckIsSumEqual(TreeNode node, long sum)
        {
            long tempSum = 0;

            Stack<TreeNode> nodes = new Stack<TreeNode>();
            nodes.Push(node);

            while (nodes.Count != 0)
            {
                var currentNode = nodes.Pop();
                tempSum += currentNode.Value;

                for (int i = 0; i < currentNode.Children.Count; i++)
                {
                    var child = currentNode.Children[i];
                    nodes.Push(child);
                }
            }

            if (tempSum == sum)
            {
                return true;
            }

            return false;
        }

        private void CalculateSum(long sum, ref List<int> currentPath, Stack<TreeNode> nodes)
        {
            while (nodes.Count != 0)
            {
                // if (ActualCalculation(sum, currentPath))
                // {
                // Console.WriteLine(string.Join(", ", currentPath));
                // }
                var currentNode = nodes.Pop();
                for (int i = 0; i < currentNode.Children.Count; i++)
                {
                    var currentChild = currentNode.Children[i];
                    currentPath.Add(currentChild.Value);
                    if (this.ActualCalculation(sum, currentPath))
                    {
                        Console.WriteLine(string.Join(", ", currentPath));
                    }

                    nodes.Push(currentChild);
                    this.CalculateSum(sum, ref currentPath, nodes);
                    currentPath.Remove(currentChild.Value);
                }
            }
        }

        private bool ActualCalculation(long sum, List<int> currentPath)
        {
            long tempSum = 0;
            for (int i = 0; i < currentPath.Count; i++)
            {
                tempSum += currentPath[i];
            }

            if (tempSum == sum)
            {
                return true;
            }

            return false;
        }

        private int[] LongestPath(ref int[] longestPath, ref List<int> currentPath, Stack<TreeNode> nodes)
        {
            while (nodes.Count != 0)
            {
                var currentNode = nodes.Pop();
                for (int i = 0; i < currentNode.Children.Count; i++)
                {
                    var currentChild = currentNode.Children[i];
                    currentPath.Add(currentChild.Value);
                    if (currentPath.Count > longestPath.Length)
                    {
                        this.CopyLongestPath(ref longestPath, currentPath);
                    }

                    nodes.Push(currentChild);
                    this.LongestPath(ref longestPath, ref currentPath, nodes);
                    currentPath.Remove(currentChild.Value);
                }
            }

            return longestPath;
        }

        private void CopyLongestPath(ref int[] longestPath, List<int> currentPath)
        {
            longestPath = new int[currentPath.Count];
            for (int i = 0; i < currentPath.Count; i++)
            {
                longestPath[i] = currentPath[i];
            }
        }

        private TreeNode FindNode(int parentValue)
        {
            if (this.Root.Value.Equals(parentValue))
            {
                return this.Root;
            }
            else
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                this.PushChildren(stack, this.Root);

                while (stack.Count != 0)
                {
                    TreeNode childNode = stack.Pop();
                    if (childNode.Value.Equals(parentValue))
                    {
                        return childNode;
                    }

                    this.PushChildren(stack, childNode);
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
    }
}
