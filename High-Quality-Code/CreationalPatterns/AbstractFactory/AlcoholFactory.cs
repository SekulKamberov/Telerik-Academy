namespace AbstractFactory
{
    public abstract class AlcoholFactory
    {
        public abstract Beer MakeBeer();

        public abstract Vodka MakeVodka();

        public abstract Rakia MakeRakia();
    }
}
