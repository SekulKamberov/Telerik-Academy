namespace PetStore.Importer
{
    using System;
    using System.Linq;

    public static class RandomGenerator
    {
        // private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random RandomInstance = new Random();

        public static string RandomString(int minLength, int maxLength)
        {
            var guid = Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
            var subStr = guid.Substring(0, RandomInstance.Next(minLength, maxLength + 1));
            return subStr;
        }

        public static DateTime RandomDate(DateTime startDate, DateTime endDate)
        {
            int startYear = startDate.Year;
            int endYear = endDate.Year;
            bool isDateCorect = false;
            bool isDateBetweenDates = false;
            DateTime randomDate;
            do
            {
                int randomYear = RandomInstance.Next(startYear, endYear + 1);
                int randomMonth = RandomInstance.Next(0, 13);
                int randomDay = RandomInstance.Next(0, 31);
                var stringDate = string.Format("{0}/{1}/{2}", randomMonth, randomDay, randomYear);
                isDateCorect = DateTime.TryParse(stringDate, out randomDate);
                if (isDateCorect)
                {
                    isDateBetweenDates = startDate <= randomDate && randomDate <= endDate;
                }
            }
            while (!isDateBetweenDates);

            return randomDate;
        }
    }
}
