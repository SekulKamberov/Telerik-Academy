namespace _02.OrderBagSearch
{
    using System;
    using System.Text;

    public class DataGerator
    {
        private static Random randomNumberGenerator = new Random();
        private const string chars =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";

        public static string GenerateWord()
        {
            int length = randomNumberGenerator.Next(5, 10);

            StringBuilder wordStringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int charPosition = randomNumberGenerator.Next(chars.Length);
                wordStringBuilder.Append(chars[charPosition]);
            }

            return wordStringBuilder.ToString();
        }

        public static double GeneratePrice()
        {
            double price = Math.Round((randomNumberGenerator.NextDouble() * 100), 2);

            return price;
        }
    }
}
