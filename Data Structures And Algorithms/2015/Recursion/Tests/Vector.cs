namespace Tests
{
    public class Vector
    {
        public Vector(int size, int index)
        {
            this.Bytes = new int[size];
            this.Index = index;
        }

        public int[] Bytes { get; set; }

        public int Index { get; set; }
    }
}
