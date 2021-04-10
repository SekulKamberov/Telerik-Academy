namespace AbstractFactory
{
    public class Vinprom : AlcoholFactory
    {
        private const string Name = "Viprom Peshtera";

        public override Beer MakeBeer()
        {
            var beer = new Beer(5, Flavor.None, Name);
            return beer;
        }

        public override Vodka MakeVodka()
        {
            var vodka = new Vodka(40, Flavor.Vanila, Name);
            return vodka;
        }

        public override Rakia MakeRakia()
        {
            var rakia = new Rakia(45, Flavor.Apple, Name);
            return rakia;
        }
    }
}
