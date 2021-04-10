namespace RandomGenerator
{
    using System;
    using System.Text;

    public static class RandomGenerator
    {
        private static Random random = new Random();
        private static string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Chars
        {
            get
            {
                return chars;
            }

            set
            {
                chars = value;
            }
        }

        public static int GeneratRandomNumber(int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if (minValue > maxValue)
            {
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;
            }

            return random.Next(minValue, maxValue);
        }

        public static double GenerateRandomDouble(double minValue = double.MinValue, double maxValue = double.MaxValue, int precision = 2)
        {
            if (minValue > maxValue)
            {
                double temp = minValue;
                minValue = maxValue;
                maxValue = temp;
            }

            if (precision < 0)
            {
                precision = 0;
            }

            if (precision > 15)
            {
                precision = 15;
            }

            var randomDouble = (random.NextDouble() * (maxValue - minValue)) + minValue;
            var rounded = Math.Round(randomDouble, precision);

            return rounded;
        }

        /// <summary>
        /// StringBuilder implementation
        /// </summary>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string GenerateRandomWord(int minLength = 1, int maxLength = 10)
        {
            if (minLength > maxLength || minLength < 0 || maxLength < 1 || maxLength == int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("Invalid min or max length.");
            }

            int length = random.Next(minLength, maxLength + 1);

            StringBuilder wordStringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int charPosition = random.Next(chars.Length);
                wordStringBuilder.Append(chars[charPosition]);
            }

            return wordStringBuilder.ToString();
        }

        /// <summary>
        /// Char[] implementation
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomString(int length)
        {
            var charsGenerated = new char[length];

            for (int i = 0; i < length; i++)
            {
                charsGenerated[i] = Chars[random.Next(0, Chars.Length)];
            }

            return new string(charsGenerated);
        }

        /// <summary>
        /// Generates random date between provided datetime periods.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DateTime GenerateRandomDateTime(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                var tempDate = startDate;
                startDate = endDate;
                endDate = tempDate;
            }

            int seconds;
            int minutes;
            int hours;
            int day;
            int month;
            int year;
            DateTime randomDate;
            bool isDateCorrect;
            bool isBetweenDates = false;

            do
            {
                seconds = GeneratRandomNumber(0, 60);
                minutes = GeneratRandomNumber(0, 60);
                hours = GeneratRandomNumber(0, 24);
                day = GeneratRandomNumber(0, 32);
                month = GeneratRandomNumber(0, 13);
                year = GeneratRandomNumber(startDate.Year, endDate.Year + 1);

                isDateCorrect = DateTime.TryParse(string.Format("{0}/{1}/{2} {3}:{4}:{5}", month, day, year, hours, minutes, seconds), out randomDate);
                if (isDateCorrect)
                {
                    isBetweenDates = startDate < randomDate && randomDate < endDate;
                }
            }
            while (isBetweenDates == false);

            return randomDate;
        }

        /// <summary>
        /// Generates random date between current datetime and provided datetime.
        /// </summary>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DateTime GenerateRandomDateTime(DateTime endDate)
        {
            var startDate = DateTime.Now;

            return GenerateRandomDateTime(startDate, endDate);
        }

        public static DateTime RandomDateMillisecondsImplementation(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                var temp = startDate;
                startDate = endDate;
                endDate = temp;
            }

            var differenceInDays = (endDate - startDate).TotalDays;
            var randomDays = GenerateRandomDouble(0, differenceInDays, 8);
            return startDate.AddDays(randomDays);
        }
    }
}
