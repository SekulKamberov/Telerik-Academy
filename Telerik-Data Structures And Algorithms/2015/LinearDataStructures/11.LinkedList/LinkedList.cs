namespace _11.LinkedList
{
    public class LinkedList<T>
    {
        private ListItem<T> firstItem;

        public LinkedList()
        {
        }

        public LinkedList(ListItem<T> firstItem)
        {
            this.firstItem = firstItem;
        }

        public ListItem<T> FirstItem 
        {
            get
            {
                return this.firstItem;
            }

            set
            {
                this.firstItem = value;
            } 
        }
    }
}
