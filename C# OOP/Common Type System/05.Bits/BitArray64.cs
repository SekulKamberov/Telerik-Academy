namespace _05.Bits
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>, IComparable
    {
        private ulong number;

        public BitArray64()
            : this(0)
        {
        }

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public ulong Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public int this[int position]
        {
            get
            {
                if (position < 0 || position >= 64)
                {
                    throw new IndexOutOfRangeException("Invalid position.");
                }

                return (int)(this.Number >> position) & 1;
            }

            set
            {
                if (position < 0 || position >= 64)
                {
                    throw new IndexOutOfRangeException("Invalid position.");
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Invalid bit value.");
                }

                if (((int)(this.Number >> position) & 1) != value)
                {
                    this.Number ^= 1ul << position;
                }
            }
        }

        public static bool operator ==(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return firstBitArray.Equals(secondBitArray);
        }

        public static bool operator !=(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return !firstBitArray.Equals(secondBitArray);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int pos = 0; pos < 64; pos++)
            {
                result.Insert(0, (this.Number >> pos) & 1);
            }

            return result.ToString();
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is BitArray64)
            {
                BitArray64 bitsArray = obj as BitArray64;

                return this.Number == bitsArray.Number;
            }

            return false;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int pos = 0; pos < 64; pos++)
            {
                yield return this[pos];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CompareTo(object obj)
        {
            return this.Number.CompareTo((obj as BitArray64).Number);
        }
    }
}
