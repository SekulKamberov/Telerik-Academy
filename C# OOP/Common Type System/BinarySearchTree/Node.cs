namespace BinarySearchTree
{
    public class Node
    {
        private int nodeValue;
        private Node leftNode;
        private Node rigthNode;

        public Node(int nodeValue)
        {
            this.NodeValue = nodeValue;
        }

        public Node(Node node)
        {
            this.NodeValue = node.NodeValue;
            this.RigthNode = node.RigthNode;
            this.LeftNode = node.LeftNode;
        }
            
        public int NodeValue
        {
            get { return this.nodeValue; }
            set { this.nodeValue = value; }
        }

        public Node RigthNode
        {
            get { return this.rigthNode; }
            set { this.rigthNode = value; }
        }
        
        public Node LeftNode
        {
            get { return this.leftNode; }
            set { this.leftNode = value; }
        }

        public override string ToString()
        {
            if (this == null)
            {
                return "Node is NULL";
            }

            string leftNodeMessage = "Left node is NULL";
            string rigthNodeMessage = "Right node is NULL";

            if (this.RigthNode != null)
            {
                rigthNodeMessage = "Rigth Node Value:" + this.RigthNode.NodeValue;
            }

            if (this.LeftNode != null)
            {
                leftNodeMessage = "Left Node Value:" + this.LeftNode.NodeValue;
            }

            return string.Format("Node value: {0} {1} {2}", this.NodeValue, rigthNodeMessage, leftNodeMessage);
        }
    }
}
