namespace AbstractFactory
{
    public class GarageInc : AlcoholFactory
    {
        private const string Name = "Baj Ivan v garaja na selo!";

        public override Beer MakeBeer()
        {
            var beer = new Beer(5, Flavor.None, Name);
            return beer;
        }

        public override Vodka MakeVodka()
        {
            var vodka = new Vodka(60, Flavor.None, Name);
            return vodka;
        }

        public override Rakia MakeRakia()
        {
            var rakia = new Rakia(70, Flavor.None, Name);
            return rakia;
        }
    }
}
