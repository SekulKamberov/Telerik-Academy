namespace AhoCorasick
{
    public class Node
    {
        public Node()
        {
            this.Letter = new Node[26];
            this.Index = -1;
        }

        public Node[] Letter { get; set; }

        public Node FailLink { get; set; }

        public Node SuccessLink { get; set; }

        public int Index { get; set; }
    }
}
