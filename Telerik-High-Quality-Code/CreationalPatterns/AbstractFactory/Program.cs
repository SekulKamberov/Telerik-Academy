namespace AbstractFactory
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new GarageInc();
            var nightClub = new NightClub(factory);
            Console.WriteLine(nightClub.OrderBeer());
            Console.WriteLine(nightClub.OrderRakia());
            Console.WriteLine(nightClub.OrderVodka());
        }
    }
}
