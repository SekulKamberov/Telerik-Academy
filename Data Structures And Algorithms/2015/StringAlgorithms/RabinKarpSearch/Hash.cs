namespace RabinKarpSearch
{
    public class Hash
    {
        private const ulong BASE = 257;
        private const ulong MOD = 1000000033;
        private static ulong[] powers;

        public Hash(string text)
        {
            this.Value = 0;

            foreach (char character in text)
            {
                this.Add(character);
            }
        }

        public ulong Value { get; private set; }

        public static void ComputePowers(int length)
        {
            powers = new ulong[length + 1];
            powers[0] = 1;

            for (int i = 0; i < length; i++)
            {
                powers[i + 1] = (powers[i] * BASE) % MOD;
            }
        }

        public void Add(char character)
        {
            this.Value = ((this.Value * BASE) + character) % MOD;
        }

        public void Remove(char character, int length)
        {
            this.Value = (MOD + this.Value - ((powers[length] * character) % MOD)) % MOD;
        }
    }
}
