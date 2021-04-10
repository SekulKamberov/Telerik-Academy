namespace AbstractFactory
{
    public class NightClub
    {
        private readonly AlcoholFactory alcoholFactory;

        public NightClub(AlcoholFactory alcoholFactory)
        {
            this.alcoholFactory = alcoholFactory;
        }

        public Beer OrderBeer()
        {
            return this.alcoholFactory.MakeBeer();
        }

        public Vodka OrderVodka()
        {
            return this.alcoholFactory.MakeVodka();
        }

        public Rakia OrderRakia()
        {
            return this.alcoholFactory.MakeRakia();
        }
    }
}
