namespace AbstractFactory
{
    public class Rakia : Alcohol
    {
        private readonly string madeBy;

        public Rakia(int percentage, Flavor flavor, string madeby)
            : base(percentage, flavor)
        {
            this.madeBy = madeby;
        }

        protected override string Name
        {
            get 
            {
                return string.Format("Rakia made by {0}", this.madeBy);
            }
        }
    }
}
