namespace RandomGenerator
{
    using ATMStore;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ATMEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, ATMEntities atmEntities, int countGeneratedObjects)
        {
            this.random = randomDataGenerator;
            this.db = atmEntities;
            this.count = countGeneratedObjects;
        }

        protected IRandomDataGenerator Random
        {
            get
            {
                return this.random;
            }
        }

        protected ATMEntities Database
        {
            get
            {
                return this.db;
            }
        }

        protected int Count 
        {
            get
            {
                return this.count;
            }
        }

        public abstract void Generate();
    }
}
