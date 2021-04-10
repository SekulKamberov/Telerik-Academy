namespace _05.Bits
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            BitArray64 bits = new BitArray64(101);
            Console.WriteLine(bits[0]);
            Console.WriteLine(bits[1]);
            Console.WriteLine(bits[2]);
            Console.WriteLine(bits);
            bits[0] = 0;
            Console.WriteLine(bits);

            foreach (var bit in bits)
            {
                Console.WriteLine(bit);
            }

            BitArray64 bits2 = new BitArray64();
            Console.WriteLine(bits2);
            Console.WriteLine(bits == bits2);
            Console.WriteLine(bits2 == bits);
            Console.WriteLine(bits != bits2);
            Console.WriteLine(bits2 != bits);
            BitArray64 bits3 = new BitArray64(101);
            BitArray64 bits4 = new BitArray64(101);
            Console.WriteLine(bits3 == bits4);
        }
    }
}
