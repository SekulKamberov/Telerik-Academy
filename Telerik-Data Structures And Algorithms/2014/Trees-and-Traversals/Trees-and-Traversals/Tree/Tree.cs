namespace Tree
{
    using System;
    using System.Collections.Generic;
    public class Tree<T> where T:IComparable<T>
    {
        public TreeNode<T> Root { get; set; }
        public void Add(T value)
        {
            var newNode = new TreeNode<T>()
            {
                Value = value
            };
            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                var parent = this.FindParentOf(value);
                if (parent.Value.CompareTo(value) < 0)
                {
                    parent.Right = newNode;
                }
                else
                {
                    parent.Left = newNode;
                }
            }
        }

        private TreeNode<T> FindParentOf(T value)
        {
            var node = this.Root;
            while (true)
            {
                //go Right
                if (node.Value.CompareTo(value) < 0)
                {
                    if (node.Right == null)
                    {
                        return node;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
                //go Left
                else
                {
                    if (node.Left == null)
                    {
                        return node;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
            }
        }

        public bool Search(T value)
        {
            var node = this.Root;

            while (node != null)
            {
                if(node.Value.CompareTo(value) == 0)
                {
                    return true;
                }
                // search right
                else if(node.Value.CompareTo(value) < 0)
                {
                    node = node.Right;
                }
                // search left
                else
                {
                    node = node.Left;
                }
            }
            return false;
        }

        public IEnumerable<T> GetInOrderValues()
        {
            var values = new List<T>();
            this.PerformInOrder(this.Root, values);
            return values;
        }

        private void PerformInOrder(TreeNode<T> node, List<T> values)
        {
            if (node == null)
            {
                return;
            }
            this.PerformInOrder(node.Left, values);
            values.Add(node.Value);
            this.PerformInOrder(node.Right, values);
        }
    }

    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
}
