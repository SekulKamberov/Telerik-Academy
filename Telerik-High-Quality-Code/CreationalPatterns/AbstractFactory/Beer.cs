namespace AbstractFactory
{
    public class Beer : Alcohol
    {
        private readonly string madeBy;

        public Beer(int percentage, Flavor flavor, string madeby)
            : base(percentage, flavor)
        {
            this.madeBy = madeby;
        }

        protected override string Name
        {
            get 
            {
                return string.Format("Beer made by {0}", this.madeBy);
            }
        }
    }
}
