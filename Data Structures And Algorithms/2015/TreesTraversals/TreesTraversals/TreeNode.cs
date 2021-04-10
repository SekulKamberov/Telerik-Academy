namespace TreesTraversals
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

        public override string ToString()
        {
            return string.Format("Value: {0} Children-Count: {1}", this.Value, this.Children.Count);
        }
    }
}
