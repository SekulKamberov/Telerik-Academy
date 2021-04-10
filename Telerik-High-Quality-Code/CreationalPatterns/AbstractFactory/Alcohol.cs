namespace AbstractFactory
{
    using System.Text;

    public abstract class Alcohol
    {
        private readonly int percentage;
        private readonly Flavor flavor;

        protected Alcohol(int percentage, Flavor flavor)
        {
            this.percentage = percentage;
            this.flavor = flavor;
        }

        protected abstract string Name { get; }

        private int Percentage
        {
            get
            {
                return this.percentage;
            }
        }

        private Flavor Flavor
        {
            get
            {
                return this.flavor;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.Name);
            stringBuilder.AppendLine(this.Percentage.ToString());
            stringBuilder.AppendLine(this.Flavor.ToString());
            return stringBuilder.ToString();
        }
    }
}
