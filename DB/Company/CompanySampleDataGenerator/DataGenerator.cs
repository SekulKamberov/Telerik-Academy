namespace CompanySampleDataGenerator
{
    using CompanyData;
    using RandomGenerator;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedEntities)
        {
            this.random = randomDataGenerator;
            this.db = companyEntities;
            this.count = countOfGeneratedEntities;
        }

        protected IRandomDataGenerator Random
        {
            get
            {
                return this.random;
            }
        }

        protected CompanyEntities Database
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
