namespace AhoCorasick
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Like KMP, but for multiple patterns
    /// "Partial match" prefix tree (trie) is precomputed 
    /// Linear in time
    /// Each occurrence of each pattern is found
    /// Linear in time
    /// There can be quadratic number of occurrences
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            Node root = new Node();

            // string[] patterns = Console.ReadLine().Split(' ');
            string[] patterns = { "abc", "bcd", "cde", "def", "efg" };

            // Build tree
            for (int i = 0; i < patterns.Length; i++)
            {
                Node rootNode = root;
                foreach (char charachter in patterns[i])
                {
                    if (rootNode.Letter[charachter - 'a'] == null)
                    {
                        rootNode.Letter[charachter - 'a'] = new Node();
                    }

                    rootNode = rootNode.Letter[charachter - 'a'];
                }

                rootNode.Index = i;
            }

            // Compute fail links
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();

                if (currentNode.FailLink != null)
                {
                    if (currentNode.FailLink.Index >= 0)
                    {
                        currentNode.SuccessLink = currentNode.FailLink;
                    }
                    else if (currentNode.FailLink.SuccessLink != null)
                    {
                        currentNode.SuccessLink = currentNode.FailLink.SuccessLink;
                    }
                }

                for (int i = 0; i < 26; i++)
                {
                    if (currentNode.Letter[i] == null)
                    {
                        continue;
                    }

                    queue.Enqueue(currentNode.Letter[i]);

                    Node failLinkNode = currentNode.FailLink;
                    while (failLinkNode != null && failLinkNode.Letter[i] == null)
                    {
                        failLinkNode = failLinkNode.FailLink;
                    }

                    currentNode.Letter[i].FailLink = (failLinkNode == null) ? root : failLinkNode.Letter[i];
                }
            }

            // Search
            // string text = Console.ReadLine();
            string text = "abcdefghtyhdefgkforbcde";
            int textLength = text.Length;
            Node matchedNode = root;

            for (int i = 0; i < textLength; i++)
            {
                while (matchedNode != null && matchedNode.Letter[text[i] - 'a'] == null)
                {
                    matchedNode = matchedNode.FailLink;
                }

                matchedNode = (matchedNode == null) ? root : matchedNode.Letter[text[i] - 'a'];

                if (matchedNode.Index >= 0)
                {
                    Console.WriteLine("{0} matches at {1}", patterns[matchedNode.Index], i - patterns[matchedNode.Index].Length + 1);
                }

                for (Node successNode = matchedNode.SuccessLink; successNode != null; successNode = successNode.SuccessLink)
                {
                    Console.WriteLine("{0} matches at {1}", patterns[successNode.Index], i - patterns[successNode.Index].Length + 1);
                }
            }
        }
    }
}
