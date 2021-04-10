namespace _11.LinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var listItem1 = new ListItem<int>(1);
            var listItem2 = new ListItem<int>(2, listItem1);
            var listItem3 = new ListItem<int>(3, listItem2);

            var listItem = listItem3;
            while (true)
            {
                Console.WriteLine("Item value: " + listItem.Value);
                var nextItem = listItem.NextItem;
                if (nextItem == null)
                {
                    return;
                }

                listItem = nextItem;
            }
        }
    }
}
