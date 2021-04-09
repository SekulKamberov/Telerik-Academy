namespace Models.Extensions
{
    using System;

    public static class RandomGenerator
    {
        private static Random instance;

        public static Random Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Random();
                }

                return instance;
            }
        }
    }
}
