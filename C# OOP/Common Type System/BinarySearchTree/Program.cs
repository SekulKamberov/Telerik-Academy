namespace BinarySearchTree
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Node eigth = new Node(8);
            // Tree tree = new Tree(eigth);
            // Node ten = new Node(10);
            // Node four = new Node(4);
            // Node five = new Node(5);
            // Node nine = new Node(9);
            // Node one = new Node(1);
            // Node two = new Node(2);
            // Node seven = new Node(7);
            // Node fifteen = new Node(15);
            // Node zero = new Node(0);
            // Node three = new Node(3);
               
            // tree.Top.RigthNode = ten;
            // tree.Top.LeftNode = four;
            // four.RigthNode = five;
            // four.LeftNode = one;
            // five.RigthNode = seven;
            // one.RigthNode = two;
            // one.LeftNode = zero;
            // ten.LeftNode = nine;
            // ten.RigthNode = fifteen;
            // two.RigthNode = three;
            // Console.WriteLine(tree);
            // Node searchedNode = tree.Search(8);
            // Console.WriteLine(searchedNode);

            // searchedNode = tree.Search(4);
            // Console.WriteLine(searchedNode);
            // searchedNode = tree.Search(10);
            // Console.WriteLine(searchedNode);
            // searchedNode = tree.Search(1);
            // Console.WriteLine(searchedNode);
            // searchedNode = tree.Search(5);
            // Console.WriteLine(searchedNode);
            // searchedNode = tree.Search(9);
            // Console.WriteLine(searchedNode);
            // searchedNode = tree.Search(15);
            // Console.WriteLine(searchedNode);
            // searchedNode = tree.Search(0);
            // Console.WriteLine(searchedNode);
            // searchedNode = tree.Search(2);
            // Console.WriteLine(searchedNode);
            // searchedNode = tree.Search(7);
            // Console.WriteLine(searchedNode);
            Tree newTree = new Tree(new Node(8));
            newTree.AddNode(4);
            newTree.AddNode(10);
            newTree.AddNode(2);
            newTree.AddNode(7);
            newTree.AddNode(3);
            newTree.AddNode(1);
            newTree.AddNode(5);
            newTree.AddNode(9);
            newTree.AddNode(15);
            newTree.AddNode(0);
            Console.WriteLine(newTree);
            Console.WriteLine(newTree.DelleteNode(10));
            Console.WriteLine(newTree);

            // newTree.Top.LeftNode = null;
            // Console.WriteLine(newTree);

            // Node parrent = newTree.FindParrentNode(0);
            // Console.WriteLine(parrent);
               
            // Node zero = newTree.Search(0);
            // zero.LeftNode = new Node(-10);
            // zero.LeftNode.LeftNode = new Node(-15);
            // zero.LeftNode.RigthNode = new Node(5);
            // Console.WriteLine(newTree);
               
            // Node searchedNode = newTree.Search(8);
            // Console.WriteLine(newTree.FindParrentNode(15));
        }      
    }
}
