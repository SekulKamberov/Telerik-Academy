namespace _05._64BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public BitArray64() { }

        public int this[int pos]
        {
            get
            {
                if (pos < 0 || pos > 63)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }

                return (int)((this.number >> pos) & 1);
            }
            set
            {
                if (pos < 0 || pos > 63)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Value must be 0 or 1");
                }
                if (value == 1)
                {
                    this.number = this.number | ((ulong)1 << pos);
                }
                else
                {
                    this.number = this.number & (~((ulong)1 << pos));
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < 64; i++)
            {
                if (((this.number >> (63-i)) & 1) == 1)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            var objAsNum = obj as BitArray64;

            if (objAsNum == null)
            {
                return false;
            }

            return this.number == objAsNum.number;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.number.GetHashCode();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !(first.Equals(second));
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
