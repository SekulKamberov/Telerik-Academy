namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree
    {
        private Node top;

        public Tree(Node top)
        {
            this.Top = top;
        }

        public Node Top
        {
            get { return this.top; }
            set { this.top = value; }
        }

        public bool AddNode(int newNodeValue)
        {
            if (this.Top == null)
            {
                this.Top = new Node(newNodeValue);

                return true;
            }

            if (this.Search(newNodeValue) != null)
            {
                return false;
            }

            Node currentNode = this.Top;

            while (true)
            {
                int currentNodeValue = currentNode.NodeValue;

                if (currentNodeValue == newNodeValue)
                {
                    return false;
                }
                else if (currentNodeValue < newNodeValue)
                {
                    if (currentNode.RigthNode == null)
                    {
                        currentNode.RigthNode = new Node(newNodeValue);

                        return true;
                    }

                    currentNode = currentNode.RigthNode;

                    // if (currentNode.RigthNode != null && currentNode.RigthNode.NodeValue > newNodeValue)
                    // {
                    // Node tempNode = currentNode.RigthNode;
                    // currentNode.RigthNode = new Node(newNodeValue);
                    // currentNode.RigthNode.RigthNode = tempNode;
                       
                    // return true;
                    // }
                }
                else
                {
                    if (currentNode.LeftNode == null)
                    {
                        currentNode.LeftNode = new Node(newNodeValue);

                        return true;
                    }

                    currentNode = currentNode.LeftNode;
                    
                    // if (currentNode.LeftNode != null && currentNode.LeftNode.NodeValue < newNodeValue)
                    // {
                    // Node tempNode = currentNode.LeftNode;
                    // currentNode.LeftNode = new Node(newNodeValue);
                    // currentNode.LeftNode.LeftNode = tempNode;
                       
                    // return true;
                    // }
                }
            }
        }

        public bool DelleteNode(int nodeValue)
        {
            Node nodeToBeDelleted = this.Search(nodeValue);

            if (nodeToBeDelleted == null)
            {
                return false;
            }

            Node rightNode = nodeToBeDelleted.RigthNode;
            Node leftNode = nodeToBeDelleted.LeftNode;

            if (leftNode == null && rightNode == null)
            {
                nodeToBeDelleted = null;
                return true;
            }

            if (leftNode == null)
            {
                nodeToBeDelleted = rightNode;
                return true;
            }

            if (rightNode == null)
            {
                nodeToBeDelleted = leftNode;
                return true;
            }

            Node rightestNodeOfTheLeftNode = this.FindMostRightNode(leftNode);
            Node parent = this.FindParrentNode(nodeValue);

            parent.LeftNode = leftNode;

            // nodeToBeDelleted = leftNode;
            rightestNodeOfTheLeftNode.RigthNode = rightNode;

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            char separator = '=';
            Queue<KeyValuePair<Node, int>> branches = new Queue<KeyValuePair<Node, int>>();

            if (this.Top != null)
            {
                KeyValuePair<Node, int> branch = new KeyValuePair<Node, int>(this.Top, 0);
                branches.Enqueue(branch);
            }

            while (branches.Count != 0)
            {
                KeyValuePair<Node, int> branch = branches.Dequeue();
                int separatorValue = branch.Value;
                int nodeValue = branch.Key.NodeValue;
                sb.Append(new string(separator, separatorValue) + nodeValue.ToString() + "\n");

                if (branch.Key.LeftNode != null)
                {
                    KeyValuePair<Node, int> leftBranch = new KeyValuePair<Node, int>(branch.Key.LeftNode, separatorValue + 2);
                    branches.Enqueue(leftBranch);
                }

                if (branch.Key.RigthNode != null)
                {
                    KeyValuePair<Node, int> rigthBranch = new KeyValuePair<Node, int>(branch.Key.RigthNode, separatorValue + 2);
                    branches.Enqueue(rigthBranch);
                }
            }

            return sb.ToString();
        }

        public Node Search(int nodeValue)
        {
            Node currentNode = this.Top;

            while (true)
            {
                int currentNodeValue = currentNode.NodeValue;

                if (currentNodeValue == nodeValue)
                {
                    return currentNode;
                }
                else if (currentNodeValue < nodeValue)
                {
                    currentNode = currentNode.RigthNode;

                    if (currentNode == null)
                    {
                        return null;
                    }
                }
                else
                {
                    currentNode = currentNode.LeftNode;

                    if (currentNode == null)
                    {
                        return null;
                    }
                }
            }
        }

        public Node FindParrentNode(int nodeValue)
        {
            if (this.Top.NodeValue == nodeValue)
            {
                return null;
            }

            Node currentNode = this.Top;
            Node parrentNode = this.Top;

            while (true)
            {
                int currentNodeValue = currentNode.NodeValue;

                if (currentNodeValue == nodeValue)
                {
                    return parrentNode;
                }
                else if (currentNodeValue < nodeValue)
                {
                    parrentNode = currentNode;
                    currentNode = currentNode.RigthNode;

                    if (currentNode == null)
                    {
                        return null;
                    }
                }
                else
                {
                    parrentNode = currentNode;
                    currentNode = currentNode.LeftNode;

                    if (currentNode == null)
                    {
                        return null;
                    }
                }
            }
        }
        
        private Node FindMostRightNode(Node currentNode)
        {
            if (currentNode.RigthNode == null)
            {
                return currentNode;
            }

            while (currentNode.RigthNode != null)
            {
                currentNode = currentNode.RigthNode;
            }

            return currentNode;
        }
    }
}