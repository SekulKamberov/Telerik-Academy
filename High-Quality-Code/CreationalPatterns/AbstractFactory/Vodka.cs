namespace AbstractFactory
{
    public class Vodka : Alcohol
    {
        private readonly string madeBy;

        public Vodka(int percentage, Flavor flavor, string madeby)
            : base(percentage, flavor)
        {
            this.madeBy = madeby;
        }

        protected override string Name
        {
            get 
            {
                return string.Format("Vodka made by {0}", this.madeBy);
            }
        }
    }
}
